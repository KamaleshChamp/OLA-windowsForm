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
    public partial class Carreg : Form
    {
        public Carreg()
        {
            InitializeComponent();
            Autono();
            load();
        }


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-NJ64FGD8\\SQLEXPRESS;  Initial catalog=ola_Syste; User ID=kamalesh; Password=champ@09;");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        bool Mode = true;
        string id;


        //for the auto increment in car reg number

        public void Autono()
        {
            sql = "select Reg_no from CarRegg order by Reg_no desc";
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
                proid = ("00000");
            }
            else
            {
                proid = ("00000");

            }

            textRegno.Text = proid.ToString();


            con.Close();

        }


        // to load the table

        public void load()
        {

            sql = "select* from CarRegg ";
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


        public void getid( string id)
        {
            sql = "select * from CarRegg  where Reg_no = '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                textRegno.Text = dr[0].ToString();
                textCompany.Text = dr[1].ToString();
                textModel.Text = dr[2].ToString();
                Avilable.Text = dr[3].ToString();


            }

            con.Close();

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void car_Click(object sender, EventArgs e)
        {

            //call all the textBox in add buttun

            string regno = textRegno.Text;
            string company = textCompany.Text;
            string model = textModel.Text;
            string aval = Avilable.SelectedItem.ToString();

            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();



            if (Mode == true)
            {
                sql = "insert into CarRegg (Reg_no,Company,Model,Available)values(@Reg_no,@Company,@Model,@Available)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Reg_no", regno);  // qs
                cmd.Parameters.AddWithValue("@Company", company);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully");

                textRegno.Clear();
                textCompany.Clear();
                textModel.Clear();
                textCompany.Focus();
                




            }
            else
            {
                sql = "update CarRegg set  Company= @Company, Model = @Model, Available = @Available where Reg_no = @Reg_no ";
                con.Open();
                cmd = new SqlCommand(sql, con);
              
                cmd.Parameters.AddWithValue("@Company", company);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.Parameters.AddWithValue("@Reg_no", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                textRegno.Enabled = true;
                Mode = true;

                textRegno.Clear();
                textCompany.Clear();
                textModel.Clear();
                textCompany.Focus();
             
                




            }
              con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // for edit button to edit the text 

            if(e.ColumnIndex==dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false; // is crt 
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textRegno.Enabled = false; // to enable to edit text box

                getid(id); // here we call the getid to edit



                // for delete button for delete the record

            } else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0) 
            {
                Mode = false; // is crt 
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from CarRegg where Reg_no = @id";
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
            load();
            Autono();
            textRegno.Clear();
            textCompany.Clear();
            textModel.Clear();
            textCompany.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
            


                


        }
    }
}
