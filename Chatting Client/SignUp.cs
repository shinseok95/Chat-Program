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
    public partial class SignUp : Form
    {

        private Point mousePoint;

        public Form1 home;
        private bool idCheck = false;
        private string checkedId = null;

        public SignUp()
        {
            InitializeComponent();
            txt_name.Focus();

        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Equals(""))
            {

                MessageBox.Show("이름을 입력하세요");
                txt_name.Focus();
                return;
            }
            if (txt_phone.Text.Equals(""))
            {

                MessageBox.Show("휴대폰 번호를 입력하세요");
                txt_phone.Focus();
                return;
            }

            if (txt_ID.Text.Equals(""))
            {

                MessageBox.Show("ID를 입력하세요");
                txt_ID.Focus();
                return;
            }

            if (txt_Password.Text.Equals(""))
            {
                MessageBox.Show("Password를 입력하세요");
                txt_Password.Focus();
                return;
            }

            if (!idCheck && !txt_ID.Text.Equals(checkedId))
            {
                MessageBox.Show("ID 중복확인을 해주세요");
                txt_ID.Focus();
                return;
            }
            

            home.p_signUp.Type = (int)PacketType.가입신청;
            home.p_signUp.ID = txt_ID.Text;
            home.p_signUp.PW = txt_Password.Text;
            home.p_signUp.name = txt_name.Text;
            home.p_signUp.phone = txt_phone.Text;

            Packet.Serialize(home.p_signUp).CopyTo(home.sendBuffer, 0);

            home.Send();

            home.p_signUp.clear();

        }

        public void signUpOK()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_IDCheck_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text.Equals(""))
            {
                MessageBox.Show("ID를 입력하세요");
                txt_ID.Focus();
                return;
            }
            

            home.p_signUpAnswer.Type = (int)PacketType.중복확인;
            home.p_signUpAnswer.ID = txt_ID.Text;
            Packet.Serialize(home.p_signUpAnswer).CopyTo(home.sendBuffer, 0);
            
            home.Send();
            
        }

        public void setIdCheck(string id)
        {
            idCheck = true;
            this.checkedId = id;
        }

        public void clearSignUp()
        {
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_ID.Text = "";
            txt_Password.Text = "";

            idCheck = false;
            checkedId = null;

        }

        private void lbl_minimum_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {

            clearSignUp();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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

        private void txt_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_signUp_Click(sender, e);
            }
        }
    }
}
