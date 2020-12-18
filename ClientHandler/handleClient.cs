using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using packet;
using System.Timers;
using MySql.Data.MySqlClient;

namespace ClientHandler
{
    public class handleClient
    {
        private const int MAXSIZE = 1024 * 4;

        private int clientNum;

        //연결 상대
        handleClient partner =null;

        TcpClient clientSocket;

        // Buffer
        public byte[] sendBuffer = new byte[MAXSIZE];
        public byte[] readBuffer = new byte[MAXSIZE];
        

        //Packet
        public LoginInfo p_login = new LoginInfo();
        public Msg p_message = new Msg();
        public Partner p_partner = new Partner();
        public PartnerList p_partnerList = new PartnerList();
        public SignUpQuery p_signUp = new SignUpQuery();
        public SignUpAnswer p_signUpAnswer = new SignUpAnswer();
        public DisConnect p_disConnect = new DisConnect();
        public ImageData p_imageData = new ImageData();

        public NetworkStream stream;
        
        //메시지 스레드
        Thread t_handler;
        
        // CLient 정보
        private string ID=null;
        private string PW=null;
        
        // 단계별 진행 상황
        private bool m_bConnect = false;
        private bool m_login = false;
        private bool m_select = false;
        
        
        /*-------------------------------------Client EVENT 처리 함수-------------------------------------------*/


        // 서버와 연동 (가입신청)
        public delegate void SignUpHandler(string id, string pw, string name, string phone, handleClient client);
        public event SignUpHandler OnSignUp;
        
        // 서버와 연동 (아이디 중복확인)
        public delegate void IdCheckHandler(string id,handleClient client);
        public event IdCheckHandler OnIdCheck;
        
        // 서버와 연동 (메시지)
        public delegate void MessageDisplayHandler(string message, string time, handleClient client);
        public event MessageDisplayHandler OnChatting;
        
        // 서버와 연동 (이미지)
        public delegate void ImageDisplayHandler(byte[] readImage, int size, handleClient client);
        public event ImageDisplayHandler OnImage;

        // 서버와 연동 (로그인)
        public delegate void LoginDataHandler(string ID, string PW, handleClient client);
        public event LoginDataHandler OnLogin;
        
        // 서버와 연동 (상대방 선택)
        public delegate void ListHandler(handleClient client);
        public event ListHandler OnList;

        // 서버와 연동 (상대방 연결 시도)
        public delegate void ClientConnectHandler(string id, handleClient client);
        public event ClientConnectHandler OnConnect;

        // 서버와 연동 (상대방 연결 확정)
        public delegate void ConnectCompleteHandler(bool value, string id, handleClient client);
        public event ConnectCompleteHandler OnComplete;
        
        // 서버와 연동 (연결해제)
        public delegate void DisConnectHandler(string id, handleClient client);
        public event DisConnectHandler OnDisConnect;

        /*------------------------------------------------------------------------------------------------------*/
        

        /*---------------------------Client와 연결 Start-----------------------------*/

        public void startClient(int count ,TcpClient ClientSocket)
        {

            this.clientNum = count;
            
            this.clientSocket = ClientSocket;
            
            this.stream = clientSocket.GetStream();

            this.m_bConnect = true;
            t_handler = new Thread(new ThreadStart(Receiver));
            t_handler.Start();
            
        }

        /*---------------------메시지 수신(Client -> server)------------------------*/

