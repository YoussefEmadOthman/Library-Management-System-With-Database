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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();

            // Check if primary keys already exist in the table
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Book_copy WHERE BC_ISBN = @BC_ISBN OR Copy_no = @Copy_no", con);
            checkCmd.Parameters.AddWithValue("@BC_ISBN", textBox4.Text);
            checkCmd.Parameters.AddWithValue("@Copy_no", int.Parse(textBox1.Text));
            int copyCount = (int)checkCmd.ExecuteScalar();

            if (copyCount > 0)
            {
                MessageBox.Show("Copy_no and BC_ISBN both exists. Please choose a different Copy_no or BC_ISBN.");
            }
            else
            {
                // Insert new record if primary keys do not exist
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Book_copy VALUES (@Copy_no, @Is_checked_out, @Is_damaged, @BC_ISBN)", con);
                insertCmd.Parameters.AddWithValue("@Copy_no", int.Parse(textBox1.Text));
                insertCmd.Parameters.AddWithValue("@Is_checked_out", textBox2.Text);
                insertCmd.Parameters.AddWithValue("@Is_damaged", textBox3.Text);
                insertCmd.Parameters.AddWithValue("@BC_ISBN", textBox4.Text);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added record.");
            }

            con.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
