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
    public partial class RentalBooking : Form
    {
        public RentalBooking()
        {
            InitializeComponent();
            carlod();
            Rentalload();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-NJ64FGD8\\SQLEXPRESS;  Initial catalog=ola_Syste; User ID=kamalesh; Password=champ@09;");
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
        string proid;
        string sql;
        string sql1;
        bool Mode = true;
        string id;


        public void carlod()
        {
            // connection path which have loaded in car reg table

            cmd = new SqlCommand("select * from CarRegg", con);
            con.Open();
            dr = cmd.ExecuteReader();

            // this is because we taking the car reg no to load in this car id

            while (dr.Read())
            {

                txtCarId.Items.Add(dr["Reg_no"].ToString());
            }

            con.Close();
        }


        public void Rentalload()
        {

            sql = "select* from Rentall ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader(); //qs
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6],dr[7],dr[8]);
            }

            con.Close();


        }


        private void RentalBooking_Load(object sender, EventArgs e)
        {

        }

        private void txtCarId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from CarRegg where Reg_no = '" + txtCarId.Text + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                // validation part
                // where we checking for if only the aval box shows YES we can able to type somthig
                // otherwise we cant edit or type the box (we not enabled)
                string avl;
                avl = dr["Available"].ToString();

                label10.Text = avl;



                if (avl == "No")
                {
                    txtCarId.Enabled = false;
                    txtFee.Enabled = false;
                    txtDate.Enabled = false;
                    txtDueDate.Enabled = false;
                }

                else
                {
                    label10.Text = "Car Not Available";
                }
            }

            // when its comes No in Available box we cant edit or type the box (we not enabled)




            con.Close();
            }

        private void txtCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new SqlCommand("select * from Customer where custId = '" + txtCustID.Text + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    txtCustName.Text = dr["custName"].ToString();

                }
                else
                {
                    MessageBox.Show("Customer is not found");
                }

                con.Close();

            }
        }

        private void car_Click(object sender, EventArgs e)
        {
            string carid = txtCarId.SelectedItem.ToString();
            string custid = txtCustID.Text;
            string custName = txtCustName.Text;
            string fee = txtFee.Text;
            string Start = txtFrom.Text;
            string Des = txtdes.Text;
            string date = txtDate.Value.Date.ToString("yyyy-MM-dd");
            string Duedate = txtDueDate.Value.Date.ToString("yyyy-MM-dd");
           
            


    sql = "insert into Rentall (Car_Id,Cust_Id,Cust_Name,Fee,In_Date,Due_Data,Start,Destination)values(@Car_Id,@Cust_Id,@Cust_Name,@Fee,@In_Date,@Due_Data,@Start,@Destination)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Car_Id", carid);  // qs
            cmd.Parameters.AddWithValue("@Cust_Id", custid);
            cmd.Parameters.AddWithValue("@Cust_Name", custName);
            cmd.Parameters.AddWithValue("@Fee", fee);
            cmd.Parameters.AddWithValue("@In_Date", date);
            cmd.Parameters.AddWithValue("@Due_Data", Duedate);
            cmd.Parameters.AddWithValue("@Start", Start);
            cmd.Parameters.AddWithValue("@Destination", Des);




            cmd.ExecuteNonQuery();
            MessageBox.Show("Record successfully");

            sql1 = "update CarRegg set Available = 'No' where Reg_no = @Reg_no";
            
            cmd1 = new SqlCommand(sql, con);
            cmd1.Parameters.AddWithValue("@Reg_no", carid);
            
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Record successfully");

            con.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textRefresh_Click(object sender, EventArgs e)
        {
            Rentalload();
            
            txtFee.Clear();
            txtCustID.Clear();
            txtFrom.Clear();
            txtdes.Clear();
            txtCustName.Clear();
            txtFee.Focus();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    } }

