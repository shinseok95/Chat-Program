using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting_Client
{
    public partial class Login : Form
    {
        public Form1 home;
        private Point mousePoint;

        public Login()
        {
            InitializeComponent();
        }
        
        /*---------------------로그인------------------------*/

        private void btn_login_Click(object sender, EventArgs e)
        {

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
                home.ID = txt_ID.Text;
                home.PW = txt_Password.Text;

                this.DialogResult = DialogResult.OK;
            
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

        /*--------------------------Mouse 관련 함수----------------------------------*/
        
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
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
                this.btn_login_Click(sender, e);
            }
        }
    }
}
