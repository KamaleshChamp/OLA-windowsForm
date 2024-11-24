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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void car_Click(object sender, EventArgs e)
        {
            Carreg c = new Carreg();
            this.Hide();
            c.Show();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            customer cus = new customer();
            this.Hide();
            cus.Show();
        }

        private void rental_Click(object sender, EventArgs e)
        {
            RentalBooking book = new RentalBooking();
            this.Hide();
            book.Show();
        }
    }
}
