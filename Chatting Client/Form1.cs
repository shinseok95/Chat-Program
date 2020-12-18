using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using packet;
using ClientEncryption;

namespace Chatting_Client
{
    public partial class Form1 : Form
    {

        private const int MAXSIZE = 1024 * 4;
        private Point mousePoint;

        // 서버 주소(IP,PORT)
        private string serverIP = "59.5.217.102";
        private int serverPORT = 19132;

        // stream
        public NetworkStream m_Stream;
        
        // Buffer
        public byte[] sendBuffer = new byte[MAXSIZE];
        public byte[] readBuffer = new byte[MAXSIZE];

        //Packet
        
        public LoginInfo p_login = new LoginInfo();
        public PartnerList p_list = new PartnerList();
        public Partner p_partner = new Partner();
        public Msg p_message = new Msg();
        public SignUpQuery p_signUp = new SignUpQuery();
        public SignUpAnswer p_signUpAnswer = new SignUpAnswer();
        public DisConnect p_disConnect = new DisConnect();
        public ImageData p_imageData = new ImageData();

        // 자식 Form
        Select select= new Select();
        Login login= new Login();
        SignUp signUp = new SignUp();
        Chatting chatting = new Chatting();
        
        TcpClient m_Client;
        
        // 메시지 스레드
        Thread message_handler;
        Thread select_handler;
        Thread signUp_handler;
        Thread talk_handler;

        // Client 정보
        public string ID = null;
        public string PW = null;
        public string partner_ID = null;
        private string key = null; // 암호 key

        // 단계별 진행 상황
        public bool m_bConnect = false;
        public bool m_login = false;
        public bool m_select = false;
        public bool m_chatting = false;

        public Form1()
        {
            InitializeComponent();

            if (m_bConnect)
                return;

            try
            {
                // 서버와 연결
                Connect();

                // 메시지 스레드 켜기
                message_handler = new Thread(new ThreadStart(Receiver));
                message_handler.Start();
                
            }

            catch
            {
                MessageBox.Show("서버와 연결에 실패하였습니다\t\n연결 상태를 확인해주세요");
            }
        }

        
        /*---------------------서버 연결------------------------*/

        public void Connect()
        {

            IPAddress localAddr = IPAddress.Parse(serverIP);

            m_Client = new TcpClient();

            try
            {
                m_Client.Connect(serverIP,serverPORT);
            }
            catch
            {
                m_bConnect = false;
                return;
            }

            m_bConnect = true; // 접속 완료

            // Stream 설정
            m_Stream = m_Client.GetStream();
        }

        /*---------------------자식 폼 : 대화상대 선택------------------------*/


        public void selectPerson()
        {
            select.home = this;
            
            DialogResult dResult = select.ShowDialog();
            
            // 선택 및 연결 완료
            if (dResult == DialogResult.OK)
            {
                m_select = true;
                MessageBox.Show("상대방과 연결되었습니다.");
                
               select_handler.Abort();
            }

            // 선택 및 연결 실패
            else if (dResult == DialogResult.Cancel)
            {
                setVisible();
                logOut(ID);

                ID = null;
                PW = null;
                key = null;
                
                select_handler.Abort();
            }
        }

        /*---------------------자식 폼 : 대화상대 선택------------------------*/


        public void chattingOpen()
        {
            chatting.home = this;
            chatting.setPartner();
            m_chatting = true;

            DialogResult dResult = chatting.ShowDialog();

            // 채팅방을 나온 경우
            if (dResult == DialogResult.OK)
            {
                // 대화 종료
                m_chatting = false;
                m_select = false;
                m_login = false;

                logOut(ID);

                ID = null;
                PW = null;
                key = null;

                setVisible();

                talk_handler.Abort();
            }

            // 그냥 끈 경우
            else if (dResult == DialogResult.Cancel)
            {
                // 대화 종료
                m_chatting = false;
                m_select = false;
                m_login = false;

                logOut(ID);
                
                logOut(null);

                Disconnect();
                Application.Exit();
                
            }
        }


        /*---------------------메시지 수신(server -> client)------------------------*/

