namespace Queuing_Application
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.studentPanel = new System.Windows.Forms.Panel();
            this.studentSubmit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.guestPanel = new System.Windows.Forms.Panel();
            this.guestSubmit = new System.Windows.Forms.Button();
            this.gcomboBox2 = new System.Windows.Forms.ComboBox();
            this.gtextBox2 = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.studentPanel.SuspendLayout();
            this.guestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 525);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(0, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 147);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guest";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 147);
            this.button1.TabIndex = 1;
            this.button1.Text = "Student";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 104);
            this.panel3.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(119, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 41);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(166, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(740, 77);
            this.panel4.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // studentPanel
            // 
            this.studentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.studentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentPanel.Controls.Add(this.studentSubmit);
            this.studentPanel.Controls.Add(this.comboBox1);
            this.studentPanel.Controls.Add(this.textBox1);
            this.studentPanel.Location = new System.Drawing.Point(166, 145);
            this.studentPanel.Name = "studentPanel";
            this.studentPanel.Size = new System.Drawing.Size(0, 231);
            this.studentPanel.TabIndex = 3;
            this.studentPanel.Visible = false;
            // 
            // studentSubmit
            // 
            this.studentSubmit.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentSubmit.Location = new System.Drawing.Point(18, 164);
            this.studentSubmit.Name = "studentSubmit";
            this.studentSubmit.Size = new System.Drawing.Size(214, 46);
            this.studentSubmit.TabIndex = 2;
            this.studentSubmit.Text = "Submit";
            this.studentSubmit.UseVisualStyleBackColor = true;
            this.studentSubmit.Click += new System.EventHandler(this.studentSubmit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "(none)";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Enrollment",
            "Payment",
            "Documents",
            "Accounts"});
            this.comboBox1.Location = new System.Drawing.Point(18, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.comboBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Location = new System.Drawing.Point(18, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "ID Number";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // guestPanel
            // 
            this.guestPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.guestPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guestPanel.Controls.Add(this.guestSubmit);
            this.guestPanel.Controls.Add(this.gcomboBox2);
            this.guestPanel.Controls.Add(this.gtextBox2);
            this.guestPanel.Location = new System.Drawing.Point(166, 226);
            this.guestPanel.Name = "guestPanel";
            this.guestPanel.Size = new System.Drawing.Size(0, 231);
            this.guestPanel.TabIndex = 4;
            this.guestPanel.Visible = false;
            // 
            // guestSubmit
            // 
            this.guestSubmit.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestSubmit.Location = new System.Drawing.Point(18, 164);
            this.guestSubmit.Name = "guestSubmit";
            this.guestSubmit.Size = new System.Drawing.Size(214, 46);
            this.guestSubmit.TabIndex = 2;
            this.guestSubmit.Text = "Submit";
            this.guestSubmit.UseVisualStyleBackColor = true;
            this.guestSubmit.Click += new System.EventHandler(this.guestSubmit_Click);
            // 
            // gcomboBox2
            // 
            this.gcomboBox2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcomboBox2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.gcomboBox2.FormattingEnabled = true;
            this.gcomboBox2.Items.AddRange(new object[] {
            "Enrollment",
            "Payment",
            "Documents",
            "Accounts"});
            this.gcomboBox2.Location = new System.Drawing.Point(18, 88);
            this.gcomboBox2.Name = "gcomboBox2";
            this.gcomboBox2.Size = new System.Drawing.Size(214, 32);
            this.gcomboBox2.TabIndex = 1;
            this.gcomboBox2.Text = "Transaction Code";
            this.gcomboBox2.Enter += new System.EventHandler(this.textBox1_Enter);
            this.gcomboBox2.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // gtextBox2
            // 
            this.gtextBox2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtextBox2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.gtextBox2.Location = new System.Drawing.Point(18, 35);
            this.gtextBox2.Name = "gtextBox2";
            this.gtextBox2.Size = new System.Drawing.Size(214, 33);
            this.gtextBox2.TabIndex = 0;
            this.gtextBox2.Text = "Guest Name";
            this.gtextBox2.Enter += new System.EventHandler(this.textBox1_Enter);
            this.gtextBox2.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(906, 525);
            this.Controls.Add(this.guestPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.studentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.studentPanel.ResumeLayout(false);
            this.studentPanel.PerformLayout();
            this.guestPanel.ResumeLayout(false);
            this.guestPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel studentPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button studentSubmit;
        private System.Windows.Forms.Panel guestPanel;
        private System.Windows.Forms.Button guestSubmit;
        private System.Windows.Forms.ComboBox gcomboBox2;
        private System.Windows.Forms.TextBox gtextBox2;
        private System.Windows.Forms.Timer timer3;
    }
}

