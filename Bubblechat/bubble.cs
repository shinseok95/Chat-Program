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

namespace Chatting_Client
{
    public partial class bubble : UserControl
    {
       

        public bubble()
        {
            InitializeComponent();
            
        }
        #region
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]  
        private static extern IntPtr CreateRoundRectRgn                     
      (
          int nLeftRect,      // x-coordinate of upper-left corner
          int nTopRect,       // y-coordinate of upper-left corner
          int nRightRect,     // x-coordinate of lower-right corner
          int nBottomRect,    // y-coordinate of lower-right corner   
          int nWidthEllipse,  // height of ellipse
          int nHeightEllipse  // width of ellipse  

      );
         #endregion

        public bubble(string message, MsgType messageType)
        {
            InitializeComponent();
            lbl_msg.Text = message;

            if (messageType==MsgType.In)
            {
                // partner message
                this.BackColor = Color.Gray;

                lbl_msg.TextAlign = ContentAlignment.MiddleLeft;

            }
            else
            {
                // my message
                this.BackColor = Color.FromArgb(0, 164, 147); 
                lbl_msg.TextAlign = ContentAlignment.MiddleRight;
            }

            setHeight();
        }

        void setHeight()
        {
            Size maxSize = new Size(495, int.MaxValue);
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(lbl_msg.Text, lbl_msg.Font, lbl_msg.Width);

            lbl_msg.Height = int.Parse(Math.Round(size.Height + 2, 0).ToString());
            this.Height = lbl_msg.Bottom + 10;
        }

        private void bubble_Resize(object sender, EventArgs e)
        {

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 35, 35));
            setHeight();
        }
    }
    public enum MsgType
    {
        In,
        Out
    }

}
