using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Queuing_Application
{
    public partial class Form1 : Form
    {
        int PW;
        bool Hided, qHided, gHided;
        SqlConnection con = new SqlConnection(@"Data Source=GEORGE-PC;Initial Catalog=practice-1.0;Persist Security Info=True;User ID=sa;Password=123456");
        public Form1()
        {
            InitializeComponent();
            PW = panel1.Width;
            comboBox1.Items.Insert(0, "Transaction Code");
            comboBox1.SelectedIndex = 0;
            comboBox1.ForeColor = Color.Silver;
            studentPanel.Visible = false;
            guestPanel.Visible = false;
            Hided = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(qHided == true)
            {
                timer2.Start();
                this.sidebar_minimize();
            }
            else if(gHided == true)
            {
                timer3.Start();
                this.sidebar_minimize();
            }
            else
            {
                if (Hided == false)
                {
                    this.sidebar_minimize();
                    Hided = true;
                }
                else
                {
                    timer1.Start();
                    Hided = false;
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Show();
            panel1.Width = panel1.Width + 10;
            if(panel1.Width >= PW)
            {
                timer1.Stop();
            }

        }

        private void sidebar_minimize()
        {
            pictureBox1.Hide();
            panel1.Width = 47;
            panel1.Show();
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            guestPanel.Show();

            if (gHided == false)
            {
                guestPanel.Width = guestPanel.Width + 30;

                if (guestPanel.Width >= 250)
                {
                    timer3.Stop();
                    button2.BackColor = Color.Gray;
                    gHided = true;
                }
            }
            else
            {
                guestPanel.Width = guestPanel.Width - 30;

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
                studentPanel.Width = studentPanel.Width + 30;

                if (studentPanel.Width >= 250)
                {
                    timer2.Stop();
                    button1.BackColor = Color.Gray;
                    qHided = true;
                }
            }
            else
            {
                studentPanel.Width = studentPanel.Width - 30;

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
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into queuelist (name,transaction_code) values('" + textBox1.Text + "','"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("success!!");
        }

        private void guestSubmit_Click(object sender, EventArgs e)
        {

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
