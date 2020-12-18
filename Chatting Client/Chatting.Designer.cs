namespace Chatting_Client
{
    partial class Chatting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chatting));
            this.chatBox = new BubbleChat.chatbox();
            this.pic_out = new System.Windows.Forms.PictureBox();
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_minimum = new System.Windows.Forms.Label();
            this.lbl_partnerName = new System.Windows.Forms.Label();
            this.pic_image = new System.Windows.Forms.PictureBox();
            this.pic_lock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_out)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_lock)).BeginInit();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(-1, 33);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(426, 624);
            this.chatBox.TabIndex = 0;
            // 
            // pic_out
            // 
            this.pic_out.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_out.Image = ((System.Drawing.Image)(resources.GetObject("pic_out.Image")));
            this.pic_out.Location = new System.Drawing.Point(47, 657);
            this.pic_out.Name = "pic_out";
            this.pic_out.Size = new System.Drawing.Size(45, 37);
            this.pic_out.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_out.TabIndex = 1;
            this.pic_out.TabStop = false;
            this.pic_out.Click += new System.EventHandler(this.pic_out_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(233)))), ((int)(((byte)(249)))));
            this.lbl_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_close.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_close.ForeColor = System.Drawing.Color.Gray;
            this.lbl_close.Location = new System.Drawing.Point(398, 6);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(23, 19);
            this.lbl_close.TabIndex = 3;
            this.lbl_close.Text = "X";
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_minimum
            // 
            this.lbl_minimum.AutoSize = true;
            this.lbl_minimum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_minimum.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_minimum.ForeColor = System.Drawing.Color.Gray;
            this.lbl_minimum.Location = new System.Drawing.Point(370, 5);
            this.lbl_minimum.Name = "lbl_minimum";
            this.lbl_minimum.Size = new System.Drawing.Size(22, 21);
            this.lbl_minimum.TabIndex = 2;
            this.lbl_minimum.Text = "_";
            this.lbl_minimum.Click += new System.EventHandler(this.lbl_minimum_Click);
            // 
            // lbl_partnerName
            // 
            this.lbl_partnerName.AutoSize = true;
            this.lbl_partnerName.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_partnerName.Location = new System.Drawing.Point(47, 14);
            this.lbl_partnerName.Name = "lbl_partnerName";
            this.lbl_partnerName.Size = new System.Drawing.Size(58, 16);
            this.lbl_partnerName.TabIndex = 4;
            this.lbl_partnerName.Text = "label1";
            // 
            // pic_image
            // 
            this.pic_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_image.Image = ((System.Drawing.Image)(resources.GetObject("pic_image.Image")));
            this.pic_image.Location = new System.Drawing.Point(-1, 657);
            this.pic_image.Name = "pic_image";
            this.pic_image.Size = new System.Drawing.Size(42, 36);
            this.pic_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_image.TabIndex = 5;
            this.pic_image.TabStop = false;
            this.pic_image.Click += new System.EventHandler(this.pic_image_Click);
            // 
            // pic_lock
            // 
            this.pic_lock.Image = ((System.Drawing.Image)(resources.GetObject("pic_lock.Image")));
            this.pic_lock.Location = new System.Drawing.Point(-1, 5);
            this.pic_lock.Name = "pic_lock";
            this.pic_lock.Size = new System.Drawing.Size(42, 30);
            this.pic_lock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_lock.TabIndex = 6;
            this.pic_lock.TabStop = false;
            // 
            // Chatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(233)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(424, 691);
            this.Controls.Add(this.pic_lock);
            this.Controls.Add(this.pic_image);
            this.Controls.Add(this.lbl_partnerName);
            this.Controls.Add(this.lbl_close);
            this.Controls.Add(this.lbl_minimum);
            this.Controls.Add(this.pic_out);
            this.Controls.Add(this.chatBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chatting";
            this.Text = "Chatting";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chatting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chatting_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pic_out)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_lock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BubbleChat.chatbox chatBox;
        private System.Windows.Forms.PictureBox pic_out;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_minimum;
        private System.Windows.Forms.Label lbl_partnerName;
        private System.Windows.Forms.PictureBox pic_image;
        private System.Windows.Forms.PictureBox pic_lock;
    }
}