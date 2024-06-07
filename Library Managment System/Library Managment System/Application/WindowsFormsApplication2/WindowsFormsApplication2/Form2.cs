using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Student_Faculty");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Book");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Author");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Genre");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM  Keywords");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT *FROM  Book_copy");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT *FROM  Borrow");

            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            String message = "Data Shown Succesfully";
            MessageBox.Show(message);
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
        }
    }
}
