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
    public partial class librarian : Form
    {
        SqlConnection conn = new SqlConnection(@"server= DESKTOP-TFANBI8;database = VP_Project;integrated security = true");
        SqlCommand cmd;
        DataTable dt0 = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt5 = new DataTable();
        SqlDataAdapter sda;
        SqlDataReader dr;
        public librarian()
        {
            InitializeComponent();


            /* new customer */
            conn.Open();
            sda = new SqlDataAdapter(@"select * from customer", conn);
            sda.Fill(dt0);
            dataGridView1.DataSource = dt0;
            dataGridView4.DataSource = dt0;
            conn.Close();

            /* buy book */
            conn.Open();
            sda = new SqlDataAdapter(@"select * from buy", conn);
            sda.Fill(dt1);
            dataGridView2.DataSource = dt1;
            conn.Close();

            comboBox1.Text = "---Select the customer name---";
            cmd = new SqlCommand(@"select name from customer", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["name"]);
            }
            conn.Close();

            comboBox2.Text = "---Select the book name---";
            cmd = new SqlCommand(@"select name from book", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["name"]);
            }
            conn.Close();

            /* search */
            conn.Open();
            sda = new SqlDataAdapter(@"select * from book", conn);
            sda.Fill(dt5);
            dataGridView3.DataSource = dt5;
            conn.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                cmd = new SqlCommand(@"delete from customer where c_id = " + textBox1.Text, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                cmd = new SqlCommand(@"update customer set name ='" + textBox2.Text + "', adress = '"
                    + textBox3.Text + "',age=" + int.Parse(textBox4.Text) + ", phone='" + textBox5.Text + "' where c_id ='"+textBox1.Text+"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                conn.Close();
                cmd = new SqlCommand(@"insert into customer(c_id,name,adress,age,phone) values ('" + textBox1.Text
                    + "','" + textBox2.Text + "','" + textBox3.Text + "'," + int.Parse(textBox4.Text) + ",'" + textBox5.Text+"')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                button9_Click(9, e);
            }catch(SqlException ex){
                MessageBox.Show("" + ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow sr = dataGridView1.Rows[index];
            textBox1.Text = sr.Cells[0].Value.ToString();
            textBox2.Text = sr.Cells[1].Value.ToString();
            textBox3.Text = sr.Cells[2].Value.ToString();
            textBox4.Text = sr.Cells[3].Value.ToString();
            textBox5.Text = sr.Cells[4].Value.ToString();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            conn.Open();
            sda = new SqlDataAdapter(@"select * from customer", conn);
            sda.Fill(dt1);
            dataGridView1.DataSource = dt1;
            conn.Close();
        }


        /* buy book */

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string str1="", str2="";
                cmd = new SqlCommand(@"select c_id from customer where name ='" + comboBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str1 = dr["c_id"].ToString();
                    break;
                }
                conn.Close();

                cmd = new SqlCommand(@"select b_id from book where name ='" + comboBox2.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str2 = dr["b_id"].ToString();
                    break;
                }
                conn.Close();

                cmd = new SqlCommand(@"insert into buy(c_id,b_id)values('"+str1+"',"+int.Parse(str2)+")", conn);
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
               
                string str1 = "", str2 = "";
                cmd = new SqlCommand(@"select c_id from customer where name ='" + comboBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str1 = dr["c_id"].ToString();
                    break;
                }
                conn.Close();

                cmd = new SqlCommand(@"select b_id from book where name ='" + comboBox2.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str2 = dr["b_id"].ToString();
                    break;
                }
                conn.Close();

                cmd = new SqlCommand(@"delete from buy where c_id ='" + str1 + "' and  b_id ="+int.Parse(str2), conn);
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
            cmd = new SqlCommand(@"select price from book where name='"+comboBox2.Text+"'", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            string price="";
            while (dr.Read())
            {
                price = dr["price"].ToString();
            }
            conn.Close();
            MessageBox.Show("the price of this book  = " + price);
            button10_Click(10, e);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(@"delete from buy where boo_id =" + int.Parse(textBox10.Text), conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            button10_Click(10, e);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                int index = e.RowIndex;
                DataGridViewRow sr = dataGridView2.Rows[index];
                
                string str1 = "", str2 = "";
                cmd = new SqlCommand(@"select name from customer where c_id ='" + sr.Cells[1].Value.ToString() + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str1 = dr["name"].ToString();
                    break;
                }
                conn.Close();

                cmd = new SqlCommand(@"select name from book where b_id =" + int.Parse(sr.Cells[2].Value.ToString()) , conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str2 = dr["name"].ToString();
                    break;
                }
                conn.Close();

                comboBox1.Text = str1;
                comboBox2.Text = str2;
                textBox10.Text = sr.Cells[0].Value.ToString();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            conn.Open();
            sda = new SqlDataAdapter(@"select * from buy", conn);
            sda.Fill(dt2);
            dataGridView2.DataSource = dt2;
            conn.Close();
        }

        /* search */
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                DataTable dt6 = new DataTable();
                sda = new SqlDataAdapter(@"select * from book where name like '%" + textBox6.Text + "%'", conn);
                sda.Fill(dt6);
                dataGridView3.DataSource = dt6;
                conn.Close();

            }catch(SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                DataTable dt7 = new DataTable();
                sda = new SqlDataAdapter(@"select * from customer where name like '%" + textBox7.Text + "%'", conn);
                sda.Fill(dt7);
                dataGridView4.DataSource = dt7;
                conn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /* -- setting -- */
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
                string str="";
                cmd = new SqlCommand(@"select password from login where job = 'librarian'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str = dr["password"].ToString();
                }
                conn.Close();
                if(str == textBox8.Text)
                {
                    conn.Open();
                    cmd = new SqlCommand(@"update login set password = '" + textBox9.Text + "' where job = 'librarian'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New password changed by successfule");
                }
                else
                {
                    MessageBox.Show("Sorry old password " + textBox8.Text + " not correct");
                }
                conn.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
