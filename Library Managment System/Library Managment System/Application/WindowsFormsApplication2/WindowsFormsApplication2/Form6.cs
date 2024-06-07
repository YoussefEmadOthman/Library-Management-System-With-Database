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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();

           
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Book WHERE ISBN = @ISBN", con);
            checkCmd.Parameters.AddWithValue("@ISBN", textBox1.Text);
            int isbnCount = (int)checkCmd.ExecuteScalar();

            if (isbnCount > 0)
            {
                MessageBox.Show("ISBN already exists in the Book table. Please enter a different ISBN.");
            }
            else
            {
               
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Book VALUES (@ISBN, @Title, @Publisher, @Edition, @G_Name)", con);
                insertCmd.Parameters.AddWithValue("@ISBN", textBox1.Text);
                insertCmd.Parameters.AddWithValue("@Title", textBox2.Text);
                insertCmd.Parameters.AddWithValue("@Publisher", textBox3.Text);
                insertCmd.Parameters.AddWithValue("@Edition", textBox4.Text);
                insertCmd.Parameters.AddWithValue("@G_Name", textBox5.Text);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added record.");
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Book set 	Title=@Title	,Publisher=@Publisher,	Edition=@Edition,	G_Name= @G_Name where ISBN=@ISBN", con);
            cmd.Parameters.AddWithValue("@ISBN", (textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Publisher", textBox3.Text);
            cmd.Parameters.AddWithValue("@Edition", textBox4.Text);
            cmd.Parameters.AddWithValue("@G_Name", textBox5.Text);
            cmd.ExecuteNonQuery();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Book where ISBN=@ISBN", con);
            cmd.Parameters.AddWithValue("@ISBN", textBox1.Text);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
