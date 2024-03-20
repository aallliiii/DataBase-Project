using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBmidsProject
{
    public partial class ManageAssesment : Form
    {
        public ManageAssesment()
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
        private void LoadData()
        {

            string connectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string query = "SELECT * FROM Assessment";


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);


            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string Command = "insert into Assessment values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(Command, connection);
            command.Parameters.AddWithValue("@Title", textBox1.Text);
            command.Parameters.AddWithValue("DateCreated", DateTime.Now.Date);
            command.Parameters.AddWithValue("TotalMarks", int.Parse(textBox2.Text));
            command.Parameters.AddWithValue("TotalWeightage", int.Parse(textBox3.Text));
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Added");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssessmentUpdate assessmentUpdate = new AssessmentUpdate();
            this.Hide();
            assessmentUpdate.ShowDialog();
        }
    }
}
