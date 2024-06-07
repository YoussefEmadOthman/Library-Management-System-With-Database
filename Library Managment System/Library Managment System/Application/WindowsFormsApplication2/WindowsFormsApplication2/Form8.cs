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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();

            
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Author WHERE B_ISBN = @B_ISBN AND Author_Name = @Author_Name", con);
            checkCmd.Parameters.AddWithValue("@B_ISBN", textBox1.Text);
            checkCmd.Parameters.AddWithValue("@Author_Name", textBox2.Text);
            int authorCount = (int)checkCmd.ExecuteScalar();

            if (authorCount > 0)
            {
                MessageBox.Show("Author record already exists.");
            }
            else
            {
                
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Author VALUES (@B_ISBN, @Author_Name)", con);
                insertCmd.Parameters.AddWithValue("@B_ISBN", textBox1.Text);
                insertCmd.Parameters.AddWithValue("@Author_Name", textBox2.Text);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added Author record.");
            }

            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
