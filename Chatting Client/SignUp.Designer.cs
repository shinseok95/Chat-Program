namespace Chatting_Client
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_minimum = new System.Windows.Forms.Label();
            this.pnl_background = new System.Windows.Forms.Panel();
            this.btn_IDCheck = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.lbl_pw = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.btn_signUp = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.pnl_background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.BackColor = System.Drawing.Color.White;
            this.lbl_close.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_close.ForeColor = System.Drawing.Color.Gray;
            this.lbl_close.Location = new System.Drawing.Point(444, 6);
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
            this.lbl_minimum.Location = new System.Drawing.Point(416, 5);
            this.lbl_minimum.Name = "lbl_minimum";
            this.lbl_minimum.Size = new System.Drawing.Size(22, 21);
            this.lbl_minimum.TabIndex = 2;
            this.lbl_minimum.Text = "_";
            this.lbl_minimum.Click += new System.EventHandler(this.lbl_minimum_Click);
            // 
            // pnl_background
            // 
            this.pnl_background.BackColor = System.Drawing.Color.White;
            this.pnl_background.Controls.Add(this.btn_IDCheck);
            this.pnl_background.Controls.Add(this.lbl_name);
            this.pnl_background.Controls.Add(this.txt_name);
            this.pnl_background.Controls.Add(this.lbl_phone);
            this.pnl_background.Controls.Add(this.txt_phone);
            this.pnl_background.Controls.Add(this.lbl_pw);
            this.pnl_background.Controls.Add(this.lbl_ID);
            this.pnl_background.Controls.Add(this.pictureBox1);
            this.pnl_background.Controls.Add(this.txt_ID);
            this.pnl_background.Controls.Add(this.lbl_close);
            this.pnl_background.Controls.Add(this.btn_signUp);
            this.pnl_background.Controls.Add(this.lbl_minimum);
            this.pnl_background.Controls.Add(this.txt_Password);
            this.pnl_background.Location = new System.Drawing.Point(3, 4);
            this.pnl_background.Name = "pnl_background";
            this.pnl_background.Size = new System.Drawing.Size(470, 442);
            this.pnl_background.TabIndex = 8;
            this.pnl_background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_background_MouseDown);
            this.pnl_background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_background_MouseMove);
            // 
            // btn_IDCheck
            // 
            this.btn_IDCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_IDCheck.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_IDCheck.FlatAppearance.BorderSize = 0;
            this.btn_IDCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_IDCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_IDCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IDCheck.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_IDCheck.ForeColor = System.Drawing.Color.White;
            this.btn_IDCheck.Location = new System.Drawing.Point(323, 264);
            this.btn_IDCheck.Name = "btn_IDCheck";
            this.btn_IDCheck.Size = new System.Drawing.Size(115, 22);
            this.btn_IDCheck.TabIndex = 14;
            this.btn_IDCheck.Text = "중복확인";
            this.btn_IDCheck.UseVisualStyleBackColor = false;
            this.btn_IDCheck.Click += new System.EventHandler(this.btn_IDCheck_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_name.Location = new System.Drawing.Point(55, 193);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(31, 14);
            this.lbl_name.TabIndex = 13;
            this.lbl_name.Text = "이름";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_name.Location = new System.Drawing.Point(131, 185);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(170, 22);
            this.txt_name.TabIndex = 12;
            this.txt_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyUp);
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_phone.Location = new System.Drawing.Point(55, 235);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(70, 14);
            this.lbl_phone.TabIndex = 11;
            this.lbl_phone.Text = "휴대폰 번호";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_phone.Location = new System.Drawing.Point(131, 227);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(170, 22);
            this.txt_phone.TabIndex = 10;
            this.txt_phone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyUp);
            // 
            // lbl_pw
            // 
            this.lbl_pw.AutoSize = true;
            this.lbl_pw.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_pw.Location = new System.Drawing.Point(55, 312);
            this.lbl_pw.Name = "lbl_pw";
            this.lbl_pw.Size = new System.Drawing.Size(28, 14);
            this.lbl_pw.TabIndex = 9;
            this.lbl_pw.Text = "PW";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ID.Location = new System.Drawing.Point(55, 273);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(20, 14);
            this.lbl_ID.TabIndex = 8;
            this.lbl_ID.Text = "ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(121, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // txt_ID
            // 
            this.txt_ID.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ID.Location = new System.Drawing.Point(131, 265);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(170, 22);
            this.txt_ID.TabIndex = 4;
            this.txt_ID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyUp);
            // 
            // btn_signUp
            // 
            this.btn_signUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_signUp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_signUp.FlatAppearance.BorderSize = 0;
            this.btn_signUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_signUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_signUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signUp.Font = new System.Drawing.Font("타이포_도담체 B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_signUp.ForeColor = System.Drawing.Color.White;
            this.btn_signUp.Location = new System.Drawing.Point(323, 366);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(115, 50);
            this.btn_signUp.TabIndex = 6;
            this.btn_signUp.Text = "회원가입";
            this.btn_signUp.UseVisualStyleBackColor = false;
            this.btn_signUp.Click += new System.EventHandler(this.btn_signUp_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Password.Location = new System.Drawing.Point(131, 304);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(170, 22);
            this.txt_Password.TabIndex = 5;
            this.txt_Password.UseSystemPasswordChar = true;
            this.txt_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyUp);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.pnl_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.pnl_background.ResumeLayout(false);
            this.pnl_background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_minimum;
        private System.Windows.Forms.Panel pnl_background;
        private System.Windows.Forms.Label lbl_pw;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Button btn_signUp;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_IDCheck;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.TextBox txt_phone;
    }
}