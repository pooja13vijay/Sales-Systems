namespace BA_SalesSystems
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.passwordShowText = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginText = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordShowText
            // 
            this.passwordShowText.AutoSize = true;
            this.passwordShowText.BackColor = System.Drawing.Color.Transparent;
            this.passwordShowText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordShowText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.passwordShowText.Location = new System.Drawing.Point(253, 327);
            this.passwordShowText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordShowText.Name = "passwordShowText";
            this.passwordShowText.Size = new System.Drawing.Size(147, 24);
            this.passwordShowText.TabIndex = 13;
            this.passwordShowText.Text = "show password";
            this.passwordShowText.UseVisualStyleBackColor = false;
            this.passwordShowText.CheckedChanged += new System.EventHandler(this.passwordShowText_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(172, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enter Username and Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.BackColor = System.Drawing.Color.Transparent;
            this.LoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginText.ForeColor = System.Drawing.Color.White;
            this.LoginText.Location = new System.Drawing.Point(256, 131);
            this.LoginText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(134, 52);
            this.LoginText.TabIndex = 11;
            this.LoginText.Text = "Login";
            this.LoginText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Password.Location = new System.Drawing.Point(221, 293);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(203, 26);
            this.Password.TabIndex = 10;
            this.Password.Text = "Password";
            this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserName.Location = new System.Drawing.Point(221, 260);
            this.UserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(203, 26);
            this.UserName.TabIndex = 9;
            this.UserName.Text = "Username";
            this.UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(185, 370);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(323, 370);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 44);
            this.button2.TabIndex = 15;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 59);
            this.label1.TabIndex = 16;
            this.label1.Text = "APPAREL && CO.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(639, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordShowText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Sales";
            this.Text = "Apparel & Garment";
            this.Load += new System.EventHandler(this.Sales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox passwordShowText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

