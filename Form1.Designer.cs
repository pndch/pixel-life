namespace pixellife
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            button3 = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label12 = new Label();
            checkBox3 = new CheckBox();
            label13 = new Label();
            checkBox4 = new CheckBox();
            label14 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(239, 12);
            button1.Name = "button1";
            button1.Size = new Size(23, 23);
            button1.TabIndex = 0;
            button1.Text = "✅";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(78, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(128, 21);
            label1.TabIndex = 6;
            label1.Text = "simulation speed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 164);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 7;
            label2.Text = "Statistics";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 200);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 8;
            label3.Text = "Average lifetime 100:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 200);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 9;
            label4.Text = "0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(135, 185);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 11;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 185);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 10;
            label6.Text = "Record lifetime:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(135, 230);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 13;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 230);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 12;
            label8.Text = "Iteration:";
            // 
            // button2
            // 
            button2.Location = new Point(157, 299);
            button2.Name = "button2";
            button2.Size = new Size(115, 50);
            button2.TabIndex = 14;
            button2.Text = "bot settings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 299);
            button3.Name = "button3";
            button3.Size = new Size(115, 50);
            button3.TabIndex = 15;
            button3.Text = "start sim";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(135, 215);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 17;
            label9.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 215);
            label10.Name = "label10";
            label10.Size = new Size(111, 15);
            label10.TabIndex = 16;
            label10.Text = "Average lifetime 25:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(12, 77);
            label11.Name = "label11";
            label11.Size = new Size(111, 21);
            label11.TabIndex = 18;
            label11.Text = "gather statistic";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(155, 83);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 19;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(155, 62);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 21;
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(12, 56);
            label12.Name = "label12";
            label12.Size = new Size(117, 21);
            label12.TabIndex = 20;
            label12.Text = "genome output";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(155, 104);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 23;
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(12, 98);
            label13.Name = "label13";
            label13.Size = new Size(72, 21);
            label13.TabIndex = 22;
            label13.Text = "show fps";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(155, 41);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 25;
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(12, 35);
            label14.Name = "label14";
            label14.Size = new Size(137, 21);
            label14.TabIndex = 24;
            label14.Text = "perfomance mode";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 361);
            Controls.Add(checkBox4);
            Controls.Add(label14);
            Controls.Add(checkBox3);
            Controls.Add(label13);
            Controls.Add(checkBox2);
            Controls.Add(label12);
            Controls.Add(checkBox1);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "simulation manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private Button button3;
        private Label label9;
        private Label label10;
        private Label label11;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label12;
        private CheckBox checkBox3;
        private Label label13;
        private CheckBox checkBox4;
        private Label label14;
    }
}