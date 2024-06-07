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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
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
            string sql_command = ("SELECT b.ISBN, b.Title, bo.Date_of_borrow, s.User_ID, s.Name, s.Department FROM Book b INNER JOIN Borrow bo ON b.ISBN = bo.MM_ISBN INNER JOIN Student_Faculty s ON bo.MM_User_Id = s.User_ID WHERE b.Publisher = 'Bloomsbury'");

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT COUNT(*) FROM Borrow WHERE DATEDIFF(month, Return_date, GETDATE()) = 1");

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

        private void button1_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT AVG(DATEDIFF(day, Date_of_borrow, Return_date)) AS Average_Borrowing_Time FROM Borrow");

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

        private void button5_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Student_Faculty WHERE DoB >= '1990' AND DoB < '2000'");

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

        private void button6_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT a.Author_Name, b.Title, b.Publisher FROM Author a INNER JOIN Book b ON a.B_ISBN = b.ISBN WHERE a.Author_Name IN ( SELECT Author_Name FROM Author GROUP BY Author_Name HAVING COUNT(*) > 1)");
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

        private void button7_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("select G_Name from book union select Name from Keywords");

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

        private void button8_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT * FROM Book WHERE ISBN NOT IN (SELECT MM_ISBN FROM Borrow WHERE Date_of_borrow >= DATEADD(month, -1, GETDATE()))");

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

        private void button9_Click(object sender, EventArgs e)
        {

        }


        private void button10_Click(object sender, EventArgs e)
        {

            TextBox textBox = new TextBox();

            textBox.Location = new Point(900, 250);
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

        private void button11_Click(object sender, EventArgs e)
        {
            string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(connected_string);
            con.Open();
            string sql_command = ("SELECT Student_Faculty.Name, COUNT(*) as Num_Borrowed FROM Student_Faculty JOIN Borrow ON Student_Faculty.User_ID = Borrow.MM_User_Id GROUP BY Student_Faculty.Name");

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

        private void button9_Click_1(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {

            TextBox textBox = new TextBox();


            textBox.Location = new Point(900, 250);
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

        private void button14_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();


            textBox.Location = new Point(900, 250);
            textBox.Size = new Size(200, 20);


            this.Controls.Add(textBox);


            textBox.KeyDown += (s, eventArgs) =>
            {
                if (eventArgs.KeyCode == Keys.Enter)
                {

                    string BC_ISBN_box = textBox.Text;


                    string connected_string = "Data Source=DESKTOP-RPHI6GJ;Initial Catalog=Library_Management_System;Integrated Security=True";
                    string query = "SELECT * FROM Book_copy WHERE BC_ISBN = @BC_ISBN";


                    using (SqlConnection con = new SqlConnection(connected_string))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@BC_ISBN", BC_ISBN_box);


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

        private void button15_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();

            textBox.Location = new Point(900, 250);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
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

        private void button13_Click_1(object sender, EventArgs e)
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

        private void button15_Click_1(object sender, EventArgs e)
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

