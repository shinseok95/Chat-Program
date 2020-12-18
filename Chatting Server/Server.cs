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
using ClientHandler;
using packet;
using ClientEncryption;
using MySql.Data.MySqlClient;

namespace Chatting_Server
{
    public partial class FlyTalk : Form
    {
        // 서버 주소(IP,PORT)


        string serverIP= ""; //보안을 위해 업로드 전 삭제
        int PORT = ; //보안을 위해 업로드 전 삭제
        
        TcpListener server = null;
        Thread t;

        // 접속 Client 수
        static int counter = 0;

        private string loginKey="ParkHyoShin";

        // 현재 접속 Client 목록
        Dictionary<string, handleClient> clientList = new Dictionary<string,handleClient>();

        // mySQL 데이터 관리
        MySqlConnection conn =
        new MySqlConnection("Server=localhost;Database=clientdata;Uid=root;Pwd=gustjr2924;");
        

        // 가입 Client 데이터베이스
        ClientData clientData;
        
        private bool m_bStop = false;

        public FlyTalk()
        {
            InitializeComponent();
            
            // 데이터 베이스 초기화
            clientData = new ClientData();
            ClientDataGridView.DataSource = clientData.Tables["Client"];
            

            // DB 연동
            conn.Open();
            string sql = "SELECT * FROM client";

            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader table = command.ExecuteReader();

            // 고객 정보 가져오기
            while (table.Read())
            {
                clientData.Tables["Client"].Rows.Add(new object[] {
               clientData.Tables["Client"].Rows.Count+1, table["Name"].ToString(),table["ID"].ToString(), table["Password"].ToString(),table["Phone"].ToString() });

            }

            conn.Close();
        }

        /*---------------------서버 Start------------------------*/

        private void InitSocket()
        {
            IPAddress localAddr = IPAddress.Parse(serverIP);
            server = new TcpListener(localAddr, PORT);
            server.Start();
            
            m_bStop = true;
            Message(">>>>>Server Start<<<<<");

            while (m_bStop)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();

                    if (client.Connected)
                    {
                        counter++;
                        Message("Client " +counter + " : Connect");

                        handleClient h_client = new handleClient();

                        // Client event 처리
                        h_client.OnSignUp += new handleClient.SignUpHandler(signUpQuery);
                        h_client.OnIdCheck += new handleClient.IdCheckHandler(idChecker);
                        h_client.OnChatting += new handleClient.MessageDisplayHandler(message_handler);
                        h_client.OnLogin += new handleClient.LoginDataHandler(loginQuery);
                        h_client.OnList += new handleClient.ListHandler(listQuery);
                        h_client.OnConnect += new handleClient.ClientConnectHandler(connectQuery);
                        h_client.OnComplete += new handleClient.ConnectCompleteHandler(connectComplete);
                        h_client.OnDisConnect += new handleClient.DisConnectHandler(disConnect_handler);
                        h_client.OnImage += new handleClient.ImageDisplayHandler(image_handler);
                        
                        h_client.startClient(counter, client);
                    }
                }

