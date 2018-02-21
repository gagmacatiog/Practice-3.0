using System;
using System.Windows.Forms;

namespace Queuing_Application
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs 
            string user = txtUsername.Text;
            string pass = txtPassword.Text;


            Login_process login = new Login_process("admin", "1234");
            //check if eligible to be logged in 
            if (login.IsLoggedIn(user, pass))
            {
                MessageBox.Show("You are logged in successfully");
            }
            else
            {
                //show default login error message 
                MessageBox.Show("Login Error!");
            }
        }

        private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //enter your code for forget password case 
            MessageBox.Show("Under development");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
    