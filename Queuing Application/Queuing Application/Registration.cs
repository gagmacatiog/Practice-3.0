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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtPassword.Text;
            string Fname = txtFName.Text;
            string Mname = txtMName.Text;
            string Lname = txtLName.Text;
            string type = ComboBox1.Text;


            Registration_process registration = new Registration_process(username, password, Fname, Mname, Lname, type);

            // Check if user is already registered from database

            if (registration.IsLoggedIn(username, password, Fname, Mname, Lname, type))
            {
                MessageBox.Show("You are logged in successfully");
            }
            else
            {
                //show default login error message 
                MessageBox.Show("Login Error!");
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
