using static Raylib_cs.Raylib;

namespace pixellife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.speed = int.Parse(textBox1.Text.ToString());
            SetTargetFPS(g.speed);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (a.iteration > 1)
            {
                label7.Text = a.iteration.ToString();
                label5.Text = a.record.ToString();
                label4.Text = a.avgLifetime100.ToString();
                label9.Text = a.avgLifetime25.ToString();
            }
            if (Program.endflag == true) { Close(); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { a.Aflag = true; } else { a.Aflag = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { a.Gflag = true; } else { a.Gflag = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { g.FPSflag = true; } else { g.FPSflag = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "restart sim")
            {
                g.Sflag = true;
                g.Pflag = true;
                button3.Text = "start sim";
                button2.Text = "bot settings";
            }
            else if (button2.Text == "bot settings")
            {
                Form2 settings = new Form2();
                settings.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Text = "restart sim";
            if (g.Pflag == false) { g.Pflag = true; button3.Text = "unpause sim"; }
            else { g.Pflag = false; button3.Text = "pause sim"; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { g.Dflag = false; } else { g.Dflag = true; }
        }
    }
}
