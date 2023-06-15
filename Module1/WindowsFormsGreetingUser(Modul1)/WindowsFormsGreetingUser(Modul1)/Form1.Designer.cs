namespace WindowsFormsGreetingUser_Modul1_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblEnterName = new System.Windows.Forms.Label();
            this.btnShowGreeting = new System.Windows.Forms.Button();
            this.lblUserGreeting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleDescription = "";
            this.txtUserName.Location = new System.Drawing.Point(32, 86);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 42);
            this.txtUserName.TabIndex = 0;
            // 
            // lblEnterName
            // 
            this.lblEnterName.Location = new System.Drawing.Point(29, 67);
            this.lblEnterName.Name = "lblEnterName";
            this.lblEnterName.Size = new System.Drawing.Size(126, 16);
            this.lblEnterName.TabIndex = 1;
            this.lblEnterName.Text = "Enter your name";
            // 
            // btnShowGreeting
            // 
            this.btnShowGreeting.Location = new System.Drawing.Point(246, 86);
            this.btnShowGreeting.Name = "btnShowGreeting";
            this.btnShowGreeting.Size = new System.Drawing.Size(98, 42);
            this.btnShowGreeting.TabIndex = 2;
            this.btnShowGreeting.Text = "Show greeting";
            this.btnShowGreeting.UseVisualStyleBackColor = true;
            this.btnShowGreeting.Click += new System.EventHandler(this.btnShowGreeting_Click);
            // 
            // lblUserGreeting
            // 
            this.lblUserGreeting.AllowDrop = true;
            this.lblUserGreeting.AutoSize = true;
            this.lblUserGreeting.Location = new System.Drawing.Point(418, 89);
            this.lblUserGreeting.Name = "lblUserGreeting";
            this.lblUserGreeting.Size = new System.Drawing.Size(0, 16);
            this.lblUserGreeting.TabIndex = 3;
            this.lblUserGreeting.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 457);
            this.Controls.Add(this.lblUserGreeting);
            this.Controls.Add(this.btnShowGreeting);
            this.Controls.Add(this.lblEnterName);
            this.Controls.Add(this.txtUserName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblEnterName;
        private System.Windows.Forms.Button btnShowGreeting;
        private System.Windows.Forms.Label lblUserGreeting;
    }
}