        public void Receiver()
        {
            int nRead = 0;

            while (m_bConnect)
            {
                try
                {

                    nRead = 0;
                    nRead = this.m_Stream.Read(readBuffer, 0, MAXSIZE);
                }
                catch
                {
                    Disconnect();
                }

                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);


                switch ((int)packet.Type)
                {

                    case (int)PacketType.가입성공:
                        {

                            this.p_signUpAnswer = (SignUpAnswer)Packet.Desserialize(this.readBuffer);

                            MessageBox.Show("축하합니다\t\n[" + p_signUpAnswer.ID + "]님 회원가입 되었습니다.\t\n로그인 해주세요");

                            signUp.clearSignUp();
                            signUp.signUpOK();

                            p_signUpAnswer.clear();
                            break;
                        }

                    case (int)PacketType.가입실패:
                        {

                            MessageBox.Show("로그인에 실패하였습니다\t\n다시 시도해주세요");

                            signUp.clearSignUp();
                            break;
                        }
                    case (int)PacketType.중복확인:
                        {

                            this.p_signUpAnswer = (SignUpAnswer)Packet.Desserialize(this.readBuffer);

                            // ID 사용가능
                            if (p_signUpAnswer.isValid)
                            {
                                signUp.setIdCheck(p_signUpAnswer.ID);
                                MessageBox.Show("[" + p_signUpAnswer.ID + "]는 사용 가능합니다.");
                            }

                            // ID 사용 불가능
                            else
                            {
                                MessageBox.Show("[" + p_signUpAnswer.ID + "]는 이미 사용 중입니다.");
                            }

                            p_signUpAnswer.clear();
                            break;
                        }

                    case (int)PacketType.로그인:
                        {
                            if (!m_login)
                            {
                                this.p_login = (LoginInfo)Packet.Desserialize(this.readBuffer);

                                // 현재 접속 X
                                if (p_login.isValid)
                                {

                                    // 로그인 성공
                                    if (p_login.isLoginOK)
                                    {
                                        m_login = true;

                                        MessageBox.Show("[" + ID + "]님 반갑습니다\t\n대화 상대를 골라주세요");

                                        this.Visible = false;
                                        // 선택 스레드 켜기
                                        select_handler = new Thread(new ThreadStart(selectPerson));
                                        select_handler.Start();
                                    }
                                    else
                                    {
                                        MessageBox.Show("아이디 혹은 비밀번호를 확인해주세요");

                                        ID = null;
                                        PW = null;
                                    }
                                }

                                // 현재 접송 O
                                else
                                {
                                    MessageBox.Show("[" + ID + "]는 접속 중입니다.\t\n다시 확인해주세요");

                                    ID = null;
                                    PW = null;
                                }
                            }

                            p_list.clear();
                            break;
                        }

                    case (int)PacketType.목록요청:
                        {
                            if (!m_select)
                            {
                                this.p_list = (PartnerList)Packet.Desserialize(this.readBuffer);

                                foreach (string item in p_list.partners)
                                {
                                    if (item != this.ID)
                                        select.setList(item);
                                }
                            }

                            p_list.clear();
                            break;
                        }

                    // 연결 신청이 온 경우
                    case (int)PacketType.연결신청:
                        {
                            if (!m_select)
                            {
                                this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                                if (connect_question(this.p_partner.ID))
                                {
                                    p_partner.Type = (int)PacketType.연결성공;

                                    Packet.Serialize(p_partner).CopyTo(sendBuffer, 0);

                                    Send();
                                }
                                else
                                {
                                    p_partner.Type = (int)PacketType.연결거부;
                                    p_partner.ID = this.ID;

                                    Packet.Serialize(p_partner).CopyTo(sendBuffer, 0);

                                    Send();
                                }
                            }

                            p_partner.clear();
                            break;
                        }

                    // 연결 신청이 성공한 경우
                    case (int)PacketType.연결성공:
                        {
                            this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                            partner_ID = p_partner.ID;
                            key = p_partner.Key;
                            select.selectOK();
                            

                            // 채팅 스레드 켜기
                            talk_handler = new Thread(new ThreadStart(chattingOpen));
                            talk_handler.Start();

                            p_partner.clear();
                            break;
                        }

                    case (int)PacketType.연결거부:
                        {
                            this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                            // 상대방이 대화 중이라면
                            if (p_partner.isAlreadyConnected)
                            {
                                MessageBox.Show("[" + p_partner.ID + "]님은 대화중이십니다.");

                                select.list_login.Items.Clear();
                                p_list.Type = (int)PacketType.목록요청;

                                Packet.Serialize(p_list).CopyTo(sendBuffer, 0);

                                Send();
                                
                            }
                            else
                                MessageBox.Show("[" + p_partner.ID + "]님께서 거절하셨습니다\t\n다른 분을 선택해주세요");


                            p_partner.clear();
                            break;
                        }


                    // 연결 신청이 온 경우
                    case (int)PacketType.연결해제:
                        {

                            this.p_disConnect = (DisConnect)Packet.Desserialize(this.readBuffer);

                            MessageBox.Show("[" + p_disConnect.ID + "]님께서 로그아웃 하셨습니다.");

                            p_disConnect.clear();

                            break;
                        }

                    case (int)PacketType.수신:
                        {
                            Encryption aes = new Encryption();

                            this.p_message = (Msg)Packet.Desserialize(this.readBuffer);
                            
                            string secretMessage = aes.AESDecrypt256(p_message.message, this.key);
                            
                            chatting.inMessage(secretMessage, p_message.time);
                            p_message.clear();

                            break;
                        }

                    case (int)PacketType.이미지수신:
                        {
                            this.p_imageData = (ImageData)Packet.Desserialize(this.readBuffer);

                            byte[] readImage = new byte[p_imageData.size+10];
                            nRead = 0;
                            nRead = this.m_Stream.Read(readImage, 0, p_imageData.size);

                            Bitmap bitmap = byteToImage(readImage);

                            chatting.inImage(bitmap,p_imageData.time);

                            p_imageData.clear();

                            break;
                        }
                }


            }
        }

