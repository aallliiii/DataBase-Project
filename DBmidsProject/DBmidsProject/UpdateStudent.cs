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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            ManageStudents manageStudents = new ManageStudents();
            this.Hide();
            manageStudents.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string Command = "update Student set FirstName=@FirstName, LastName=@Lastname, Contact=@Contact, Email=@Email, Status=@Status where RegistrationNumber=@RegistrationNumber";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(Command, con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", status());
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
