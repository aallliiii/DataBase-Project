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
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
             string DelCommand = "select ID from student where RegistrationNumber=@RegistrationNumber";
             string Command = "delete student where RegistrationNumber=@RegistrationNumber";

             SqlConnection con = new SqlConnection(ConnectionString);
             con.Open();

             SqlCommand findD = new SqlCommand(DelCommand,  con);
             findD.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);
             int ID = Convert.ToInt32(findD.ExecuteScalar());

             string MyDel = "delete studentAttendance where StudentID="+ID.ToString();
             SqlCommand Delete = new SqlCommand(MyDel, con);
             Delete.ExecuteNonQuery();

             SqlCommand cmd = new SqlCommand(Command, con);
             cmd.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);
             cmd.ExecuteNonQuery();
             con.Close();
             MessageBox.Show("Successfully deleted!");
           

        }
    }
}
