namespace WindowsFormsModule3
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
            this.components = new System.ComponentModel.Container();
            this.txtSourceDolder = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnShowFiels = new System.Windows.Forms.Button();
            this.txtFilterByFilesFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.buttonPredicate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSourceDolder
            // 
            this.txtSourceDolder.Location = new System.Drawing.Point(30, 39);
            this.txtSourceDolder.Name = "txtSourceDolder";
            this.txtSourceDolder.Size = new System.Drawing.Size(638, 22);
            this.txtSourceDolder.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(30, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(638, 415);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // btnShowFiels
            // 
            this.btnShowFiels.Location = new System.Drawing.Point(694, 37);
            this.btnShowFiels.Name = "btnShowFiels";
            this.btnShowFiels.Size = new System.Drawing.Size(75, 23);
            this.btnShowFiels.TabIndex = 3;
            this.btnShowFiels.Text = "Show";
            this.btnShowFiels.UseVisualStyleBackColor = true;
            this.btnShowFiels.Click += new System.EventHandler(this.btnShowFiels_Click);
            // 
            // txtFilterByFilesFolder
            // 
            this.txtFilterByFilesFolder.Location = new System.Drawing.Point(694, 98);
            this.txtFilterByFilesFolder.Name = "txtFilterByFilesFolder";
            this.txtFilterByFilesFolder.Size = new System.Drawing.Size(267, 22);
            this.txtFilterByFilesFolder.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the path to the folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search by folders/files";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(967, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 34);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPredicate
            // 
            this.buttonPredicate.Location = new System.Drawing.Point(940, 155);
            this.buttonPredicate.Name = "buttonPredicate";
            this.buttonPredicate.Size = new System.Drawing.Size(113, 44);
            this.buttonPredicate.TabIndex = 8;
            this.buttonPredicate.Text = "btn to check Predicate";
            this.buttonPredicate.UseVisualStyleBackColor = true;
            this.buttonPredicate.Click += new System.EventHandler(this.buttonPredicate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 513);
            this.Controls.Add(this.buttonPredicate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilterByFilesFolder);
            this.Controls.Add(this.btnShowFiels);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtSourceDolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceDolder;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnShowFiels;
        private System.Windows.Forms.TextBox txtFilterByFilesFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button buttonPredicate;
    }
}