                catch
                {
                    Message("접속 도중 오류 발생");
                    return;
                }
            }
        }

        /*-------------------------------------Client EVENT 처리 함수-------------------------------------------*/
        

        /*-----------------------------메시지 전송---------------------------------*/

        private void message_handler(string message, string time, handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    client.getPartner().p_message.message = message;
                    client.getPartner().p_message.time = client.p_message.time;
                    client.getPartner().p_message.Type = (int)PacketType.수신;

                    // mySQL 연동
                    string insertQuery = "INSERT INTO clientdialog(MyID, PartnerID, TIME, Content) VALUES('" + client.getID() + "','" + client.getPartner().getID() + "','" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "','" + message + "')";
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    Packet.Serialize(client.getPartner().p_message).CopyTo(client.getPartner().sendBuffer, 0);

                    client.getPartner().Send();
                    
                    client.getPartner().p_message.clear();
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Message("[" + client.getID() +" -> "+ client.getPartner().getID()+"] : 메시지 전송 오류");                }

            }));
        }

        /*-----------------------------이미지 전송---------------------------------*/

        private void image_handler(byte[] readImage, int size, handleClient client)
        {
           
            this.Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    // mySQL 연동
                    string insertQuery = "INSERT INTO clientdialog(MyID, PartnerID, TIME, Content) VALUES('" + client.getID() + "','" + client.getPartner().getID() + "','" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "','" + "//**Image**//" + "')";
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, conn);
                    command.ExecuteNonQuery();
                    conn.Close();


                    client.getPartner().p_imageData.time = client.p_imageData.time;
                    client.getPartner().p_imageData.Type = (int)PacketType.이미지수신;
                    client.getPartner().p_imageData.size = size;

                    Packet.Serialize(client.getPartner().p_imageData).CopyTo(client.getPartner().sendBuffer, 0);

                    client.getPartner().Send();

                    client.getPartner().stream.Write(readImage, 0, size);
                    client.getPartner().stream.Flush();

                    client.getPartner().p_imageData.clear();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Message("[" + client.getID() + " -> " + client.getPartner().getID() + "] : 이미지 전송 오류");
                }

            }));
        }

        /*-------------------------회원가입---------------------------*/

            private void signUpQuery(string id, string pw, string name, string phone, handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    // PW 암호화
                    Encryption aes = new Encryption();
                    string secretMessage = aes.AESEncrypt256(pw, this.loginKey);
                    
                    // DataSet 추가
                    clientData.Tables["Client"].Rows.Add(new object[] {
               clientData.Tables["Client"].Rows.Count+1, name,id, secretMessage,phone });
                    

                    // mySQL 연동
                    string insertQuery = "INSERT INTO client(No, Name, ID, Password, Phone) VALUES('" + (clientData.Tables["Client"].Rows.Count+1) + "','" + name + "','" + id +"','" + secretMessage + "','" +phone +"')";
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, conn);
                    command.ExecuteNonQuery();
                    conn.Close();


                    // send
                    client.p_signUpAnswer.isValid = true;
                    client.p_signUpAnswer.Type = (int)PacketType.가입성공;
                    client.p_signUpAnswer.ID = id;

                    Packet.Serialize(client.p_signUpAnswer).CopyTo(client.sendBuffer, 0);
                    client.Send();
                    
                }

                catch
                {
                    client.p_signUpAnswer.isValid = false;
                    client.p_signUpAnswer.Type = (int)PacketType.가입실패;
                    client.p_signUpAnswer.ID = id;

                    Packet.Serialize(client.p_signUpAnswer).CopyTo(client.sendBuffer, 0);
                    client.Send();
                }

                client.p_signUpAnswer.clear();

            }));
        }

        /*-------------------ID 중복확인---------------------*/

        private void idChecker(string id,handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {

                // DB 연동
                conn.Open();
                string sql = "SELECT * FROM client";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader table = command.ExecuteReader();

                // 가입자 목록에서 중복확인
                while (table.Read()){

                    if (!table["ID"].ToString().Equals(id))
                        continue;

                    client.p_signUpAnswer.isValid = false;
                    client.p_signUpAnswer.Type = (int)PacketType.중복확인;
                    client.p_signUpAnswer.ID = id;

                    Packet.Serialize(client.p_signUpAnswer).CopyTo(client.sendBuffer, 0);
                    client.Send();

                    client.p_signUpAnswer.clear();

                    conn.Close();
                    return;

                }

                client.p_signUpAnswer.isValid = true;
                client.p_signUpAnswer.Type = (int)PacketType.중복확인;
                client.p_signUpAnswer.ID = id;

                Packet.Serialize(client.p_signUpAnswer).CopyTo(client.sendBuffer, 0);
                client.Send();

                client.p_signUpAnswer.clear();

                conn.Close();

            }));
        }
    
        /*---------------------로그인 신호------------------------*/

        private void loginQuery(string id, string pw, handleClient client)
        {

            this.Invoke(new MethodInvoker(delegate ()
            {

            // 현재 로그인 중인 아이디가 아닌 경우
            if (!clientList.ContainsKey(id))
            {
                if(isLoginOK(id, pw))
                    {
                        Message("["+id + "] : Login");
                        clientList.Add(id, client);

                        client.setLogin();

                        client.p_login.isValid = true;
                        client.p_login.isLoginOK = true;

                        Packet.Serialize(client.p_login).CopyTo(client.sendBuffer, 0);
                        client.Send();

                        client.p_login.clear();
                    }

                    else
                    {
                        client.setID(null);
                        client.setPW(null);
                        client.p_login.isValid = true;
                        client.p_login.isLoginOK = false;

                        Packet.Serialize(client.p_login).CopyTo(client.sendBuffer, 0);
                        client.Send();

                        client.p_login.clear();
                    }
            }

                // 현재 로그인 중인 아이디인 경우
                else
                {
                client.setID(null);
                client.setPW(null);
                client.p_login.isValid = false;

                Packet.Serialize(client.p_login).CopyTo(client.sendBuffer, 0);
                client.Send();

                client.p_login.clear();
                }
            
            }));

        }


        /*---------------------아이디 목록 요청 신호------------------------*/

        private void listQuery(handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
            client.p_partnerList.Type = (int)PacketType.목록요청;

                foreach (KeyValuePair<string, handleClient> item in clientList)
                    client.p_partnerList.partners.Add(item.Key);
        
                Packet.Serialize(client.p_partnerList).CopyTo(client.sendBuffer, 0);
                client.Send();

                client.p_partnerList.clear();

            }));
        }


        /*---------------------연결 요청 신호------------------------*/

        private void connectQuery(string id, handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                // 상대방이 대화 중이 아니라면
                if (clientList.ContainsKey(id))
                {

                    client.p_partner.Type = (int)PacketType.연결신청;
                    client.p_partner.ID = client.getID();

                    Packet.Serialize(client.p_partner).CopyTo(clientList[id].sendBuffer, 0);

                    clientList[id].Send();
                }
                // 대화중이라면
                else
                {
                    client.p_partner.Type = (int)PacketType.연결거부;
                    client.p_partner.ID = id;
                    client.p_partner.isAlreadyConnected = true;


                    Packet.Serialize(client.p_partner).CopyTo(client.sendBuffer, 0);

                    client.Send();
                }

            client.p_partner.clear();
            }));
        }


        /*---------------------연결 요청 신호------------------------*/


        private void connectComplete(bool isOK, string id, handleClient client)
        {

            this.Invoke(new MethodInvoker(delegate ()
            {
                //연결 승인이 됐다면
                if (isOK)
            {
                    
                    // Key 값 생성
                    int key = 0;
                    Random rand = new Random();
                    for (int i = 0; i < 100; i++)
                    key += rand.Next(1, 100);
                    
                    Message("[" + client.getID() + " , " + id + "] 대화를 시작하였습니다.");
                    
                clientList[id].p_partner.Type = (int)PacketType.연결성공;
                clientList[id].p_partner.ID = client.getID();
                clientList[id].p_partner.Key = key.ToString();
                    

                Packet.Serialize(clientList[id].p_partner).CopyTo(clientList[id].sendBuffer, 0);

                    
                clientList[id].setPartner(client);
                clientList[id].setSelect();
                clientList[id].Send();

                 clientList[id].p_partner.clear();

                client.p_partner.Type = (int)PacketType.연결성공;
                client.p_partner.ID = id;
                client.p_partner.Key = key.ToString();

                Packet.Serialize(client.p_partner).CopyTo(client.sendBuffer, 0);


                clientList.Remove(client.getID());
                client.setPartner(clientList[id]);
                client.setSelect();
                client.Send();

                    clientList.Remove(client.getID());
                    clientList.Remove(clientList[id].getID());
                    client.p_partner.clear();
        }

            //연결 승인이 되지 않았다면
            else
            {
                client.p_partner.Type = (int)PacketType.연결거부;
                client.p_partner.ID = id;
                client.p_partner.isAlreadyConnected = false;
                Packet.Serialize(client.p_partner).CopyTo(client.sendBuffer, 0);
                client.Send();


                    client.p_partner.clear();
                }
                
            }));
        }
        
        /*---------------------연결 해제 신호------------------------*/

         private void disConnect_handler(string id, handleClient client)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {

                if(id == null)
                    Message("Client " + client.getClientNum() + " : Disconnect");

                // 로그인 X
                if (!clientList.ContainsKey(id))
                {
                    Message("Client " + client.getClientNum() + " : Disconnect");
                }
                // 로그인 O
                else
                {
                    Message("[" + id+ "] : Logout");
                    
                    // 대화 중
                    if(client.getPartner() != null)
                    {

                        clientList.Remove(client.getID());

                        clientList[client.getPartner().getID()].p_disConnect.Type = (int)PacketType.연결해제;
                        clientList[client.getPartner().getID()].p_disConnect.ID = id;
                        clientList[client.getPartner().getID()].setPartner(null);

                        Packet.Serialize(clientList[client.getPartner().getID()].p_disConnect).CopyTo(clientList[client.getPartner().getID()].sendBuffer, 0);

                        clientList[client.getPartner().getID()].Send();

                        clientList[client.getPartner().getID()].p_disConnect.clear();
                    }


                    clientList.Remove(id);
                    client.setID(null);
                    client.setPW(null);
                    client.setPartner(null);

                }

                counter--;
            }));
        }


        /*----------------------------------------------------------------------------------------------------------*/

        private bool isLoginOK(string id, string pw)
        {

            Encryption aes = new Encryption();
            string secretMessage = aes.AESEncrypt256(pw, this.loginKey);
            
            // DB 연동
            conn.Open();
            string sql = "SELECT * FROM client";

            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader table = command.ExecuteReader();

            // 고객 정보 가져오기
            while (table.Read())
            {
                // 아이디가 다른 경우
                if (!table["ID"].ToString().Equals(id))
                    continue;

                // 비밀번호가 다른 경우
                if (!table["Password"].ToString().Equals(secretMessage))
                    return false;

                conn.Close();
                return true;
            }

            conn.Close();
            return false;
            
        }




        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
        {
            txt_message.AppendText(msg + "\r\n");

            txt_message.Focus();
            txt_message.ScrollToCaret();

        }));
    }
        
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (m_bStop)
                return;

            t= new Thread(new ThreadStart(InitSocket));
            t.IsBackground = true;
            t.Start();
            
            btn_start.ForeColor = Color.Red;
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (m_bStop)
            {
                foreach (KeyValuePair<string, handleClient> a in clientList)
                    clientList[a.Key].Disconnect();

                server.Stop();
                t.Abort();
            }
        }
      
    }
}
