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

namespace Chatting_Client
{
    public partial class Select : Form
    {
        public Form1 home;

        private Point mousePoint;

        public Select()
        {
            InitializeComponent();
        }

        public void setList(string id)
        {
            list_login.Items.Add(id);
        }

        public void selectOK()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /*---------------------새로고침 버튼(리스트를 비우고, 서버에 다시 전송 신청)------------------------*/

        private void btn_newly_Click(object sender, EventArgs e)
        {
            
            list_login.Items.Clear();
            home.p_list.Type = (int)PacketType.목록요청;
            
            Packet.Serialize(home.p_list).CopyTo(home.sendBuffer, 0);

            home.Send();

            home.p_list.clear();
        }


        /*---------------------대화 신청(서버에 대화 신청 전송)------------------------*/

        private void btn_ask_Click(object sender, EventArgs e)
        {
            if(list_login.SelectedItem.ToString() == null)
            {
                MessageBox.Show("대화상대를 선택해주세요");
                list_login.Focus();
                return;
            }

            home.p_partner.Type = (int)PacketType.연결신청;
            home.p_partner.ID = list_login.SelectedItem.ToString();
            
            Packet.Serialize(home.p_partner).CopyTo(home.sendBuffer, 0);

            home.Send();
            
            home.p_list.clear();
        }


        /*---------------------최소화 및 종료------------------------*/


        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lbl_minimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Select_FormClosed(object sender, FormClosedEventArgs e)
        {
            list_login.Items.Clear();
        }

        /*--------------------------Mouse 관련 함수----------------------------------*/

        private void Select_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void Select_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        
    }
}
