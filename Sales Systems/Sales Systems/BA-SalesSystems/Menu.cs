using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA_SalesSystems
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        // Logout Btn
        private void button6_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Create Sales Order Btn
        private void button2_Click(object sender, EventArgs e)
        {
            CreateSalesOrder cso = new CreateSalesOrder();
            cso.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalesSummaryReport ssr = new SalesSummaryReport();
            ssr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurchasingOrder f1 = new PurchasingOrder();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderDeliveryReq odr = new OrderDeliveryReq();
            odr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeliverStatus ds = new DeliverStatus();
            ds.Show();
            this.Hide();
        }
    }
}