        /*---------------------Byte to Image----------------------*/


        public Bitmap byteToImage(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                ms.Write(data, 0, data.Length);
                ms.Seek(0, SeekOrigin.Begin);

                Bitmap bitmap = new Bitmap(ms);

                return bitmap;
            }
        }


        /*---------------------메시지 발신------------------------*/

        public void Send()
        {
            try
            {
                this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_Stream.Flush();

                for (int i = 0; i < MAXSIZE; i++)
                    this.sendBuffer[i] = 0;
            }

            catch
            {
                //Message("쓰기 오류 발생");
            }

        }
    
        /*---------------------상대방에게 연결 신호가 온 경우------------------------*/
        
        public bool connect_question(string id)
        {
            var result = MessageBox.Show("[" +id + "] 님께서 대화신청을 하셨습니다.\r\n연결 하시겠습니까?", "Caption", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                partner_ID = id;
                return true;
            }

            else
                return false;
        }
        
        /*---------------------서버와 연결 해제------------------------*/

        public void Disconnect()
        {
            if (!m_bConnect)
                return;
            
            m_bConnect = false;

            m_Client.Close();
            m_Stream.Close();
            message_handler.Abort();

            //Message("상대방과 연결 중단");
        }


        /*---------------------자식 폼 : 로그인--------------------------------------*/


        private void btn_login_Click(object sender, EventArgs e)
        {
       
            login.home = this;
            
            DialogResult dResult = login.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                p_login.Type = (int)PacketType.로그인;
                p_login.ID = this.ID;
                p_login.PW = this.PW;

                Packet.Serialize(p_login).CopyTo(sendBuffer, 0);

                Send();
            }
            else if (dResult == DialogResult.Cancel)
            {

            ID = null;
            PW = null;
                
            }

        }
        
        /*---------------------자식 폼 : 로그인 화면 -> 상대방 연결 ------------------------*/
       
        private void openSignUp()
        {
            signUp.home = this;
            DialogResult dResult = signUp.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                signUp.clearSignUp();
                signUp_handler.Abort();
                
            }

            else if (dResult == DialogResult.Cancel)
            {
                signUp.clearSignUp();
                signUp_handler.Abort();
                
            }
        }
        private void btn_signUp_Click(object sender, EventArgs e)
        {
            
            signUp_handler = new Thread(new ThreadStart(openSignUp));
            signUp_handler.Start();
        }

        /*---------------------최소화, 숨기기, 로그아웃, 종료------------------------*/


        public void setVisible()
        {
            this.Visible = true;
        }

        private void logOut(string id)
        {

            this.key = null;
            this.partner_ID = null;

            p_disConnect.Type = (int)PacketType.연결해제;
            p_disConnect.ID = id;

            Packet.Serialize(p_disConnect).CopyTo(sendBuffer, 0);

            Send();

            m_login = false;
            m_select = false;
        }
        

        private void lbl_minimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            logOut(null);
            Disconnect();
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logOut(null);
            Disconnect();
        }

        /*--------------------------Mouse 관련 함수----------------------------------*/

            
        private void pnl_background_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void pnl_background_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }


        /*--------------------------Mouse 관련 함수----------------------------------*/

        public string getKey()
        {
            return key;
        }

    }
}
