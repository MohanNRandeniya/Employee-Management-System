using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeM
{
    
    public class validation
    {
        public Control.ControlCollection controls;



        public void clearText(Panel pnlForm)
        {

            foreach (Control c in pnlForm.Controls)
                

                    if ((string)c.Tag == "text")
                    {
                        MessageBox.Show("");
                        ((TextBox)c).Text = "";

                    }
            
        }

       public bool isEmpty(Panel pnl)
        {
            bool status = false;
            foreach (Control c in pnl.Controls)
                if (c.GetType() == typeof(TextBox))
                {

                    if ((string)c.Tag == "text" && (((TextBox)c).Text).Equals(""))
                    {
                        status = true;
                    }

                }
            
            return status;
        }

        public int IsValidEmail(string email)
        {
            int count = 0;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                MessageBox.Show(email + " is correct");
                count = 0;
            }

            else
            {
                MessageBox.Show(email + " is incorrect");
                count++;
            }

            return count;

        }


       public int charValidate(string name)
       {
           int count = 0;
            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            Match match = regex.Match(name);
           if (match.Success)
           {
               MessageBox.Show(name + " is correct");
               count = 0;
           }
           else
           {
               count++;
           }

           return count;
       }

       public int numberValidate(string number)
       {
           int count = 0;
            Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            Match match = regex.Match(number);
            if (match.Success && number.Length == 10)
            {
               // MessageBox.Show(number + " is correct");
                count = 0;
            }
            else
            {
                if (number.Length == 10)
                {
                    MessageBox.Show("meka madi or wadi");
                    count++;
                }

            }

           return count;
       }


    }

    

   
}
