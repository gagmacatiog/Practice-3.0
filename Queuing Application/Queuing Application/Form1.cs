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
        private bool qHided, gHided;
        private DateTime thisday = DateTime.Today;
        private int newID = 0;
        private String connection_string = System.Configuration.ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            //PW = panel1.Width;
            comboBox1.ForeColor = Color.Silver;
            gcomboBox2.ForeColor = Color.Silver;
            studentPanel.Visible = false;
            guestPanel.Visible = false;
            timer1.Start();
            label5.Text = DateTime.Now.ToString("d");
            label16.Text = "4 : 00 PM     " + DateTime.Now.ToString("d");
            num2down2.Text = "4 : 00 PM     " + DateTime.Now.ToString("d");
            //Hided = true;
            //this.sidebar_minimize();
            SqlConnection con = new SqlConnection(connection_string);
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
                SqlConnection con = new SqlConnection(connection_string);
                using (con)
                {
                    int count = 0;
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd2.CommandType = CommandType.Text;
                        String query = "select Fullname, StudentNo from vw_es_students where StudentNo = '" + textBox1.Text + "'";
                        String fullname = "";
                        cmd = new SqlCommand(query, con);
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            count += 1;
                            fullname = dr.GetString(0);
                        }
                        if (count == 1)
                        {

                            String query2 = "insert into Queue_WalkIn (Full_Name,Type,Student_No,Transaction_Type,Date) OUTPUT Inserted.id ";
                            query2 += "values ('" + fullname + "','Student','" + textBox1.Text + "','" + comboBox1.SelectedValue + "',GETDATE())";
                            cmd2 = new SqlCommand(query2, con);
                            newID = (int)cmd2.ExecuteScalar();
                            Form2 f2 = new Form2();
                            f2.Show();
                            con.Close();
                            textBox1.Clear();
                            timer2.Start();

                        }
                        else
                        {
                            MessageBox.Show("Student ID not found.");
                        }
                        //Clear Value

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
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
                SqlConnection con = new SqlConnection(connection_string);
                using (con)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd2.CommandType = CommandType.Text;

                        String query2 = "insert into Queue_WalkIn (Full_Name,Type,Student_ID,Transaction_Type,Date) OUTPUT Inserted.id ";
                        query2 += "values ('" + gtextBox2.Text + "','Guest',' ','" + gcomboBox2.SelectedValue + "',GETDATE())";
                        cmd2 = new SqlCommand(query2, con);
                        newID = (int)cmd2.ExecuteScalar();
                        Form2 f2 = new Form2();
                        f2.Show();
                        con.Close();

                        //Clear Value
                        gtextBox2.Clear();
                        timer3.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

            else
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usep_queueDataSet.Transaction_Type' table. You can move, or remove it, as needed.
            this.transaction_TypeTableAdapter.Fill(this.usep_queueDataSet.Transaction_Type);

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
