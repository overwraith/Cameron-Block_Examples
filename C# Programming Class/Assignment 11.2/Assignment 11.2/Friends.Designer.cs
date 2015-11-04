namespace Assignment_11._2 {
    partial class Friends {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Entry = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEnterFriend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.maskPhoneNum = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBirthDay = new System.Windows.Forms.TextBox();
            this.txtBirthMonth = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Read = new System.Windows.Forms.TabPage();
            this.listRead = new System.Windows.Forms.ListBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.Reminder = new System.Windows.Forms.TabPage();
            this.listReminder = new System.Windows.Forms.ListBox();
            this.btnReminder = new System.Windows.Forms.Button();
            this.btnExit3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBirthMonth2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Entry.SuspendLayout();
            this.Read.SuspendLayout();
            this.Reminder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Entry);
            this.tabControl1.Controls.Add(this.Read);
            this.tabControl1.Controls.Add(this.Reminder);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 240);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Entry
            // 
            this.Entry.Controls.Add(this.btnExit);
            this.Entry.Controls.Add(this.btnEnterFriend);
            this.Entry.Controls.Add(this.label5);
            this.Entry.Controls.Add(this.maskPhoneNum);
            this.Entry.Controls.Add(this.label4);
            this.Entry.Controls.Add(this.label3);
            this.Entry.Controls.Add(this.label2);
            this.Entry.Controls.Add(this.label1);
            this.Entry.Controls.Add(this.txtBirthDay);
            this.Entry.Controls.Add(this.txtBirthMonth);
            this.Entry.Controls.Add(this.txtLastName);
            this.Entry.Controls.Add(this.txtFirstName);
            this.Entry.Location = new System.Drawing.Point(4, 22);
            this.Entry.Name = "Entry";
            this.Entry.Padding = new System.Windows.Forms.Padding(3);
            this.Entry.Size = new System.Drawing.Size(252, 214);
            this.Entry.TabIndex = 0;
            this.Entry.Text = "Entry";
            this.Entry.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(119, 175);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 33);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEnterFriend
            // 
            this.btnEnterFriend.Location = new System.Drawing.Point(20, 175);
            this.btnEnterFriend.Name = "btnEnterFriend";
            this.btnEnterFriend.Size = new System.Drawing.Size(93, 33);
            this.btnEnterFriend.TabIndex = 10;
            this.btnEnterFriend.Text = "Enter Friend";
            this.btnEnterFriend.UseVisualStyleBackColor = true;
            this.btnEnterFriend.Click += new System.EventHandler(this.btnEnterFriend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phone Number: ";
            // 
            // maskPhoneNum
            // 
            this.maskPhoneNum.Location = new System.Drawing.Point(124, 119);
            this.maskPhoneNum.Mask = "999-9999";
            this.maskPhoneNum.Name = "maskPhoneNum";
            this.maskPhoneNum.Size = new System.Drawing.Size(100, 20);
            this.maskPhoneNum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Birth Day: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Birth Month: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "First Name: ";
            // 
            // txtBirthDay
            // 
            this.txtBirthDay.Location = new System.Drawing.Point(124, 92);
            this.txtBirthDay.MaxLength = 2;
            this.txtBirthDay.Name = "txtBirthDay";
            this.txtBirthDay.Size = new System.Drawing.Size(100, 20);
            this.txtBirthDay.TabIndex = 3;
            // 
            // txtBirthMonth
            // 
            this.txtBirthMonth.Location = new System.Drawing.Point(124, 65);
            this.txtBirthMonth.MaxLength = 2;
            this.txtBirthMonth.Name = "txtBirthMonth";
            this.txtBirthMonth.Size = new System.Drawing.Size(100, 20);
            this.txtBirthMonth.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(124, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(124, 11);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // Read
            // 
            this.Read.Controls.Add(this.listRead);
            this.Read.Controls.Add(this.btnExit2);
            this.Read.Controls.Add(this.btnRead);
            this.Read.Location = new System.Drawing.Point(4, 22);
            this.Read.Name = "Read";
            this.Read.Padding = new System.Windows.Forms.Padding(3);
            this.Read.Size = new System.Drawing.Size(252, 214);
            this.Read.TabIndex = 1;
            this.Read.Text = "Read";
            this.Read.UseVisualStyleBackColor = true;
            // 
            // listRead
            // 
            this.listRead.FormattingEnabled = true;
            this.listRead.Location = new System.Drawing.Point(6, 6);
            this.listRead.Name = "listRead";
            this.listRead.Size = new System.Drawing.Size(240, 160);
            this.listRead.TabIndex = 2;
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(127, 175);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(93, 33);
            this.btnExit2.TabIndex = 1;
            this.btnExit2.Text = "Exit";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(28, 175);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(93, 33);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // Reminder
            // 
            this.Reminder.Controls.Add(this.listReminder);
            this.Reminder.Controls.Add(this.btnReminder);
            this.Reminder.Controls.Add(this.btnExit3);
            this.Reminder.Controls.Add(this.label6);
            this.Reminder.Controls.Add(this.txtBirthMonth2);
            this.Reminder.Location = new System.Drawing.Point(4, 22);
            this.Reminder.Name = "Reminder";
            this.Reminder.Size = new System.Drawing.Size(252, 214);
            this.Reminder.TabIndex = 2;
            this.Reminder.Text = "Reminder";
            this.Reminder.UseVisualStyleBackColor = true;
            // 
            // listReminder
            // 
            this.listReminder.FormattingEnabled = true;
            this.listReminder.Location = new System.Drawing.Point(6, 37);
            this.listReminder.Name = "listReminder";
            this.listReminder.Size = new System.Drawing.Size(230, 134);
            this.listReminder.TabIndex = 4;
            // 
            // btnReminder
            // 
            this.btnReminder.Location = new System.Drawing.Point(25, 178);
            this.btnReminder.Name = "btnReminder";
            this.btnReminder.Size = new System.Drawing.Size(93, 33);
            this.btnReminder.TabIndex = 3;
            this.btnReminder.Text = "Reminder";
            this.btnReminder.UseVisualStyleBackColor = true;
            this.btnReminder.Click += new System.EventHandler(this.btnReminder_Click);
            // 
            // btnExit3
            // 
            this.btnExit3.Location = new System.Drawing.Point(124, 178);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(93, 33);
            this.btnExit3.TabIndex = 2;
            this.btnExit3.Text = "Exit";
            this.btnExit3.UseVisualStyleBackColor = true;
            this.btnExit3.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Birth Month: ";
            // 
            // txtBirthMonth2
            // 
            this.txtBirthMonth2.Location = new System.Drawing.Point(76, 11);
            this.txtBirthMonth2.MaxLength = 2;
            this.txtBirthMonth2.Name = "txtBirthMonth2";
            this.txtBirthMonth2.Size = new System.Drawing.Size(100, 20);
            this.txtBirthMonth2.TabIndex = 0;
            // 
            // Friends
            // 
            this.AcceptButton = this.btnEnterFriend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.tabControl1);
            this.Name = "Friends";
            this.Text = "Friends";
            this.tabControl1.ResumeLayout(false);
            this.Entry.ResumeLayout(false);
            this.Entry.PerformLayout();
            this.Read.ResumeLayout(false);
            this.Reminder.ResumeLayout(false);
            this.Reminder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Entry;
        private System.Windows.Forms.TabPage Read;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBirthDay;
        private System.Windows.Forms.TextBox txtBirthMonth;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskPhoneNum;
        private System.Windows.Forms.Button btnEnterFriend;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listRead;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TabPage Reminder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBirthMonth2;
        private System.Windows.Forms.Button btnExit3;
        private System.Windows.Forms.ListBox listReminder;
        private System.Windows.Forms.Button btnReminder;
    }
}

