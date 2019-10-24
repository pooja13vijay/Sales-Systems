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
    public partial class DeliverStatus : Form
    {
        DataTable DeliveryStatusdatatable = new DataTable();

        string path = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\";

        int index;

        public DeliverStatus()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DeliverStatus_Load(object sender, EventArgs e)
        {
            DeliveryStatusdatatable.Columns.Add("CustID", typeof(string));
            DeliveryStatusdatatable.Columns.Add("CustName", typeof(string));
            DeliveryStatusdatatable.Columns.Add("OrderID", typeof(string));
            DeliveryStatusdatatable.Columns.Add("RequestDate", typeof(string));
            DeliveryStatusdatatable.Columns.Add("OrderStatus", typeof(string));
            DeliveryStatusdatatable.Columns.Add("DeliveryStatus", typeof(string));

            //Read customer data from CSV
            string[] raw_text = System.IO.File.ReadAllLines(path + "DeliverStatus.csv");
            string[] data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                DeliveryStatusdatatable.Rows.Add(data_col);
            }
            dataGridView1.DataSource = DeliveryStatusdatatable; //set customer table to be shown in datagridview1
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();
            label7.Text = "Current Status: " + selectedRow.Cells[4].Value.ToString();
            label8.Text = "Current Status: " + selectedRow.Cells[5].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRow newDataRow = dataGridView1.Rows[index];
            newDataRow.Cells[4].Value = comboBox1.Text;
            newDataRow.Cells[5].Value = comboBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Menu ms = new Menu();
            ms.Show();
            this.Close();
        }
    }
}
