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
    public partial class MarkAttendence : Form
    {
        public MarkAttendence()
        {
            InitializeComponent();
            AddItems();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddItems()
        {
            
            string connectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";

            
            string query = "SELECT RegistrationNumber FROM Student";

           
           
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);

               

               
                SqlDataReader reader = command.ExecuteReader();

                
                comboBox1.Items.Clear();

              
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0)); 
                }

               
                reader.Close();
                connection.Close();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now.Date;
            string Connection = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(Connection);
            connection.Open();
            string query1 = "Insert Into ClassAttendance(AttendanceDate) OUTPUT INSERTED.ID Values('" + date + "')";
            SqlCommand sqlcmd = new SqlCommand(query1, connection);
            int classId = Convert.ToInt32(sqlcmd.ExecuteScalar());

            for (int i = 0; i < comboBox1.Items.Count - 1; i++)
            {
      
                int studentId = 0;
                string query2 = "Select * from Student where RegistrationNumber = '" + comboBox1.Text + "'";
                SqlCommand sqlcmd2 = new SqlCommand(query2, connection);
                SqlDataReader reader = sqlcmd2.ExecuteReader();
                while(reader.Read())
                {
                    studentId = (int)reader["Id"];
                }
                reader.Close();
              
                int attendanceId = 0;
                if (comboBox2.Text=="Present")
                {
                    attendanceId = 1;
                }
                else
                {
                    attendanceId = 2;
                }

              
                string query3 = "Insert Into StudentAttendance(AttendanceId, StudentId, AttendanceStatus) " +
                    "Values('" + classId + "', '" + studentId + "', '" + attendanceId + "')";
                SqlCommand sqlcmd3 = new SqlCommand(query3, connection);
                sqlcmd3.ExecuteNonQuery();
            }
            connection.Close();
            MessageBox.Show("Attendence Marked Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageStudents manageStudents = new ManageStudents();
            this.Hide();
            manageStudents.ShowDialog();
        }
    }
    }

