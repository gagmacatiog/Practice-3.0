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
    public partial class Form3 : Form
    {
        List<Control> myControls = new List<Control>();
        String pressedButton = "";
        public Form3()
        {
            InitializeComponent();
            myControls.Add(button2);
            myControls.Add(button3);
            myControls.Add(button4);
            myControls.Add(button5);
            myControls.Add(button6);
        }

        private void rate_click(object sender, EventArgs e)
        {
            if (pressedButton != "")
            {
                for (int x = 0; x < myControls.Count; x++)
                {
                    if (myControls[x].Name == pressedButton)
                    {
                        myControls[x].BackColor = Color.Transparent;
                    }
                }
            }

            ((Button)sender).BackColor = Color.BurlyWood;
            pressedButton = ((Button)sender).Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID # or Guest Name")
            {
                MessageBox.Show("Please put ID Number or Guest Name!");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please put ID Number or Guest Name!");
            }else
            {
                switch (pressedButton)
                {
                    case "button2":
                        //MessageBox.Show("Extremely Satisfied");
                        break;

                    case "button3":
                        //MessageBox.Show(" Satisfied");
                        break;

                    case "button4":
                        //MessageBox.Show("Neutral");
                        break;

                    case "button5":
                        //MessageBox.Show("Unsatisfied");
                        break;

                    case "button6":
                       // MessageBox.Show("Extremely Unsatisfied");
                        break;

                    default:
                        MessageBox.Show("Please pick one...");
                        break;
                }

                if (pressedButton != "")
                {
                    MessageBox.Show("Thank you for sending us your feedback! Rest assured that we will improve our services to ensure quality operation. Have a nice day and God bless you.");
                    this.Close();
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
            if (((TextBox)sender).Text == "ID # or Guest Name")
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "ID # or Guest Name";
                ((TextBox)sender).ForeColor = Color.Silver;
            }
        }
    }
}
