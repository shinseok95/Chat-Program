using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using packet;
using System.IO;
using ClientEncryption;

namespace Chatting_Client
{
    public partial class Chatting : Form
    {
        public Form1 home;
        private Point mousePoint;
        

        public Chatting()
        {
            InitializeComponent();
            
            chatBox.outMessage += new BubbleChat.chatbox.outMessageHandler(sendMessage);

        }

        public void inImage(Bitmap bm, string time)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                chatBox.addInImage(bm,time);
            }));
        }
        

        public void inMessage(string message, string time)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                chatBox.addInMessage(message, time);
            }));
        }

        public void sendMessage(string message, string time)
        {
            // 메시지 암호화

            Encryption aes = new Encryption();

            string secretMessage = aes.AESEncrypt256(message, home.getKey());
            
            // 메시지 전송

            home.p_message.Type = (int)PacketType.발신;
            home.p_message.message = secretMessage;
            home.p_message.time = time;

            Packet.Serialize(home.p_message).CopyTo(home.sendBuffer, 0);
            
            home.Send();
            
            home.p_message.clear();
        }

        /*-----------------------버튼 클릭------------------------------------*/

        private void pic_image_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.AutoUpgradeEnabled = false;
            openDialog.Multiselect = false;
            openDialog.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            openDialog.InitialDirectory = "C:\\";

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openDialog.FileName);

                    // image draw
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        // image draw
                        chatBox.addOutImage(image, DateTime.Now.ToString("tt:hh:mm"));
                    }));


               // send image
                Bitmap bitmap = new Bitmap(image);
                MemoryStream ms = new MemoryStream();

                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                byte[] data = ms.ToArray();


                // 이미지 크기 및 시간 전송
                home.p_imageData.Type = (int)PacketType.이미지발신;
                //data.CopyTo(home.p_imageData.imgData, 0);
                home.p_imageData.time = DateTime.Now.ToString("tt:hh:mm");
                home.p_imageData.size = (int)data.Length;

                Packet.Serialize(home.p_imageData).CopyTo(home.sendBuffer, 0);

                home.Send();

                // 이미지 전송
                home.m_Stream.Write(data, 0, data.Length);
                home.m_Stream.Flush();

                home.p_imageData.clear();
                
             }
            
        }

        private void pic_out_Click(object sender, EventArgs e)
        {
            chatBox.panelClear();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /*--------------------------최소화, 닫기-------------------------------*/

        public void setPartner()
        {
            this.lbl_partnerName.Text = home.partner_ID;
        }

        /*--------------------------최소화, 닫기-------------------------------*/

        private void lbl_minimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            chatBox.panelClear();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        /*--------------------------Mouse 관련 함수----------------------------------*/

        private void Chatting_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        
        private void Chatting_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        
    }
}
