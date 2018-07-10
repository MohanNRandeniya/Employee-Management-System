using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeM
{
    class TextAnim
    {




        string Text;
        Label lbl;
        int k = 0;
        int r = 0;
        Panel line;
        int unit;
        int end;
        int delay;

        public TextAnim(string Text, Label lbl,Panel line,int unit,int delay) 
        {

            this.Text = Text;
            this.lbl = lbl;
            this.line = line;
            this.unit = unit;
            this.end = line.Width;
            this.delay = delay;
            


        
        }


        public void  Start()
        {

           


            foreach(char c in Text)
            {
                k++;
            }

            //int width = line.Width;
            //unit = width / k;
            line.Width = 0;

            Timer t = new Timer();
            t.Interval = delay;
            t.Tick += new EventHandler(addr);

            t.Start();
         //  MessageBox.Show("count"+unit);
            
    
    
        }

        private void addr(object sender, EventArgs e)
        {
            string l="";
          // MessageBox.Show("count" + k);
            if (r < k)
            {

                l = Convert.ToString(Text[r]);
            }

         
                lbl.Text += l;
                r++;

           
           

            if (line.Width == end)
            {
               
                ((Timer)sender).Stop();

            }
            else 
            {
                if ((end - line.Width) < unit)
                {
                    line.Width = end;

                }
                else 
                {

                    line.Width += unit;
                
                }
                
               
            }
           
        }










    }
}
