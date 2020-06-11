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

namespace VP_Project
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection(@"server= DESKTOP-TFANBI8;database = VP_Project;integrated security = true");
        SqlCommand cmd;
        DataTable Dt = new DataTable();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.Text = "Select your job";
            cmd = new SqlCommand(@"select * from login", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["job"]);
            }
            conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            librarian librarian = new librarian();
            admin admin = new admin();

           
            try {
                conn.Open();
                cmd = new SqlCommand(@"Select password from login",conn);
               
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (comboBox1.Text == "librarian" && dr["password"].Equals(textBox1.Text))
                    {
                        librarian.Show();
                        break;
                    } else if (comboBox1.Text == "admin" && dr["password"].Equals(textBox1.Text))
                    {
                        admin.Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the password is not correct or job");
                        break;
                    }
                }
                conn.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
            
        }
    }
}
