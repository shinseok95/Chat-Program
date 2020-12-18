using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Chatting_Client;

namespace BubbleChat
{
    public partial class chatbox: UserControl
    {

        public chatbox()
        {
            if (!this.DesignMode)
            {
                InitializeComponent();

            }
        }

        // 채팅창과 연동 (메시지 입력)
        public delegate void outMessageHandler(string msg, string time);
        public event outMessageHandler outMessage;

        /*------------------Message 추가----------------------*/

        bool isPrevImage = false;
        Chatting_Client.bubble bbl_old = new Chatting_Client.bubble();
        PictureBox pic_old = new PictureBox();

        public void addInMessage(string message, string time)
        {
            Chatting_Client.bubble bbl = new Chatting_Client.bubble(message,Chatting_Client.MsgType.In);
            
            bbl.Location = bubble1.Location;
            bbl.Size = bubble1.Size;
            bbl.Anchor = bubble1.Anchor;

            if (isPrevImage)
                bbl.Top = pic_old.Bottom + 20;
            else
                bbl.Top = bbl_old.Bottom + 20;

            pnl_msg.Controls.Add(bbl);

            bottom.Top = bbl.Bottom + 30;

            Label lbl_time = new Label();
            lbl_time.Font = new Font("THE정고딕140", 8);
            lbl_time.ForeColor = Color.Black;
            lbl_time.Text = time;
            
            lbl_time.Left = bbl.Right + 2;
            lbl_time.Top = bbl.Bottom - 14;
            pnl_msg.Controls.Add(lbl_time);

            pnl_msg.VerticalScroll.Value = pnl_msg.VerticalScroll.Maximum;


            isPrevImage = false;
            bbl_old = bbl;
        }

        public void addOutMessage(string message, string time)
        {

            Chatting_Client.bubble bbl = new Chatting_Client.bubble(message, Chatting_Client.MsgType.Out);
            bbl.Location = bubble1.Location;
            bbl.Left += 143;
            bbl.Size = bubble1.Size;
            bbl.Anchor = bubble1.Anchor;

            if (isPrevImage)
                bbl.Top = pic_old.Bottom + 20;
            else
                bbl.Top = bbl_old.Bottom + 20;
            
            pnl_msg.Controls.Add(bbl);

            bottom.Top = bbl.Bottom + 30;

            Label lbl_time = new Label();
            lbl_time.Font = new Font("THE정고딕140", 8);
            lbl_time.ForeColor = Color.Black;
            lbl_time.Text = time;
           
            lbl_time.Left = bbl.Left -57;
            lbl_time.Top = bbl.Bottom-14;
            pnl_msg.Controls.Add(lbl_time);


            isPrevImage = false;
            bbl_old = bbl;
        }

        /*------------------Message 추가----------------------*/

        public void addInImage(Bitmap image, string time)
        {

            PictureBox pic_image = new PictureBox();

            pic_image.Image = (Image)image;
            pic_image.SizeMode = PictureBoxSizeMode.Zoom;
            pic_image.Size = new Size(179, 179);
            pic_image.Location = bubble1.Location;
            pic_image.Anchor = bubble1.Anchor;

            if (isPrevImage)
                pic_image.Top = pic_old.Bottom + 20;
            else
                pic_image.Top = bbl_old.Bottom + 20;

            pnl_msg.Controls.Add(pic_image);
            
            bottom.Top = pic_image.Bottom + 30;

            Label lbl_time = new Label();
            lbl_time.Font = new Font("THE정고딕140", 8);
            lbl_time.ForeColor = Color.Black;
            lbl_time.Text = time;

            lbl_time.Left = pic_image.Right + 2;
            lbl_time.Top = pic_image.Bottom - 14;
            pnl_msg.Controls.Add(lbl_time);


            pnl_msg.VerticalScroll.Value = pnl_msg.VerticalScroll.Maximum;

            isPrevImage = true;
            pic_old = pic_image;
            
        }

        public void addOutImage(Image image, string time)
        {
            PictureBox pic_image = new PictureBox();

            pic_image.Image = image;
            pic_image.SizeMode = PictureBoxSizeMode.Zoom;
            pic_image.Size = new Size(179, 179);
            pic_image.Location = bubble1.Location;
            pic_image.Anchor = bubble1.Anchor;
            pic_image.Left += 200;
            
            if (isPrevImage)
                pic_image.Top = pic_old.Bottom + 20;
            else
                pic_image.Top = bbl_old.Bottom + 20;

            pnl_msg.Controls.Add(pic_image);
            
           bottom.Top = pic_image.Bottom + 30;

            Label lbl_time = new Label();
            lbl_time.Font = new Font("THE정고딕140", 8);
            lbl_time.ForeColor = Color.Black;
            lbl_time.Text = time;

            lbl_time.Left = pic_image.Left - 57;
            lbl_time.Top = pic_image.Bottom - 14;
            pnl_msg.Controls.Add(lbl_time);
            
            isPrevImage = true;
            pic_old = pic_image;

        }

        public void panelClear()
        {
            this.txt_msg.Text = "";
            this.pnl_msg.Controls.Clear();
        }

        private void pic_button_Click(object sender, EventArgs e)
        {
            if (!txt_msg.Text.Equals(""))
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    outMessage(txt_msg.Text, DateTime.Now.ToString("tt:hh:mm"));
                    addOutMessage(txt_msg.Text, DateTime.Now.ToString("tt:hh:mm"));
                    txt_msg.Text = "";
                }));
            }

            pnl_msg.VerticalScroll.Value = pnl_msg.VerticalScroll.Maximum;
        }

        private void txt_msg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.pic_button_Click(sender, e);
            }
            
        }
        
    }
}
