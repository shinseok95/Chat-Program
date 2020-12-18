namespace Chatting_Client
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_background = new System.Windows.Forms.Panel();
            this.btn_signUp = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_minimum = new System.Windows.Forms.Label();
            this.pnl_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_background
            // 
            this.pnl_background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_background.BackgroundImage")));
            this.pnl_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_background.Controls.Add(this.btn_signUp);
            this.pnl_background.Controls.Add(this.btn_login);
            this.pnl_background.Controls.Add(this.lbl_close);
            this.pnl_background.Controls.Add(this.lbl_minimum);
            this.pnl_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_background.Location = new System.Drawing.Point(0, 0);
            this.pnl_background.Name = "pnl_background";
            this.pnl_background.Size = new System.Drawing.Size(436, 718);
            this.pnl_background.TabIndex = 0;
            this.pnl_background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_background_MouseDown);
            this.pnl_background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_background_MouseMove);
            // 
            // btn_signUp
            // 
            this.btn_signUp.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_signUp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_signUp.FlatAppearance.BorderSize = 0;
            this.btn_signUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_signUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_signUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signUp.Font = new System.Drawing.Font("타이포_도담체 B", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_signUp.ForeColor = System.Drawing.Color.White;
            this.btn_signUp.Location = new System.Drawing.Point(12, 684);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(79, 22);
            this.btn_signUp.TabIndex = 3;
            this.btn_signUp.Text = "Sign Up";
            this.btn_signUp.UseVisualStyleBackColor = false;
            this.btn_signUp.Click += new System.EventHandler(this.btn_signUp_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btn_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("타이포_도담체 B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(117, 510);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(194, 39);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.BackColor = System.Drawing.Color.White;
            this.lbl_close.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_close.ForeColor = System.Drawing.Color.Gray;
            this.lbl_close.Location = new System.Drawing.Point(409, 6);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(23, 19);
            this.lbl_close.TabIndex = 1;
            this.lbl_close.Text = "X";
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_minimum
            // 
            this.lbl_minimum.AutoSize = true;
            this.lbl_minimum.BackColor = System.Drawing.Color.White;
            this.lbl_minimum.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_minimum.ForeColor = System.Drawing.Color.Gray;
            this.lbl_minimum.Location = new System.Drawing.Point(381, 5);
            this.lbl_minimum.Name = "lbl_minimum";
            this.lbl_minimum.Size = new System.Drawing.Size(22, 21);
            this.lbl_minimum.TabIndex = 0;
            this.lbl_minimum.Text = "_";
            this.lbl_minimum.Click += new System.EventHandler(this.lbl_minimum_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(436, 718);
            this.Controls.Add(this.pnl_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "FlyTalk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.pnl_background.ResumeLayout(false);
            this.pnl_background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_background;
        private System.Windows.Forms.Label lbl_minimum;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_signUp;
    }
}

