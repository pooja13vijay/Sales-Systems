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
    public partial class SalesSummaryReport : Form
    {
        // Datatable Objects
        //************************************************
        DataTable OrderRefDatatable2 = new DataTable();
        //************************************************

        // Locate to the path of the database files. Ignore the "Database Backup" file.
        //*************************************************************************************
        string path = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\";
        //*************************************************************************************

        public SalesSummaryReport()
        {
            InitializeComponent();
        }

        private void SalesSummaryReport_Load(object sender, EventArgs e)
        {
            // ORDER REF TABLE 2 HEADER
            OrderRefDatatable2.Columns.Add("OrderID", typeof(string));
            OrderRefDatatable2.Columns.Add("CustID", typeof(string));
            OrderRefDatatable2.Columns.Add("CustName", typeof(string));
            OrderRefDatatable2.Columns.Add("Amount (RM)", typeof(double));
            OrderRefDatatable2.Columns.Add("Order Date", typeof(string));

            // ORDER REF TABLE DATA
            //------------------------------------------
            // Reassignments / reuse variables
            string[] raw_text = System.IO.File.ReadAllLines(path + "OrderRefTable2.csv");
            string[] data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                OrderRefDatatable2.Rows.Add(data_col);
            }
            dataGridView1.DataSource = OrderRefDatatable2;

            // Calculate grand total
            //********************************************************
            if (dataGridView1.RowCount > 0)
            {
                double accum = 0;
                double temp = 0;
                for (int i = 0; i <= dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        temp = (double)dataGridView1.Rows[i].Cells[3].Value;
                    }

                    accum = accum + temp;
                }
                label2.Text = "Total sales of today: RM " + accum;
            }
            //********************************************************
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
