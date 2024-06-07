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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Keywords values (@Name	,	@Genre_Keys)", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Genre_Keys", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            String message = "Succesfully Added";
            MessageBox.Show(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update  Keywords set  	Genre_Keys = @Genre_Keys where Name= @Name	", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Genre_Keys", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            String message = "Succesfully Updated";
            MessageBox.Show(message);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Keywords WHERE Name = @Name;", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                String message = "Succesfully Deleted";
                MessageBox.Show(message);
            }
            else
            {
                String message = "No rows were affected by the delete command.";
                MessageBox.Show(message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Keywords SET Genre_Keys = @NewGenreKeys WHERE Name = @Name AND Genre_Keys = @Genre_Keys;", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Genre_Keys", textBox2.Text);
            cmd.Parameters.AddWithValue("@NewGenreKeys", textBox3.Text);
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                String message = "Successfully updated";
                MessageBox.Show(message);
            }
            else
            {
                String message = "Update failed";
                MessageBox.Show(message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        }
    }

