using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