        public void Receiver()
        {
            try
            {
                int nRead;

                while (m_bConnect)
                {
                    nRead = 0;
                    nRead = this.stream.Read(readBuffer, 0, MAXSIZE);
                   
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    switch ((int)packet.Type)
                    {

                        case (int)PacketType.가입신청:
                            {

                                this.p_signUp = (SignUpQuery)Packet.Desserialize(this.readBuffer);
                                
                                OnSignUp(p_signUp.ID, p_signUp.PW, p_signUp.name, p_signUp.phone, this);

                                break;
                            }

                        case (int)PacketType.중복확인:
                            {

                                this.p_signUpAnswer = (SignUpAnswer)Packet.Desserialize(this.readBuffer);
                                OnIdCheck(p_signUpAnswer.ID, this);

                                break;
                            }

                        case (int)PacketType.로그인:
                            {
                                if (!m_login)
                                {
                                    this.p_login = (LoginInfo)Packet.Desserialize(this.readBuffer);

                                    ID = this.p_login.ID;
                                    PW = this.p_login.PW;

                                    OnLogin(ID, PW, this);
                                }

                                break;
                            }

                        case (int)PacketType.목록요청:
                            {
                                if (!m_select)
                                    OnList(this);

                                break;
                            }

                        case (int)PacketType.연결신청:
                            {
                                if (!m_select)
                                {
                                    this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                                    OnConnect(this.p_partner.ID, this);
                                    p_partner.clear();
                                }

                                break;
                            }

                        case (int)PacketType.연결성공:
                            {
                                if (!m_select)
                                {
                                    this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                                    OnComplete(true, this.p_partner.ID, this);

                                    p_partner.clear();
                                }

                                break;
                            }

                        case (int)PacketType.연결거부:
                            {
                                if (!m_select)
                                {
                                    this.p_partner = (Partner)Packet.Desserialize(this.readBuffer);

                                    OnComplete(false, this.p_partner.ID, this);

                                    p_partner.clear();
                                }

                                break;
                            }
                            

                        case (int)PacketType.발신:
                            {
                                this.p_message = (Msg)Packet.Desserialize(this.readBuffer);
                                
                                OnChatting(p_message.message,p_message.time, this);

                                p_message.clear();
                                break;
                            }

                        case (int)PacketType.연결해제:
                            {
                                this.p_disConnect = (DisConnect)Packet.Desserialize(this.readBuffer);

                                m_login = false;
                                m_select = false;
                                OnDisConnect(p_disConnect.ID, this);

                                p_disConnect.clear();
                                break;
                            }

                        case (int)PacketType.이미지발신:
                            {
                                this.p_imageData = (ImageData)Packet.Desserialize(this.readBuffer);

                                byte[] readImage = new byte[p_imageData.size+10];

                                nRead = 0;
                                nRead = this.stream.Read(readImage, 0, p_imageData.size);
                                
                                OnImage(readImage, p_imageData.size,this);

                                p_imageData.clear();


                                break;
                            }
                    }
                    
                }
            }
            catch
            {
               // Message("읽기 오류 발생");
            }

            Disconnect();
        }

        /*---------------------연결 해제------------------------*/

        public void Disconnect()
        {
            if (!m_bConnect)
                return;

            m_bConnect = false;
            
            stream.Close();
            t_handler.Abort();

            //Message("상대방과 연결 중단");
        }
        
        /*---------------------메시지 전송------------------------*/

        public void Send()
        {
            try
            {
                this.stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.stream.Flush();

                for (int i = 0; i < MAXSIZE; i++)
                    this.sendBuffer[i]=0;
            }

            catch
            {
                //Message("쓰기 오류 발생");
            }

        }
        
        
        /*-------------------Get,Set----------------------*/


        public void setID(string id)
        {
            this.ID = id;
        }

        public void setPW(string pw)
        {
            this.PW = pw;
        }

        public string getID()
        {
            return this.ID;
        }

        public string getPW()
        {
            return this.PW;
        }
        
        public void setPartner(handleClient Other)
        {
            this.partner = Other;

        }

        public handleClient getPartner()
        {
            return this.partner;
        }

        public void setConnect()
        {
            m_bConnect = true;
        }
        public void setLogin()
        {
            m_login = true;
        }
        public void setSelect()
        {
            m_select= true;
        }

        public int getClientNum()
        {
            return clientNum;
        }


    }

}