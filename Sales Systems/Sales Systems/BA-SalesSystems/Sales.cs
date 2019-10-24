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
    public partial class Sales : Form
    {
        int faildAttempts = 0;
        string[] ids = new string[5] { "kiriel", "bryan", "joseph", "pooja", "bobby" };
        string[] pws = new string[5] { "kiriel", "bryan", "joseph", "pooja", "bobby" };

        public Sales()
        {
            InitializeComponent();

            // Prevent users from resizing the window
            //FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        // Login Btn
        private void button2_Click(object sender, EventArgs e)
        {
            faildAttempts = faildAttempts + 1;
            if (faildAttempts >= 5)
            {
                MessageBox.Show("Error! You have failed to login for 5 times.");
                this.Close();
            }
            else
            {
                for (int x = 0; x <= 4; x++)
                {
                    if (UserName.Text == ids[x] && Password.Text == pws[x])
                    {

                        Menu menu = new Menu();
                        menu.Show();
                        this.Hide();
                        
                        /*
                        Form2 f2 = new Form2();
                        this.Visible = false;
                        f2.Visible = true;
                        */

                    }
                    else
                    {
                        //label2.Font = new Font(label2.Font, label2.Font.Style ^ FontStyle.Bold);
                        label2.ForeColor = System.Drawing.Color.Red;
                        label2.Text = "Wrong username or password!";

                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Quit Btn
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordShowText_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordShowText.Checked == true)
            {
                Password.PasswordChar = '\0';
            }
            else
            {
                Password.PasswordChar = '*';
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
