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
    public partial class PurchasingOrder : Form
    {
        //create db object
        DataTable ReqDatatable = new DataTable();
        DataTable ProdDatatable = new DataTable();

        //path to db
        string path = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\";

        public PurchasingOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //header for the table (hardcoded)
            //Requestor
            ReqDatatable.Columns.Add("ID", typeof(string));
            ReqDatatable.Columns.Add("Name", typeof(string));

            //Product
            ProdDatatable.Columns.Add("Product ID", typeof(string));
            ProdDatatable.Columns.Add("Product Model", typeof(string));
            ProdDatatable.Columns.Add("Qty Left", typeof(int));
            ProdDatatable.Columns.Add("Unit Price (RM)", typeof(double));

            //*****************************REQUESTOR*********************************
            string[] raw_text = System.IO.File.ReadAllLines(path + "Requestor.csv");
            string[] data_col = null; //empty array
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                ReqDatatable.Rows.Add(data_col);
            }
            dataGridView1.DataSource = ReqDatatable;

            //*****************************PRODUCT*********************************
            raw_text = System.IO.File.ReadAllLines(path + "ProductTable.csv");
            data_col = null; //empty array
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                ProdDatatable.Rows.Add(data_col);
            }
            dataGridView2.DataSource = ProdDatatable;

        }

        private void labelVendorName_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //***************************************Product Table*************************************************
        private void butSave_Click(object sender, EventArgs e)
        {
            //Save to csv

            TextWriter writer = new StreamWriter(path + "ProductTable.csv");

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) //-1 to get rid of adding row. or uncheck adding row then remove
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (j == 3) //to check on the columns avoid comma at the end
                    {
                        writer.Write(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dataGridView2.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
            MessageBox.Show("Product Updated");


        }//end of save

        //*****************************Requestor Table*********************************************
        private void btnSave_Click(object sender, EventArgs e)
        {
            //saving the requestor csv file
            TextWriter writer = new StreamWriter(path + "Requestor.csv");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) //-1 to get rid of adding row. or uncheck adding row then remove
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 1) //to check on the columns avoid comma at the end
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
            MessageBox.Show("Requestor Updated!!");
        }

        //-----------------------To get the value in the numericUpDown box----------------------
        int quantityToAdd = 0; //to initialize the value of qtt 
        private void numericQtt_ValueChanged(object sender, EventArgs e)
        {
            quantityToAdd = (int)numericQtt.Value;
        }


        //----------------------Add to new stocks and save it in the csv file--------------------
        int initialValue = 0; // to initialize the current value in stocks
        DateTime orderTime = DateTime.Now; //initialize time and date

        private void btnTest_Click(object sender, EventArgs e)
        {
            //to add the new amount to the current stock
            initialValue = (int)dataGridView2.SelectedRows[0].Cells[2].Value;
            dataGridView2.SelectedRows[0].Cells[2].Value = initialValue + quantityToAdd;



            //to write to csv
            TextWriter writer = new StreamWriter(path + "ProductTable.csv");
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) //-1 to get rid of adding row. or uncheck adding row then remove
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (j == 3) //to check on the columns avoid comma at the end
                    {
                        writer.Write(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dataGridView2.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
            //prints quantity added, item, requestor, date, and time
            MessageBox.Show("Product Ordered!\n\n" + quantityToAdd + " " + dataGridView2.SelectedRows[0].Cells[1].Value.ToString() + " Added To Stocks\n\nPerformed by: " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "\nDate: " + orderTime.ToShortDateString() + "\nTime: " + orderTime.ToShortTimeString());
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSalesOrder cso = new CreateSalesOrder();
            cso.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
