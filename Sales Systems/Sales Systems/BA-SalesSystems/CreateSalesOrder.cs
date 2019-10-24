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
    public partial class CreateSalesOrder : Form
    {
        // Datatable Objects
        //************************************************
        DataTable CustDatatable = new DataTable();
        DataTable ProdDatatable = new DataTable();
        DataTable TempOrderDatatable = new DataTable();
        DataTable OrderRefDatatable = new DataTable();
        DataTable InvoiceDatatable = new DataTable();
        //************************************************

        // Locate to the path of the database files. Ignore the "Database Backup" file.
        //*************************************************************************************
        string path = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\";
        string ordersPath = @"C:\Users\Bryan\Desktop\Sales Systems\Databases\OrderTables\";
        //*************************************************************************************

        public CreateSalesOrder()
        {
            InitializeComponent();
        }

        // When form loads
        private void CreateSalesOrder_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized; // Maximize window

            // ALL DATA_GRID_VIEW HEADERS
            //*******************************************************************
            // CUSTOMER TABLE HEADER
            CustDatatable.Columns.Add("CustID", typeof(string));
            CustDatatable.Columns.Add("CustName", typeof(string));
            CustDatatable.Columns.Add("CustType", typeof(string));
            CustDatatable.Columns.Add("Credit Limit (RM)", typeof(double));
            CustDatatable.Columns.Add("CustPhone", typeof(string));
            CustDatatable.Columns.Add("CustEmail", typeof(string));
            CustDatatable.Columns.Add("CustAddress", typeof(string));

            // PRODUCT TABLE HEADER
            ProdDatatable.Columns.Add("ProdID", typeof(string));
            ProdDatatable.Columns.Add("ProdModel", typeof(string));
            ProdDatatable.Columns.Add("QtyLeft", typeof(int));
            ProdDatatable.Columns.Add("Unit Price (RM)", typeof(double));

            // TEMP ORDER TABLE HEADER
            TempOrderDatatable.Columns.Add("ProdID", typeof(string));
            TempOrderDatatable.Columns.Add("ProdModel", typeof(string));
            TempOrderDatatable.Columns.Add("QtyTaken", typeof(int));
            TempOrderDatatable.Columns.Add("Unit Price (RM)", typeof(double));
            TempOrderDatatable.Columns.Add("Remarks", typeof(string));

            // ORDER REF TABLE HEADER
            OrderRefDatatable.Columns.Add("OrderID", typeof(string));
            OrderRefDatatable.Columns.Add("CustID", typeof(string));
            OrderRefDatatable.Columns.Add("CustName", typeof(string));
            OrderRefDatatable.Columns.Add("Payment Method", typeof(string));
            OrderRefDatatable.Columns.Add("Order Date", typeof(string));

            // INVOICE TABLE HEADER
            InvoiceDatatable.Columns.Add("ProdID", typeof(string));
            InvoiceDatatable.Columns.Add("ProdModel", typeof(string));
            InvoiceDatatable.Columns.Add("Qty", typeof(int));
            InvoiceDatatable.Columns.Add("Unit Price (RM)", typeof(double));
            InvoiceDatatable.Columns.Add("Remarks", typeof(string));
            //*******************************************************************
            // END OF ALL DATA_GRID_VIEW HEADERS

            // All DATA_GRID_VIEW DATA
            //************************************************************************************
            // CUSTOMER TABLE DATA
            //------------------------------------------
            string[] raw_text = System.IO.File.ReadAllLines(path + "CustomerTable.csv");
            string[] data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                CustDatatable.Rows.Add(data_col);
            }
            dataGridView1.DataSource = CustDatatable;

            // PRODUCT TABLE DATA
            //------------------------------------------
            // Reassignments / reuse variables
            raw_text = System.IO.File.ReadAllLines(path + "ProductTable.csv");
            data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                ProdDatatable.Rows.Add(data_col);
            }
            dataGridView2.DataSource = ProdDatatable;

            // TEMP ORDER TABLE DATA (EMPTY TABLE)
            //------------------------------------------
            // Reassignments / reuse variables
            raw_text = System.IO.File.ReadAllLines(path + "EmptyTable.csv");
            data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                TempOrderDatatable.Rows.Add(data_col);
            }
            dataGridView4.DataSource = TempOrderDatatable;
            
            // ORDER REF TABLE DATA
            //------------------------------------------
            // Reassignments / reuse variables
            raw_text = System.IO.File.ReadAllLines(path + "OrderRefTable.csv");
            data_col = null;
            foreach (string text_line in raw_text)
            {
                data_col = text_line.Split(',');
                OrderRefDatatable.Rows.Add(data_col);
            }
            dataGridView3.DataSource = OrderRefDatatable;
            //************************************************************************************
            // END OF All DATA_GRID_VIEW DATA

            textBox3.Hide();
            textBox5.Hide();
        }

        // Customer Search Textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(CustDatatable);
            DV.RowFilter = string.Format("CustName LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Product Search Textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(ProdDatatable);
            DV.RowFilter = string.Format("ProdModel LIKE '%{0}%'", textBox2.Text);
            dataGridView2.DataSource = DV;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Save customer btn
        private void button8_Click(object sender, EventArgs e)
        {
            // Save customer to CSV
            //************************************************************************************
            TextWriter writer = new StreamWriter(path + "CustomerTable.csv");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 6)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    } else
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
            MessageBox.Show("Saved!");
            //************************************************************************************
            // End of Save customer to CSV
        }

        // Delete Btn for Customer Table
        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        // Choose product btn
        int index = 0;
        int a = 0;
        int b = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            // Adding in temp order table
            //**********************************************************************************************************************
            if ((int)dataGridView2.SelectedRows[0].Cells[2].Value != 0) // When the Qty isn't equals 0
            { // Keep adding
                TempOrderDatatable.Rows.Add();
                dataGridView4.Rows[index].Cells[0].Value = dataGridView2.SelectedRows[0].Cells[0].Value.ToString(); // ProdID cell
                dataGridView4.Rows[index].Cells[1].Value = dataGridView2.SelectedRows[0].Cells[1].Value.ToString(); // ProdModel cell
                dataGridView4.Rows[index].Cells[2].Value = 1; // Qty cell
                dataGridView4.Rows[index].Cells[3].Value = dataGridView2.SelectedRows[0].Cells[3].Value.ToString(); // Unit Price cell
            } else if ((int)dataGridView2.SelectedRows[0].Cells[2].Value == 0) // When the Qty is equals 0
            { // Stop adding
                dataGridView4.Rows[index].Cells[0].Value = null; // ProdID cell
                dataGridView4.Rows[index].Cells[1].Value = null; // ProdModel cell
                dataGridView4.Rows[index].Cells[2].Value = null; // Qty cell
                dataGridView4.Rows[index].Cells[3].Value = null; // Unit Price cell

                index--;
            }
            //**********************************************************************************************************************
            // End of Adding in temp order table

            // Qty deduction in products table
            //***************************************************************************************************
            a = (int)dataGridView4.Rows[index].Cells[2].Value;
            b = (int)dataGridView2.SelectedRows[0].Cells[2].Value;
            if ((int)dataGridView2.SelectedRows[0].Cells[2].Value != 0) // When the Qty isn't equals 0
            { // Keep deducting
                dataGridView2.SelectedRows[0].Cells[2].Value = b - a;

                if ((int)dataGridView2.SelectedRows[0].Cells[2].Value == 5)
                {
                    dataGridView2.SelectedRows[0].Cells[2].Value = b - a;
                    MessageBox.Show("Low-level of stock!\n" + dataGridView2.SelectedRows[0].Cells[0].Value + " - " + dataGridView2.SelectedRows[0].Cells[1].Value);
                }
            }
            else if ((int)dataGridView2.SelectedRows[0].Cells[2].Value == 0) // When the Qty is equals 0
            { // Stop deducting
                dataGridView2.SelectedRows[0].Cells[2].Value = 0;
                MessageBox.Show("Out of stock!\n" + dataGridView2.SelectedRows[0].Cells[0].Value + " - " + dataGridView2.SelectedRows[0].Cells[1].Value);
            }
            //***************************************************************************************************
            // End of Qty deduction in products table

            index++;
        }

        // Quantity textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Remarks textbox
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Selected rows in Order Ref table
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Generate Order btn
        int index2 = 0;
        int RandNum;
        Random myRand = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            // SAVE THE PRODUCT TABLE
            //************************************************************************************
            TextWriter writer = new StreamWriter(path + "ProductTable.csv");
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (j == 3)
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
            //MessageBox.Show("Products Updated!");
            //************************************************************************************

            if (dataGridView4.Rows[0].Cells[0].Value != null) // if Temp Order contains something
            { // Check if Temp Order table is empty

                // SAVE THE TEMP ORDER TABLE
                //************************************************************************************
                // Check if File already exist (to get unique Random number)
                while (File.Exists(ordersPath + RandNum + " - Order.csv"))
                {
                    // Keep randomizing to get a unique number
                    RandNum = myRand.Next(10000); // 0 - 9999
                }

                // Create & Write into the new CSV File using the unique RandNum
                writer = new StreamWriter(ordersPath + RandNum + " - Order.csv");
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView4.Columns.Count; j++)
                    {
                        if (j == 4)
                        {
                            writer.Write(dataGridView4.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write(dataGridView4.Rows[i].Cells[j].Value.ToString() + ",");
                        }
                    }
                    writer.WriteLine();
                }
                writer.Close();
                MessageBox.Show("Order Successful!");
                //************************************************************************************

                // Generate an OrderRef
                //************************************************************************************
                DateTime myValue = DateTime.Now;
                OrderRefDatatable.Rows.Add();
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Value = RandNum; // OrderID cell
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[1].Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // CustID cell
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[2].Value = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); // CustName cell
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[3].Value = "Unavailable"; // Payment Method cell
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[4].Value = myValue.ToShortDateString(); // Order Date cell
                index2++;
                //************************************************************************************

                // Save or update the OrderRef to CSV
                //************************************************************************************
                writer = new StreamWriter(path + "OrderRefTable.csv");
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.Columns.Count; j++)
                    {
                        if (j == 4)
                        {
                            writer.Write(dataGridView3.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write(dataGridView3.Rows[i].Cells[j].Value.ToString() + ",");
                        }
                    }
                    writer.WriteLine();
                }
                writer.Close();
                //************************************************************************************

                // Clear Temp Order table
                //********************************************************
                if (dataGridView4.RowCount > 0)
                {
                    for (int i = 0; i <= dataGridView4.RowCount; i++)
                    {
                        // Keep on removing the 1st elem as it loops
                        dataGridView4.Rows.RemoveAt(0);
                    }
                    index = 0;
                }
                //********************************************************
            }
            else // if Temp Order empty
            {
                MessageBox.Show("No products keyed in!");
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        // Order Search Textbox
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(OrderRefDatatable);
            DV.RowFilter = string.Format("OrderID LIKE '%{0}%'", textBox4.Text);
            dataGridView3.DataSource = DV;
        }

        // Delete Btn for Temp Order table
        private void button7_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView4.CurrentCell.RowIndex;
            dataGridView4.Rows.RemoveAt(rowIndex);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Invoice Table Cell Click
        double accum = 0;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[index];

            label2.Text = "OrderID - " + selectedRow.Cells[0].Value.ToString();
            label4.Text = "CustID - " + selectedRow.Cells[1].Value.ToString();
            label5.Text = "CustName - " + selectedRow.Cells[2].Value.ToString();
            label6.Text = "Order Date - " + selectedRow.Cells[4].Value.ToString();

            // Clear Invoice table
            //********************************************************
            if (dataGridView5.RowCount > 0)
            {
                for (int i = 0; i <= dataGridView5.RowCount; i++)
                {
                    // Keep on removing the 1st elem as it loops
                    dataGridView5.Rows.RemoveAt(0);
                }
                //index = 0;
            }
            //********************************************************

            string[] raw_text2 = System.IO.File.ReadAllLines(ordersPath + selectedRow.Cells[0].Value.ToString() + " - Order.csv");
            string[] data_col2 = null;
            foreach (string text_line in raw_text2)
            {
                data_col2 = text_line.Split(',');
                InvoiceDatatable.Rows.Add(data_col2);
            }
            dataGridView5.DataSource = InvoiceDatatable;

            // Calculate grand total
            //********************************************************
            if (dataGridView5.RowCount > 0)
            {
                accum = 0;
                double temp = 0;
                for (int i = 0; i <= dataGridView5.RowCount; i++)
                {
                    if (dataGridView5.Rows[i].Cells[3].Value == null)
                    {
                        break;
                    } else
                    {
                        temp = (double)dataGridView5.Rows[i].Cells[3].Value;
                    }
                    
                    accum = accum + temp;
                }
                label7.Text = "Grand Total: RM " + accum;
            }
            //********************************************************
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        // Refresh btn
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Label that displays CustType
            label11.Text = "" + dataGridView1.SelectedRows[0].Cells[2].Value;

            // If its Regular
            if ((string)dataGridView1.SelectedRows[0].Cells[2].Value == "Regular")
            {
                if (comboBox1.Items.Count > 6)
                { // Remove Customer Credit Account payment option
                    comboBox1.Items.RemoveAt(6);
                    label10.Text = "0.00";
                    label9.Text = "0.00";
                }
            } else if ((string)dataGridView1.SelectedRows[0].Cells[2].Value == "Premium" && comboBox1.Items.Count <= 6)
            { // Re-add Customer Credit Account payment option when CustType is premium & at the same time, the option was removed
                comboBox1.Items.Add("Customer Credit Account");
            }

            // If its Premium
            if ((string)dataGridView1.SelectedRows[0].Cells[2].Value == "Premium")
            {
                double diff = 0;
                if (comboBox1.Text == "Customer Credit Account")
                { // When Customer Credit Account is the chosen payment method
                    double credLim = (double)dataGridView1.SelectedRows[0].Cells[3].Value; // get the cust credit limit
                    diff = credLim - accum; // deduct it with the Grand Total

                    // Display them
                    label10.Text = "Remaining Credits: RM " + credLim;
                    label9.Text = "After Deductions: RM " + diff;

                    if (accum > credLim)
                    { // When the credit limit is insufficient, disallow user to use the option
                        //comboBox1.Text = null;
                        textBox5.Show();
                        MessageBox.Show("Insufficient Credit Limit!");

                        double num;
                        double additional;
                        if (double.TryParse(textBox5.Text, out num))
                        {
                            additional = diff + num;
                            label9.Text = "After Deductions: RM " + additional;
                        }
                    }
                    //comboBox2.Text = null;
                }
            }

            if (comboBox1.Text == "Cash")
            {
                textBox3.Show();
                textBox5.Hide();
                label10.Text = "";
                label9.Text = "";
            } else
            {
                textBox3.Hide();
            }
        }

        // Confirm Order Btn
        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt successfully delivered to the designated customer!");
            MessageBox.Show("Account Department Notified!");
        }

        // Pend Order Btn
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Pended! An email of order confirmation acknowledgement has been sent to the customer.");
            MessageBox.Show("Account Department Notified! An invoice will be issued to the customer as soon as possible.");
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Back Btn
        private void button10_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PurchasingOrder po = new PurchasingOrder();
            po.Show();
            this.Hide();
        }
    }
}
