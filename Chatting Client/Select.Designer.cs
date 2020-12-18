namespace Chatting_Client
{
    partial class Select
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Select));
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_minimum = new System.Windows.Forms.Label();
            this.list_login = new System.Windows.Forms.ListBox();
            this.pic_man = new System.Windows.Forms.PictureBox();
            this.pnl_background = new System.Windows.Forms.Panel();
            this.btn_ask = new System.Windows.Forms.Button();
            this.btn_newly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_man)).BeginInit();
            this.pnl_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.BackColor = System.Drawing.Color.White;
            this.lbl_close.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_close.ForeColor = System.Drawing.Color.Gray;
            this.lbl_close.Location = new System.Drawing.Point(300, 4);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(23, 19);
            this.lbl_close.TabIndex = 3;
            this.lbl_close.Text = "X";
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_minimum
            // 
            this.lbl_minimum.AutoSize = true;
            this.lbl_minimum.BackColor = System.Drawing.Color.White;
            this.lbl_minimum.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_minimum.ForeColor = System.Drawing.Color.Gray;
            this.lbl_minimum.Location = new System.Drawing.Point(272, 3);
            this.lbl_minimum.Name = "lbl_minimum";
            this.lbl_minimum.Size = new System.Drawing.Size(22, 21);
            this.lbl_minimum.TabIndex = 2;
            this.lbl_minimum.Text = "_";
            this.lbl_minimum.Click += new System.EventHandler(this.lbl_minimum_Click);
            // 
            // list_login
            // 
            this.list_login.Font = new System.Drawing.Font("THE정고딕140", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.list_login.FormattingEnabled = true;
            this.list_login.ItemHeight = 15;
            this.list_login.Location = new System.Drawing.Point(70, 137);
            this.list_login.Name = "list_login";
            this.list_login.Size = new System.Drawing.Size(191, 244);
            this.list_login.TabIndex = 4;
            // 
            // pic_man
            // 
            this.pic_man.Image = ((System.Drawing.Image)(resources.GetObject("pic_man.Image")));
            this.pic_man.Location = new System.Drawing.Point(70, 36);
            this.pic_man.Name = "pic_man";
            this.pic_man.Size = new System.Drawing.Size(191, 95);
            this.pic_man.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_man.TabIndex = 5;
            this.pic_man.TabStop = false;
            // 
            // pnl_background
            // 
            this.pnl_background.BackColor = System.Drawing.Color.White;
            this.pnl_background.Controls.Add(this.btn_ask);
            this.pnl_background.Controls.Add(this.btn_newly);
            this.pnl_background.Controls.Add(this.pic_man);
            this.pnl_background.Controls.Add(this.lbl_minimum);
            this.pnl_background.Controls.Add(this.list_login);
            this.pnl_background.Controls.Add(this.lbl_close);
            this.pnl_background.Location = new System.Drawing.Point(12, 12);
            this.pnl_background.Name = "pnl_background";
            this.pnl_background.Size = new System.Drawing.Size(325, 454);
            this.pnl_background.TabIndex = 6;
            this.pnl_background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Select_MouseDown);
            this.pnl_background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Select_MouseMove);
            // 
            // btn_ask
            // 
            this.btn_ask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_ask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ask.FlatAppearance.BorderSize = 0;
            this.btn_ask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_ask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_ask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ask.Font = new System.Drawing.Font("THE정고딕140", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ask.ForeColor = System.Drawing.Color.White;
            this.btn_ask.Location = new System.Drawing.Point(175, 387);
            this.btn_ask.Name = "btn_ask";
            this.btn_ask.Size = new System.Drawing.Size(86, 29);
            this.btn_ask.TabIndex = 9;
            this.btn_ask.Text = "대화신청";
            this.btn_ask.UseVisualStyleBackColor = false;
            this.btn_ask.Click += new System.EventHandler(this.btn_ask_Click);
            // 
            // btn_newly
            // 
            this.btn_newly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_newly.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_newly.FlatAppearance.BorderSize = 0;
            this.btn_newly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_newly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_newly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newly.Font = new System.Drawing.Font("THE정고딕140", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_newly.ForeColor = System.Drawing.Color.White;
            this.btn_newly.Location = new System.Drawing.Point(70, 387);
            this.btn_newly.Name = "btn_newly";
            this.btn_newly.Size = new System.Drawing.Size(86, 29);
            this.btn_newly.TabIndex = 8;
            this.btn_newly.Text = "새로고침";
            this.btn_newly.UseVisualStyleBackColor = false;
            this.btn_newly.Click += new System.EventHandler(this.btn_newly_Click);
            // 
            // Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(349, 478);
            this.Controls.Add(this.pnl_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Select";
            this.Text = "Select";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Select_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Select_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Select_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pic_man)).EndInit();
            this.pnl_background.ResumeLayout(false);
            this.pnl_background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_minimum;
        private System.Windows.Forms.PictureBox pic_man;
        private System.Windows.Forms.Panel pnl_background;
        private System.Windows.Forms.Button btn_ask;
        private System.Windows.Forms.Button btn_newly;
        public System.Windows.Forms.ListBox list_login;
    }
}