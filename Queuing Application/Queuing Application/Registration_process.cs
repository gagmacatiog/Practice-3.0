using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Queuing_Application
{
    class Registration_process
    {
        //decalre properties 
        public string Username { get; set; }
        public string Userpassword { get; set; }
        public string UserfirstName { get; set; }
        public string UsermiddleName { get; set; }
        public string UserlastName { get; set; }
        public string Usertype { get; set; }

        //intialise  
        public Registration_process(string user, string pass, string fname, string mname, string lname, string type)
        {
            this.Username = user;
            this.Userpassword = pass;
            this.UserfirstName = fname;
            this.UsermiddleName = mname;
            this.UserlastName = lname;
            this.Usertype = type;
        }
        //validate string 
        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //validate integer 
        private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //clear user inputs 
        private void ClearTexts(string user, string pass, string fname, string mname, string lname, string type)
        {
            user = String.Empty;
            pass = String.Empty;
            fname = String.Empty;
            mname = String.Empty;
            lname = String.Empty;
            type = String.Empty;
        }
        //method to check if eligible to be logged in 
        internal bool IsLoggedIn(string user, string pass, string fname, string mname, string lname, string type)
        {
            //check user name empty 
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Enter the user name!");
                return false;

            }
            //check user name is valid type 
            else if (StringValidator(user) == true)
            {
                MessageBox.Show("Enter only text here");
                ClearTexts(user, pass, fname, mname, lname, type);
                return false;
            }
            //check user name is correct 
            else
            {
                if (Username != user)
                {
                    MessageBox.Show("User name is incorrect!");
                    ClearTexts(user, pass, fname, mname, lname, type);
                    return false;
                }
                //check password is empty 
                else
                {
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Enter the passowrd!");
                        return false;
                    }
                    //check password is valid 
                    else if (IntegerValidator(pass) == true)
                    {
                        MessageBox.Show("Enter only integer here");
                        return false;
                    }
                    //check password is correct 
                    else if (Userpassword != pass)
                    {
                        MessageBox.Show("Password is incorrect");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
