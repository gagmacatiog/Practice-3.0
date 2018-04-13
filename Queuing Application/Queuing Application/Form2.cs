using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queuing_Application
{
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form f = Application.OpenForms["Form1"];
            label1.Text = ((Form1)f).textBox1.Text;
            label4.Text = Form1.shownID.ToString();
            label5.Text = format_estimated_time(Form1.time);
        }
        private string format_estimated_time(double time)
        {
            string a = "";
            var minutes = Math.Floor((time / 60));
            var seconds = time - minutes * 60;
            if (minutes > 0)
            {
                if (minutes == 1)
                {
                    a = minutes + " minute and ";
                }
                else
                {
                    a = minutes + " minutes and ";
                }
            }
            if (seconds >= 2)
                a += seconds + " seconds";
            else
                a += seconds + " second";
            
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
