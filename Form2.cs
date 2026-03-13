using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixellife
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = g.botCount.ToString();
            textBox2.Text = g.maximumBotCount.ToString();

            textBox5.Text = g.startHP.ToString();
            textBox3.Text = g.foodCount.ToString();
            textBox6.Text = g.foodEff.ToString();

            textBox4.Text = g.mutationFactor.ToString();
            textBox9.Text = g.mutationStep.ToString();

            textBox7.Text = g.dupe.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.botCount = int.Parse(textBox1.Text);
            g.maximumBotCount = int.Parse(textBox2.Text);

            g.startHP = int.Parse(textBox5.Text);
            g.foodCount = int.Parse(textBox3.Text);
            g.foodEff = int.Parse(textBox6.Text);

            g.mutationFactor = int.Parse(textBox4.Text);
            g.mutationStep = double.Parse(textBox9.Text);

            g.dupe = bool.Parse(textBox7.Text);

            Close();
        }
    }
}
