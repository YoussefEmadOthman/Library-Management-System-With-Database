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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Genre WHERE Name = @Name", con);
            checkCmd.Parameters.AddWithValue("@Name", textBox1.Text);
            int nameCount = (int)checkCmd.ExecuteScalar();

            if (nameCount > 0)
            {
                MessageBox.Show("Genre Name is already taken. Please choose a different Name.");
            }
            else
            {
                
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Genre (Name) VALUES (@Name)", con);
                insertCmd.Parameters.AddWithValue("@Name", textBox1.Text);
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
            SqlCommand cmd = new SqlCommand("Update  Genre values where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            String message = "Succesfully Added";
            MessageBox.Show(message);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
