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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String message = "Please inform the admin with your wished book to begin the borrow operation";
            MessageBox.Show(message);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();




            textBox.Location = new Point(698, 195);
            textBox.Size = new Size(200, 20);




            this.Controls.Add(textBox);




            textBox.KeyDown += (s, eventArgs) =>
            {
                if (eventArgs.KeyCode == Keys.Enter)
                {



                    string Genrename_box = textBox.Text;




                    string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
                    string query = "SELECT * FROM Book WHERE G_Name = @G_Name";




                    using (SqlConnection con = new SqlConnection(connected_string))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {



                        cmd.Parameters.AddWithValue("@G_Name", Genrename_box);




                        con.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {



                            dt.Load(reader);
                        }




                        dataGridView1.DataSource = dt;
                    }
                }
            };
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT Book.ISBN, Book.Title, Author.Author_Name, Book_copy.Copy_no FROM Book JOIN Author ON Book.ISBN = Author.B_ISBN JOIN Book_copy ON Book.ISBN = Book_copy.BC_ISBN WHERE Book_copy.Is_checked_out = 'No';");



            SqlCommand cmd = new SqlCommand(sql_command, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);



            if (dt.Rows.Count > 0) // Check if there are any rows in the DataTable
            {
                dataGridView1.DataSource = dt;
                String message = "Data Shown Succesfully";
                MessageBox.Show(message);
            }
            else
            {
                String message = "No records found";
                MessageBox.Show(message);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();

 

            textBox.Location = new Point(698, 195);
            textBox.Size = new Size(200, 20);

 

            this.Controls.Add(textBox);

 

            textBox.KeyDown += (s, eventArgs) =>
            {
                if (eventArgs.KeyCode == Keys.Enter)
                {
                    string authorName = textBox.Text;



                    string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
                    string query = "SELECT Book.ISBN, Book.Title, Book.Publisher, Book.Edition, Genre.Name " +
                                   "FROM Book " +
                                   "INNER JOIN Author ON Book.ISBN = Author.B_ISBN " +
                                   "INNER JOIN Genre ON Book.G_Name = Genre.Name " +
                                   "WHERE Author.Author_Name = @AuthorName";

 

                    using (SqlConnection con = new SqlConnection(connected_string))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AuthorName", authorName);

 

                        con.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

 

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No records found.");
                        }
                        else
                        {
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            };
        }
        }
    }

