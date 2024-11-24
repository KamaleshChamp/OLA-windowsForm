using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace olaa_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usertext.Clear();
            Passtext.Clear();
            usertext.Focus();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string uname = usertext.Text;
            string pass = Passtext.Text;
            
            if(uname.Equals("kamalesh") && pass.Equals("champ"))
            {

                Main m = new Main();
                this.Hide();
                m.Show();
            }
            else
            {

                MessageBox.Show("Please cheak the Username and Password");
                usertext.Clear();
                Passtext.Clear();
                usertext.Focus();
            }
               

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
