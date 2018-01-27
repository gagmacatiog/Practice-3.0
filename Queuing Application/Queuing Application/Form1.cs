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
        private static int Servicing_Office = 1;
        private String connection_string = System.Configuration.ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        internal static int newID;
        private int tickTime;
        private Label[] sb = new Label[7];
        private Label[] qb = new Label[7];
        public Form1()
        {
            newID = 0;
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
            sb[0] = this.s1;    qb[0] = this.q1;
            sb[1] = this.s2;    qb[1] = this.q2;
            sb[2] = this.s3;    qb[2] = this.q3;
            sb[3] = this.s4;    qb[3] = this.q4;
            sb[4] = this.s5;    qb[4] = this.q5;
            sb[5] = this.s6;    qb[5] = this.q6;
            sb[6] = this.s7;    qb[6] = this.q7;

            Queue_Info_Update();

        }
        private int return_transaction_type_offices_count(SqlConnection con, int q_tt) {
            String query6 = "select Pattern_Max from Transaction_Type where id = @q_tt";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@q_tt", q_tt);
            int c = 0;
            SqlDataReader rdr3;
            cmd6.Parameters.AddWithValue("@sn", Servicing_Office);
            rdr3 = cmd6.ExecuteReader();
            while (rdr3.Read()) { c = (int)rdr3["Pattern_Max"]; }
            return c;
        }
        private void new_transaction_queue(SqlConnection con, int q_tt) {
            String query5 = "insert into Queue_Transaction (Main_Queue_ID,Pattern_No,Servicing_Office) values (@q_mid,@q_pn,@sn)";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.Parameters.AddWithValue("@q_mid", newID);
            cmd5.Parameters.AddWithValue("@sn", Servicing_Office);
            //loop -- how many servicing offices
            int c = 0;
            for (int x = 0; x < (return_transaction_type_offices_count(con, q_tt)); x++)
            {
                c++;
                cmd5.Parameters.AddWithValue("@q_pn", c);
                cmd5.ExecuteNonQuery();
            }
            c = 0;
            
        }
        private int return_on_queue(SqlConnection con) {
            int a = 0;
            String query4 = "select count(*) as a from Main_Queue where Servicing_Office = @sn";
            SqlCommand cmd3 = new SqlCommand(query4, con);
            SqlDataReader rdr2;
            cmd3.Parameters.AddWithValue("@sn", Servicing_Office);
            rdr2 = cmd3.ExecuteReader();
            while (rdr2.Read()) { a = (int)rdr2["a"]; }
            //execute return_total_queue
            return a;
        }
        private void incrementQueueNumber(SqlConnection con, int res, int q_so) {
            // increment queue number 
            SqlCommand cmd4;
            String query2 = "update Queue_Info set Current_Queue = @n_cq where Servicing_Office = @Servicing_Office";
            cmd4 = new SqlCommand(query2, con);
            cmd4.Parameters.AddWithValue("@n_cq", (res + 1));
            cmd4.Parameters.AddWithValue("@Servicing_Office", q_so);
            cmd4.ExecuteNonQuery();
        }
        private int getQueueNumber(SqlConnection con, int q_so) {
            // retrieves queue number
            int res=0;

            SqlCommand cmd3;
            String query = "select Current_Queue from Queue_Info where Servicing_Office = @Servicing_Office";
            cmd3 = new SqlCommand(query, con);
            cmd3.Parameters.AddWithValue("@Servicing_Office", q_so);
            SqlDataReader rdr2;
            rdr2 = cmd3.ExecuteReader();
            while (rdr2.Read()) { res = (int)rdr2["Current_Queue"];}
            Console.Write("--RETURNING-> getQueueNumber[" + res + "]");
            incrementQueueNumber(con,res,q_so);
            return res;
        }
        private void Queue_Info_Update() {
            //Checks whether Queue_Info is available.
            //Writes default data.
            //Always executed when a Kiosk have been opened.
            
            SqlConnection con = new SqlConnection(connection_string);
            using (con)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd2.CommandType = CommandType.Text;

                String query = "select * from Queue_Info where Servicing_Office = @Servicing_Office";
                String query2 = "";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Servicing_Office", Servicing_Office);

                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                int rowCount = 0;
                while (rdr.Read())
                { rowCount++; { if (rowCount > 0) { break; } } }
                if (rowCount > 0)
                {
                    string Current_Number = rdr["Current_Number"].ToString();
                    string Status = rdr["Status"].ToString();
                    MessageBox.Show(Status+" already");
                }
                else
                {
                    query2 = "insert into Queue_Info (Current_Number,Current_Queue,Servicing_Office,Mode,Status,Counter) values (@cn,@cq,@so,@m,@sn,@c)";
                    cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@cn", 1);
                    cmd2.Parameters.AddWithValue("@cq", 1);
                    cmd2.Parameters.AddWithValue("@so", Servicing_Office);
                    cmd2.Parameters.AddWithValue("@m", 1);
                    cmd2.Parameters.AddWithValue("@sn", "Online");
                    cmd2.Parameters.AddWithValue("@c", "0");
                    int result = cmd2.ExecuteNonQuery();
                }

            }
            con.Close();


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
            int x = 0;
            
            label4.Text = DateTime.Now.ToString("h:m:s tt");
            label27.Text = tickTime.ToString();
            tickTime++;
            if (tickTime == 50)
            {
                SqlConnection con = new SqlConnection(connection_string);
                tickTime = 0;
                x = 0;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd2.CommandType = CommandType.Text;
                    String query = "select Queue_Number,Type,Student_No from (select TOP 7 Queue_Number, Type, Student_No from Main_Queue where Servicing_Office = @Servicing_Office order by Queue_Number desc) temp_n order by Queue_Number asc";
                    
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Servicing_Office", Servicing_Office);
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // get the results of each column
                        // string id = (string)rdr["id"];
                        string qn = rdr["Queue_Number"].ToString();
                        string type = ((Boolean)rdr["Type"] == false) ? "Student" : "Guest";
                        string s_id = (string)rdr["Student_No"];

                        qb[x].Text = qn;
                        if (type == "Student") { sb[x].Text = s_id; }
                        else { sb[x].Text = type; }
                        x++;

                    }

                    //cmd3.CommandText = "return_total_queue";
                    //cmd3.CommandType = CommandType.StoredProcedure;
                    //cmd3.Parameters.AddWithValue("ServicingOffice", Servicing_Office);
                    //cmd3.Connection = con;
                    //rdr2 = cmd3.ExecuteReader();
                    //while (rdr2.Read()) { label29.Text =  rdr2["a"].ToString();}
                    label29.Text = return_on_queue(con).ToString();
                    
                }
                con.Close();



            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            guestPanel.Show();
            gtextBox2.Clear();
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
            textBox1.Clear();
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
                    //try
                    //{
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

                            int c = getQueueNumber(con, Servicing_Office);
                            String query2 = "insert into Main_Queue (Queue_Number,Full_Name,Servicing_Office,Student_No,Transaction_Type,Type,Time,Pattern_Current) OUTPUT Inserted.Queue_Number";
                            query2 += " values (@q_qn,@q_fn,@q_so,@q_sn,@q_tt,0,GETDATE(),@q_pc)";

                            cmd2 = new SqlCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@q_qn", c);
                            cmd2.Parameters.AddWithValue("@q_fn", fullname);
                            cmd2.Parameters.AddWithValue("@q_so", Servicing_Office);
                            cmd2.Parameters.AddWithValue("@q_sn", textBox1.Text);
                            cmd2.Parameters.AddWithValue("@q_tt", comboBox1.SelectedValue);
                            cmd2.Parameters.AddWithValue("@q_pc", 1);
                            Console.Write("--INSERTING TO Main_Queue--");
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

                    //}
                    //catch (Exception ex)
                    //{
                    //   MessageBox.Show(ex.Message);
                    //}

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
                        int c = getQueueNumber(con, Servicing_Office);
                        SqlCommand cmd = con.CreateCommand();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd2.CommandType = CommandType.Text;
                        textBox1.Text=gtextBox2.Text;
                        String query2 = "insert into Main_Queue (Queue_Number,Full_Name,Servicing_Office,Student_No,Transaction_Type,Type,Time,Pattern_Current) OUTPUT Inserted.Queue_Number";
                        query2 += " values (@q_qn,@q_fn,@q_so,@q_sn,@q_tt,1,GETDATE(),@q_pc)";

                        cmd2 = new SqlCommand(query2, con);
                        cmd2.Parameters.AddWithValue("@q_qn", c);
                        cmd2.Parameters.AddWithValue("@q_fn", gtextBox2.Text);
                        cmd2.Parameters.AddWithValue("@q_so", Servicing_Office);
                        cmd2.Parameters.AddWithValue("@q_sn", "N/A");
                        cmd2.Parameters.AddWithValue("@q_tt", gcomboBox2.SelectedValue);
                        cmd2.Parameters.AddWithValue("@q_pc", 1);
                        Console.Write("--INSERTING TO Main_Queue--");
                        newID = (int)cmd2.ExecuteScalar();
                        new_transaction_queue(con, (int)gcomboBox2.SelectedValue);
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
            if (textBox1.Text != ""|| gtextBox2.Text != "")
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
