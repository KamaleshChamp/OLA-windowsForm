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

namespace olaa_system
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            Autono();
            Customerload();
        }


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-NJ64FGD8\\SQLEXPRESS;  Initial catalog=ola_Syste; User ID=kamalesh; Password=champ@09;");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        bool Mode = true;
        string id;

        public void Autono()
        {
            sql = "select custId from Customer order by custId desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                int id = int.Parse(dr[0].ToString()) + 1; // where here 0 position is reg no are 0
                proid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00001");
            }
            else
            {
                proid = ("00001");

            }

            txtId.Text = proid.ToString();


            con.Close();

        }

        public void Customerload()
        {

            sql = "select* from Customer ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader(); //qs
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }

            con.Close();


        }


        public void getid(string id)
        {
            sql = "select * from Customer  where custId = '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                txtId.Text = dr[0].ToString();
                txtName.Text = dr[1].ToString();
                txtAddr.Text = dr[2].ToString();
                txtMobile.Text = dr[3].ToString();


            }

            con.Close();

        }




        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textRegno_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void car_Click(object sender, EventArgs e)
        {
            //call all the textBox in add buttun

            string custId = txtId.Text;
            string cutmName = txtName.Text;
            string cutmAddr = txtAddr.Text;
            string cutmMobile = txtMobile.Text;

             id = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            if (Mode == true)
            {
                sql = "insert into Customer (custId,custName,custAddress,Mobile)values(@custId,@custName,@custAddress,@Mobile)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@custId", custId);  // qs
                cmd.Parameters.AddWithValue("@custName", cutmName);
                cmd.Parameters.AddWithValue("@custAddress", cutmAddr);
                cmd.Parameters.AddWithValue("@Mobile", cutmMobile);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully");

                
                txtName.Clear();
                txtAddr.Clear();
                txtMobile.Clear();
                txtName.Focus();





            }
            else
            {
                sql = "update Customer set  custName = @custName, @custAddress = @custAddress, Mobile = @Mobile where  custId = @custId ";
                con.Open();
                cmd = new SqlCommand(sql,con);

              
                cmd.Parameters.AddWithValue("@custName", cutmName);
                cmd.Parameters.AddWithValue("@custAddress", cutmAddr);
                cmd.Parameters.AddWithValue("@Mobile", cutmMobile);
                cmd.Parameters.AddWithValue("@custId", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                txtId.Enabled = true;
                Mode = true;

                txtName.Clear();
                txtAddr.Clear();
                txtMobile.Clear();
                txtName.Focus();






            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false; // is crt 
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtId.Enabled = false; // to enable to edit text box

                getid(id); // here we call the getid to edit



                // for delete button for delete the record

            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                Mode = false; // is crt 
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from Customer where custId = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record Deleted");
                con.Close();

            }
        }

        private void textRefresh_Click(object sender, EventArgs e)
        {
           Customerload();
            Autono();
            txtName.Clear();
            txtAddr.Clear();
            txtMobile.Clear();
            txtName.Focus();

        }

        private void back_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }
    }
}

