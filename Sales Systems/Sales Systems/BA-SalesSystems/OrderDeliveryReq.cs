using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BA_SalesSystems
{
    public partial class OrderDeliveryReq : Form
    {
        DataTable CustDatatable = new DataTable();
        DataTable OrderDatatable = new DataTable();
        DataTable OrderRefDatatable = new DataTable();
        DataTable InvoiceDatatable = new DataTable();
        DataTable DeliveryReqDatatable = new DataTable();


        string path = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\";
        string ordersPath = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\OrderTables\";


        StreamWriter sw;

        public OrderDeliveryReq()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Load Customer Data Table
            //initialize attributes
            CustDatatable.Columns.Add("CustID", typeof(string));
            CustDatatable.Columns.Add("CustName", typeof(string));
            CustDatatable.Columns.Add("CustType", typeof(string));
            CustDatatable.Columns.Add("Credit Limit (RM)", typeof(string));
            CustDatatable.Columns.Add("CustPhone", typeof(string));
            CustDatatable.Columns.Add("CustEmail", typeof(string));
            CustDatatable.Columns.Add("CustAddress", typeof(string));

            //Load Order Data Table
            //intialize attributes to display in datagrid
            OrderDatatable.Columns.Add("OrderID", typeof(string));
            OrderDatatable.Columns.Add("CustID", typeof(string));
            OrderDatatable.Columns.Add("CustName", typeof(string));
            OrderDatatable.Columns.Add("Payment Method", typeof(string));
            OrderDatatable.Columns.Add("Order Date", typeof(string));

            //Load Table
            InvoiceDatatable.Columns.Add("ProdID", typeof(string));
            InvoiceDatatable.Columns.Add("ProdModel", typeof(string));
            InvoiceDatatable.Columns.Add("Qty", typeof(int));
            InvoiceDatatable.Columns.Add("Unit Price (RM)", typeof(double));
            InvoiceDatatable.Columns.Add("Remarks", typeof(string));


            //Read customer data from CSV
            string[] raw_text = System.IO.File.ReadAllLines(path + "CustomerTable.csv");
            string[] data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                CustDatatable.Rows.Add(data_col);
            }
            dataGridView1.DataSource = CustDatatable; //set customer table to be shown in datagridview1

            //Read Order data from CSV
            string[] raw_text1 = System.IO.File.ReadAllLines(path + "OrderRefTable.csv");
            string[] data_col1 = null;
            foreach (string text_line in raw_text1)
            {
                data_col1 = text_line.Split(',');
                OrderDatatable.Rows.Add(data_col1);
            }
            dataGridView2.DataSource = OrderDatatable;//set order table to be shown in datagridview2

            sw = new StreamWriter(path + "DeliveryReq.csv");
        }

        //search function to search specific cell in the customer table to be shown in datagridview1
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(CustDatatable);
            DV.RowFilter = string.Format("CustName LIKE '%{0}%'", textBox10.Text);
            dataGridView1.DataSource = DV;
        }

        //set when the cell is clicked
        //each value in the cell is set to a separate textbox to be displayed
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox5.Text = selectedRow.Cells[4].Value.ToString();
            textBox6.Text = selectedRow.Cells[5].Value.ToString();
            textBox7.Text = selectedRow.Cells[6].Value.ToString();

        }

        //search function to search specific cell in the customer table to be shown in datagridview2
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(OrderDatatable);
            DV.RowFilter = string.Format("CustID LIKE '%{0}%'", textBox8.Text);
            dataGridView2.DataSource = DV;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //send request button is clicked message box will appear

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product Delivery Request Has Been Sent to Logistic Department!");

            string customerID = textBox1.Text;
            string customerName = textBox2.Text;
            string customerAdd = textBox7.Text;
            string orderID = textBox4.Text;
            string customerPh = textBox5.Text;
            string customerEmail = textBox6.Text;
            string reqStatus = "Requested";



            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", customerID, customerName, customerAdd, orderID, customerPh, customerEmail, reqStatus);

            sw.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            PurchasingOrder f1 = new PurchasingOrder();
            f1.Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            textBox4.Text = selectedRow.Cells[0].Value.ToString();

            //clear table
            if (dataGridView3.RowCount > 0)
            {
                for (int i = 0; i <= dataGridView3.RowCount; i++)
                {
                    dataGridView3.Rows.RemoveAt(0);
                }
            }

            string[] raw_text2 = System.IO.File.ReadAllLines(ordersPath + selectedRow.Cells[0].Value.ToString() + " - Order.csv");
            string[] data_col2 = null;
            foreach (string text_line in raw_text2)
            {
                data_col2 = text_line.Split(',');
                InvoiceDatatable.Rows.Add(data_col2);
            }
            dataGridView3.DataSource = InvoiceDatatable; //set customer table to be shown in datagridview2

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
