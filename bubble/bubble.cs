using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting_Client
{
    public partial class bubble : UserControl
    {
        public enum MsgType
        {
            In,
            Out
        }
        
        public bubble()
        {
            InitializeComponent();
        }

        public bubble(string message, string time, MsgType messageType)
        {
            InitializeComponent();
            lbl_msg.Text = message;
            lbl_time.Text = time;

            if (messageType.ToString().Equals("In"))
            {
                // partner message
                this.BackColor = Color.FromArgb(0, 164, 147);
            }
            else
            {
                // my message
                this.BackColor = Color.Gray;
            }
        }

        void setHeight(Label _label)
        {
            Size maxSize = new Size(495, int.MaxValue);
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(_label.Text, _label.Font, _label.Width);

            _label.Height = int.Parse(Math.Round(size.Height + 2, 0).ToString());

            this.Height = lbl_msg.Height + lbl_msg.Top;
        }
    }
}
