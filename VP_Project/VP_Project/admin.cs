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
    public partial class admin : Form
    {

        SqlConnection conn = new SqlConnection(@"server= DESKTOP-TFANBI8;database = VP_Project;integrated security = true");
        SqlCommand cmd;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        SqlDataReader dr;
        SqlDataAdapter sda;
        public admin()
        {
            InitializeComponent();

            /* book */
            comboBox1.Text = "---Select the department---";
            cmd = new SqlCommand(@"select name from department", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["name"]);
            }
            conn.Close();

            sda = new SqlDataAdapter(@"select * from book", conn);
            conn.Open();
            sda.Fill(dt1);
            dataGridView1.DataSource = dt1;
            conn.Close();


            /* departmrnt */
            conn.Open();
            sda = new SqlDataAdapter(@"select * from department", conn);
            sda.Fill(dt2);
            dataGridView2.DataSource = dt2;
            conn.Close();

            /* opearations */
            sda = new SqlDataAdapter(@"select * from customer as cu left join buy as bu on cu.c_id = bu.c_id  ", conn);
            conn.Open();
            sda.Fill(dt4);
            dataGridView3.DataSource = dt4;
            conn.Close();


        }


        /*   start Books   */
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow sr = dataGridView1.Rows[index];
                textBox1.Text = sr.Cells[0].Value.ToString();
                textBox2.Text = sr.Cells[1].Value.ToString();
                textBox3.Text = sr.Cells[2].Value.ToString();
                textBox4.Text = sr.Cells[5].Value.ToString();
                comboBox1.Text = sr.Cells[4].Value.ToString();
                dateTimePicker1.Text = sr.Cells[3].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                cmd = new SqlCommand(@"select d_id from department where name = '" + comboBox1.Text +"'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                string str="1";
                while (dr.Read())
                {
                    str = dr["d_id"].ToString();
                }
                conn.Close();
                
                
                cmd = new SqlCommand(@"insert into book(name,author,pub_date,dept,price,d_id)values('"+ textBox2.Text+
                "','"+textBox3.Text+"','"+ dateTimePicker1.Text + "','"+comboBox1.Text+
                "',"+int.Parse(textBox4.Text)+","+int.Parse(str)+")", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(""+ex);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(@"delete from book where b_id = " + int.Parse(textBox1.Text), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(@"update book set name ='" + textBox2.Text 
                                                + "',author = '" + textBox3.Text 
                                                +"', price = " + int.Parse(textBox4.Text) 
                                                +",dept ='" + comboBox1.Text 
                                                +"',pub_date = '" + dateTimePicker1.Text  
                                                +"' where b_id = " + int.Parse(textBox1.Text), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }
            catch(SqlException ex) {
                MessageBox.Show("" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "---Select the department---";
            textBox5.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            conn.Open();
            sda = new SqlDataAdapter(@"select * from book", conn);
            sda.Fill(dt2);
            dataGridView1.DataSource = dt2;
            conn.Close();
        }

        /* departments */
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                cmd = new SqlCommand(@"insert into department(name)values('" + textBox6.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button10_Click(10, e);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                cmd = new SqlCommand(@"delete from department where d_id ="+int.Parse(textBox5.Text), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button10_Click(10, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow sr = dataGridView2.Rows[index];
            textBox5.Text = sr.Cells[0].Value.ToString();
            textBox6.Text = sr.Cells[1].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt4 = new DataTable();
            conn.Open();
            sda = new SqlDataAdapter(@"select * from department", conn);
            sda.Fill(dt4);
            dataGridView2.DataSource = dt4;
            conn.Close();
        }

        /* setting */
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                cmd = new SqlCommand(@"select password from login where job = 'admin'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str = dr["password"].ToString();
                }
                conn.Close();
                if (str == textBox8.Text)
                {
                    conn.Open();
                    cmd = new SqlCommand(@"update login set password = '" + textBox9.Text + "' where job = 'admin'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New password changed by successfule");
                }
                else
                {
                    MessageBox.Show("Sorry old password " + textBox8.Text + " not correct");
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        /* opearation */
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt5 = new DataTable();
                sda = new SqlDataAdapter(@"select * from customer as cu left join buy as bu on cu.c_id = bu.c_id where cu.name like '%"+textBox7.Text+"%'", conn);
                conn.Open();
                sda.Fill(dt5);
                dataGridView3.DataSource = dt5;
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
