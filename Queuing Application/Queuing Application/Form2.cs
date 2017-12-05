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
            label4.Text = Form1.newID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
