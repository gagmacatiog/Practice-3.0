using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Queuing_Application
{
    public partial class Form1 : Form
    {
        bool qHided, gHided;
        DateTime thisday = DateTime.Today;
        SqlConnection con = new SqlConnection(@"Data Source=GEORGE-PC;Initial Catalog=practice1.0;Persist Security Info=True;User ID=sa;Password=123456");
        public Form1()
        {
            InitializeComponent();
            //PW = panel1.Width;
            comboBox1.Items.Insert(0, "Transaction Code");
            comboBox1.SelectedIndex = 0;
            comboBox1.ForeColor = Color.Silver;
            gcomboBox2.Items.Insert(0, "Transaction Code");
            gcomboBox2.SelectedIndex = 0;
            gcomboBox2.ForeColor = Color.Silver;
            studentPanel.Visible = false;
            guestPanel.Visible = false;
            timer1.Start();
            label5.Text = DateTime.Now.ToString("d");
            label16.Text = "4 : 00 PM     " + DateTime.Now.ToString("d");
            num2down2.Text = "4 : 00 PM     " + DateTime.Now.ToString("d");
            //Hided = true;
            //this.sidebar_minimize();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (guestPanel.Visible.Equals(true))
            {
                timer3.Start();
                timer2.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeUpdate();
        }

        private void timeUpdate()
        {
            label4.Text = DateTime.Now.ToString("h:m:s tt");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            guestPanel.Show();

            if (gHided == false)
            {
                guestPanel.Width = guestPanel.Width + 25;

                if (guestPanel.Width >= 250)
                {
                    timer3.Stop();
                    button2.BackColor = Color.Gray;
                    gHided = true;
                }
            }
            else
            {
                guestPanel.Width = guestPanel.Width - 25;

                if (guestPanel.Width <= 0)
                {
                    timer3.Stop();
                    button2.BackColor = Color.FromArgb(21, 21, 21);
                    gHided = false;
                    guestPanel.Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (studentPanel.Visible.Equals(true))
            {
                timer2.Start();
                timer3.Start();
            }
            else
            {
                timer3.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            studentPanel.Show();

            if (qHided == false)
            {
                studentPanel.Width = studentPanel.Width + 25;

                if (studentPanel.Width >= 250)
                {
                    timer2.Stop();
                    button1.BackColor = Color.Gray;
                    qHided = true;
                }
            }
            else
            {
                studentPanel.Width = studentPanel.Width - 25;

                if (studentPanel.Width <= 0)
                {
                    timer2.Stop();
                    button1.BackColor = Color.FromArgb(21, 21, 21);
                    qHided = false;
                    studentPanel.Visible = false;
                }
            }
            
        }

        //Submit Data

        private void studentSubmit_Click(object sender, EventArgs e)
        {
            if (checkFields() == true)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Main_Queue (Student_ID,user_queue_ID,Service_Office,Status) values('" + textBox1.Text + "','', '" + comboBox1.SelectedIndex + "', 'Student')";
                cmd.ExecuteNonQuery();
                con.Close();

                Form2 f2 = new Form2();
                f2.ShowDialog();

                //Clear Value
                textBox1.Clear();
                comboBox1.SelectedIndex = 0;

                timer2.Start();
            }
            else
            {
                MessageBox.Show("Please Fill up the Form!");
            }
        }

        private void guestSubmit_Click(object sender, EventArgs e)
        {
            if (checkFields() == true)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Main_Queue (Student_ID,user_queue_ID,Service_Office,Status) values('" + gtextBox2.Text + "','', '" + gcomboBox2.SelectedIndex + "', 'Walk-In')";
                cmd.ExecuteNonQuery();
                con.Close();

                Form2 f2 = new Form2();
                f2.ShowDialog();

                //Clear Value
                gtextBox2.Clear();
                gcomboBox2.SelectedIndex = 0;

                timer3.Start();
            }else
            {
                MessageBox.Show("Please Fill up the Form!");
            }
        }

        private bool checkFields()
        {
            if (textBox1.Text != "" && comboBox1.SelectedIndex != 0 || gtextBox2.Text != "" && gcomboBox2.SelectedIndex != 0)
            {
                return true;
            }

            return false;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }


        //Textbox effects

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                if (((TextBox)sender).Text == "ID Number" || ((TextBox)sender).Text == "Guest Name")
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).ForeColor = Color.Black;
                }
            }
            else if (sender.GetType().Name == "ComboBox")
            {
                if(((ComboBox)sender).Text == "Transaction Code")
                {
                    ((ComboBox)sender).Text = "";
                    ((ComboBox)sender).ForeColor = Color.Black;
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                if (((TextBox)sender).Text == "")
                {
                    if (((TextBox)sender).Name == "textBox1")
                    {
                        ((TextBox)sender).Text = "ID Number";
                    }
                    else
                    {
                        ((TextBox)sender).Text = "Guest Name";
                    }
                    ((TextBox)sender).ForeColor = Color.Silver;
                }
                
            }
            else if (sender.GetType().Name == "ComboBox")
            {
                if(((ComboBox)sender).Text == "")
                {
                    ((ComboBox)sender).Text = "Transaction Code";
                    ((ComboBox)sender).ForeColor = Color.Silver;
                }
            }
        }
    }
}
