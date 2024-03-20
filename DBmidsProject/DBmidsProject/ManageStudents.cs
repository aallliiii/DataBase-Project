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

namespace DBmidsProject
{
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string Command = "insert into Student values(@FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)";
            SqlConnection con = new SqlConnection (ConnectionString);
            con.Open ();
            SqlCommand cmd = new SqlCommand (Command, con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("Status", status());
            cmd.ExecuteNonQuery ();
            con.Close ();
            MessageBox.Show("Successfully Inserted!");


            con.Open();
            
        }
        private int status()
        {
            int status;
            if (comboBox1.Text == "Current Student")
                status = 5;
            else
                status = 6;

            return status;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudent = new DeleteStudent();
            this.Hide();
            deleteStudent.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent();
            this.Hide();
            updateStudent.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewSpecific viewSpecific = new ViewSpecific();
            this.Hide ();
            viewSpecific.ShowDialog();
        }

        private void LoadData()
        {
            
            string connectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string query = "SELECT * FROM student";


                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open ();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }

        private void button6_Click(object sender, EventArgs e)
        {
            MarkAttendence markAttendence = new MarkAttendence();
            this.Hide();    
            markAttendence.ShowDialog();
        }
    }
    }


