namespace BubbleChat
{
    partial class chatbox
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatbox));
            this.pnl_msg = new System.Windows.Forms.Panel();
            this.bottom = new System.Windows.Forms.PictureBox();
            this.bubble1 = new Chatting_Client.bubble();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pic_button = new System.Windows.Forms.PictureBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.pnl_msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottom)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_button)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_msg
            // 
            this.pnl_msg.AutoScroll = true;
            this.pnl_msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(233)))), ((int)(((byte)(249)))));
            this.pnl_msg.Controls.Add(this.bottom);
            this.pnl_msg.Controls.Add(this.bubble1);
            this.pnl_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_msg.Location = new System.Drawing.Point(0, 0);
            this.pnl_msg.Name = "pnl_msg";
            this.pnl_msg.Size = new System.Drawing.Size(430, 557);
            this.pnl_msg.TabIndex = 1;
            // 
            // bottom
            // 
            this.bottom.Location = new System.Drawing.Point(0, 513);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(100, 38);
            this.bottom.TabIndex = 1;
            this.bottom.TabStop = false;
            // 
            // bubble1
            // 
            this.bubble1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubble1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(147)))));
            this.bubble1.Location = new System.Drawing.Point(17, 13);
            this.bubble1.Name = "bubble1";
            this.bubble1.Size = new System.Drawing.Size(244, 41);
            this.bubble1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txt_msg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 557);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 72);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(137)))), ((int)(((byte)(220)))));
            this.panel2.Controls.Add(this.pic_button);
            this.panel2.Location = new System.Drawing.Point(348, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 72);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.pic_button_Click);
            // 
            // pic_button
            // 
            this.pic_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(137)))), ((int)(((byte)(220)))));
            this.pic_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_button.Image = ((System.Drawing.Image)(resources.GetObject("pic_button.Image")));
            this.pic_button.Location = new System.Drawing.Point(17, 14);
            this.pic_button.Name = "pic_button";
            this.pic_button.Size = new System.Drawing.Size(54, 46);
            this.pic_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_button.TabIndex = 1;
            this.pic_button.TabStop = false;
            this.pic_button.Click += new System.EventHandler(this.pic_button_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_msg.Font = new System.Drawing.Font("THE정고딕140", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_msg.Location = new System.Drawing.Point(0, 0);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(351, 72);
            this.txt_msg.TabIndex = 0;
            this.txt_msg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyUp);
            // 
            // chatbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_msg);
            this.Controls.Add(this.panel1);
            this.Name = "chatbox";
            this.Size = new System.Drawing.Size(430, 629);
            this.pnl_msg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_msg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pic_button;
        private System.Windows.Forms.PictureBox bottom;
        private Chatting_Client.bubble bubble1;
    }
}
