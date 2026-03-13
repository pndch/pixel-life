namespace pixellife
{
    partial class Form2
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            textBox9 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 8;
            label1.Text = "bot count";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(78, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 30);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 10;
            label2.Text = "max bot count";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(78, 23);
            textBox2.TabIndex = 9;
            textBox2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(85, 21);
            label3.TabIndex = 12;
            label3.Text = "food count";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(155, 90);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(78, 23);
            textBox3.TabIndex = 11;
            textBox3.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(106, 21);
            label4.TabIndex = 18;
            label4.Text = "mutation step";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(155, 152);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(78, 23);
            textBox4.TabIndex = 17;
            textBox4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 71);
            label5.Name = "label5";
            label5.Size = new Size(63, 21);
            label5.TabIndex = 16;
            label5.Text = "start hp";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(155, 69);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(78, 23);
            textBox5.TabIndex = 15;
            textBox5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 113);
            label6.Name = "label6";
            label6.Size = new Size(64, 21);
            label6.TabIndex = 14;
            label6.Text = "food eff";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(155, 111);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(78, 23);
            textBox6.TabIndex = 13;
            textBox6.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(12, 154);
            label9.Name = "label9";
            label9.Size = new Size(117, 21);
            label9.TabIndex = 20;
            label9.Text = "mutation factor";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(155, 173);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(78, 23);
            textBox9.TabIndex = 19;
            textBox9.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(12, 250);
            button1.Name = "button1";
            button1.Size = new Size(221, 40);
            button1.TabIndex = 21;
            button1.Text = "confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(245, 302);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(textBox9);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "bot settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label9;
        private TextBox textBox9;
        private Button button1;
    }
}