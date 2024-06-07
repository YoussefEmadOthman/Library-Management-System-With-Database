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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlConnection con = new SqlConnection(connected_string);
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Borrow WHERE Borrow_ID = @Borrow_ID", con);
                checkCmd.Parameters.AddWithValue("@Borrow_ID", int.Parse(textBox5.Text));
                int borrowCount = (int)checkCmd.ExecuteScalar();

                if (borrowCount > 0)
                {
                    MessageBox.Show("Borrow_ID is already taken. Please choose a different Borrow_ID.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Borrow VALUES (@MM_User_Id, @Date_of_borrow, @Return_date, @Extension_date, @Borrow_ID, @MM_ISBN, @MM_copy_no)", con);
                    cmd.Parameters.AddWithValue("@MM_User_Id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Date_of_borrow", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Return_date", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Extension_date", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Borrow_ID", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@MM_ISBN", textBox6.Text);
                    cmd.Parameters.AddWithValue("@MM_copy_no", int.Parse(textBox7.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    String message = "Successfully added record.";

                    MessageBox.Show(message);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
