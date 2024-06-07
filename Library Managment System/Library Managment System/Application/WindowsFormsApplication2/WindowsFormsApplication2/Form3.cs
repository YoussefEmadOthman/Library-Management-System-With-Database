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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Student_Faculty WHERE User_ID = @User_ID", con);
            checkCmd.Parameters.AddWithValue("@User_ID", int.Parse(textBox1.Text));
            int userCount = (int)checkCmd.ExecuteScalar();

            if (userCount > 0)
            {
                MessageBox.Show("User_ID is already taken. Please choose a different User_ID.");
            }
            else
            {
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Student_Faculty VALUES (@User_ID, @Password, @Name, @Gender, @DoB, @Email, @Department)", con);
                insertCmd.Parameters.AddWithValue("@User_ID", int.Parse(textBox1.Text));
                insertCmd.Parameters.AddWithValue("@Password", textBox2.Text);
                insertCmd.Parameters.AddWithValue("@Name", textBox3.Text);
                insertCmd.Parameters.AddWithValue("@Gender", textBox4.Text);
                insertCmd.Parameters.AddWithValue("@DoB", textBox5.Text);
                insertCmd.Parameters.AddWithValue("@Email", textBox6.Text);
                insertCmd.Parameters.AddWithValue("@Department", textBox7.Text);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added record.");
            }

            con.Close();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Student_Faculty set Password=@Password,Name= @Name,Gender= @Gender, DoB=@DoB, Email=@Email , Department=@Department where User_ID=@User_ID	", con);
            cmd.Parameters.AddWithValue("@User_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox4.Text);
            cmd.Parameters.AddWithValue("@DoB", textBox5.Text);
            cmd.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd.Parameters.AddWithValue("@Department", textBox7.Text);
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

            // Check if the user has any borrowed books
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Borrow WHERE MM_User_Id = @MM_User_Id", con);
            checkCmd.Parameters.AddWithValue("@MM_User_Id", int.Parse(textBox1.Text));
            int borrowedBooksCount = (int)checkCmd.ExecuteScalar();

            if (borrowedBooksCount > 0)
            {
                String message = "This user has borrowed books and cannot be deleted.";
                MessageBox.Show(message);
            }
            else
            {
                // Delete the user record
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM Student_Faculty WHERE User_ID = @User_ID", con);
                deleteCmd.Parameters.AddWithValue("@User_ID", int.Parse(textBox1.Text));
                int rowsAffected = deleteCmd.ExecuteNonQuery();

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

            con.Close();


        }
    }
}
