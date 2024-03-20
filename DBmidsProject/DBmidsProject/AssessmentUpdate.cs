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
    public partial class AssessmentUpdate : Form
    {
        public AssessmentUpdate()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageAssesment manageAssesment = new ManageAssesment();
            this.Hide();
            manageAssesment.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-4QQAIDQ\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;";
            string Command = "update assessment set TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage where title=@title";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(Command, con);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);
            cmd.Parameters.AddWithValue("@title", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");
        }
    }
}
