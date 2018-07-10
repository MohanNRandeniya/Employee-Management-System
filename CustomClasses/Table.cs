using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace EmployeeM
{
   public class Table
    {
        //,eka public Korapan
       private int lastPage;
       private int currentPage;
       private int nextPage;
       private int totRows;
       private int totPages;
       private int nextHop;
       private int nextHoptoback;
       private int max;
       private int LastMax;
       private int forwardindex;
       private int best;
       private bool back;
       private List<string> arrayList = new List<string>();
        private List<string> arrayList2 = new List<string>();
        private int[] selected = null;
       private string sel = "";
       private Panel Next = null;
       private Panel Previous = null;
       private Panel TblBg = null;
       private Panel[] pns = null;
       //public CheckBox[] cbs = null;
        public Panel[] selects = null;
       //Table tbl = null;
        private bool image;
        private int coli;
        private string Query="";
        private string quert2="";
        private int rowCount;
        private int numCols=0;
        private Color selectRows;
        private Color baseRow;
        private Color selectSelector;
        private Color baseSelector;
        private string path="";







        public Table(int rowCount, Panel next, Panel previous,Panel tblbg,bool image,int coli,int numCols) 
       {
            
       this.lastPage = 0;
       this.currentPage = 0;
       this.nextPage = 0;
       this.totRows = 0;
       this.totPages = 0;
       this.nextHop = 0;
       this.nextHoptoback = 0;
       this.max = 1;
       this.LastMax = 0;
       this.forwardindex = -1;
       this.best = 0;
       this.back = false;
       this.selected = new int[rowCount];
        this.selects = new Panel[rowCount];
       this.sel = "";
       this.Next = next;
       this.Previous = previous;
       this.TblBg = tblbg;
       this.image = image;
       this.coli = coli;
       this.Query = "";
       this.quert2 = "";
       this.rowCount = rowCount;
        this.numCols = numCols;



       
       
       }




        public void tblTheamSetter(Color selectRows,Color baseRow,Color selectSelector,Color baseSelector)
        {


        this.selectRows = selectRows;
        this.baseRow=baseRow;
        this.selectSelector=selectSelector;
        this.baseSelector=baseSelector;



    }

        public void setPath(string pathp) 
        {
            this.path = pathp;
        }

        public string getSelecdedIds()
        {
            string Ids = null;
            string str = selectRowq();
            string isStr = selectId();
            
            arrayList[currentPage-1] = str;
            arrayList2[currentPage - 1] = isStr;



            foreach (string k in arrayList2)
            {
                Ids += k;

            }
            Ids += "End";
     

            return Ids;

}

        public void setQuery1(string query)
        {
            this.Query = query;

        }
        public void setQuery2(string q2)
        {
            this.quert2 = q2;

        }
       public void setTblRows(Panel r1,Panel r2, Panel r3, Panel r4, Panel r5, Panel r6, Panel r7, Panel r8, Panel r9, Panel r10) 
       {

           this.pns = new Panel[] {r1,r2,r3,r4,r5,r6,r7,r8,r9,r10};
       
       }

        public void setTblRowsImage(Panel r1, Panel r2, Panel r3, Panel r4, Panel r5)
        {

            this.pns = new Panel[] {r1, r2, r3, r4, r5};

        }
       // public void setCBoxs(CheckBox c1, CheckBox c2) 
       //{
       //    this.cbs = new CheckBox[] { c1, c2 };
       //}
       public void loadFirstPage()

       {
            clearSelects();
            clearAll();
           RefreshTable();


            if (totRows < rowCount)
            {
                rowHider();

            }
            
            //  MessageBox.Show(""+totPages);
            int rnumber = 1;
           String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

           String query = Query + " OFFSET  0 ROWS FETCH NEXT "+ rowCount + " ROWS ONLY;";
           SqlConnection con = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand(query, con);
           con.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           while (reader.Read())
           {

               // MessageBox.Show(reader.GetString(1));
               insertToRow(rnumber, reader);
               rnumber++;

           }
           nextPage = 2;
           currentPage = nextPage - 1;
           arrayList.Insert(0, "");
            arrayList2.Insert(0, "");

        }

        private void RefreshTable()
        {
            this.lastPage = 0;
            this.currentPage = 0;
            this.nextPage = 0;
            this.totRows = 0;
            this.totPages = 0;
            this.nextHop = 0;
            this.nextHoptoback = 0;
            this.max = 1;
            this.LastMax = 0;
            this.forwardindex = -1;
            this.best = 0;
            this.back = false;
            //this.Query = "";
            //this.quert2 = "";
            arrayList.Clear();
            arrayList2.Clear();
      
        Next.Show();
            Previous.Show();
            enablePagination();
            setPages();

        }

        public void setSelects()
        {
            int i = 0;
            foreach (Panel p in pns)
            {
               // MessageBox.Show(p.Name);
                foreach (Control cs in p.Controls)
                {
                    
                    if (cs.Tag == "select")
                    {
                        selects[i] = ((Panel)cs);
                        i++;
                    }
                }

            }

          
             
              
            
           // MessageBox.Show("jhjjh"+selects.Length);
        }


        public void enablePagination()
       {

            String query = quert2 ;
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand(query, con);
           con.Open();
           String total = cmd.ExecuteScalar().ToString();
           totRows = Int32.Parse(total);
           //totalRows.Text = Convert.ToString(totRows);

           int rowsperPage = rowCount;
           if (totRows > rowsperPage)
           {
               Next.Show();
               Previous.Hide();

           }
           else
           {

               Previous.Hide();
               Next.Hide();

           }




       }
       public void setPages()
       {
           totPages = (int)Math.Ceiling(totRows / ((Double)(rowCount)));
           lastPage = totPages;
           if (totPages > 0)
           {
               currentPage = 1;
               //Page.Text = Convert.ToString(currentPage);
              // Last.Text = Convert.ToString(lastPage);


           }





       }
       private void insertToRow(int rowNumber,SqlDataReader rdr)
       {
            
                Panel Row = null;
                String rNumber = "r" + Convert.ToString(rowNumber);
                foreach (Control c in TblBg.Controls)
                {
                    if (c.Name == "r" + Convert.ToString(rowNumber))
                    {

                        Row = ((Panel)c);




                    }
                }


                if (image == true)
                {
                    // MessageBox.Show(path+"dfgdfg");
                    for (int i = 0; i <= numCols; i++)//colem gana
                    {

                        if (coli == i)
                        {
                            // MessageBox.Show(path);
                            foreach (Control lbl in Row.Controls)//methana balahan
                            {

                                if (lbl.GetType().ToString() == "System.Windows.Forms.PictureBox")
                                {
                                    if (lbl.Name == "r" + Convert.ToString(rowNumber) + "c" + Convert.ToString(i))
                                    {
                                        // MessageBox.Show(lbl.Name);

                                        string k = path + rdr.GetValue(i).ToString();
                                    //MessageBox.Show(rdr.GetValue(i).ToString());    
                                    
                                    
                                    //MessageBox.Show(k);
                                        ((PictureBox)lbl).Image = Image.FromFile(k);


                                    }


                                }

                            }

                        }
                        else
                        {
                            foreach (Control lbl in Row.Controls)//methana balahan
                            {

                                if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                                {
                                    if (lbl.Name == "r" + Convert.ToString(rowNumber) + "c" + Convert.ToString(i))
                                    {
                                        string type = rdr.GetDataTypeName(i);
                                        //MessageBox.Show(type);

                                        if (type == "date")
                                        {
                                            lbl.Text = rdr.GetDateTime(i).ToString("dd MMM yyyy");
                                        }
                                        else
                                        {
                                            lbl.Text = rdr.GetValue(i).ToString();
                                        }



                                    }


                                }

                            }


                        }



                    }

                }
                else
                {

                    for (int i = 0; i <= numCols - 1; i++)//colem gana
                    {
                        foreach (Control lbl in Row.Controls)//methana balahan
                        {
                            //MessageBox.Show(" "+lbl.GetType().ToString());
                            if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                            {
                                if (lbl.Name == "r" + Convert.ToString(rowNumber) + "c" + Convert.ToString(i))
                                {
                                    string type = rdr.GetDataTypeName(i);
                                    //MessageBox.Show(type);

                                    if (type == "date")
                                    {
                                        lbl.Text = rdr.GetDateTime(i).ToString("dd MMM yyyy");
                                    }
                                    else
                                    {
                                        lbl.Text = rdr.GetValue(i).ToString();
                                    }



                                }


                            }

                        }
                    }


                }


    



        }


       




        public void GoToNextPage() 
       {

           string str = selectRowq();
            string isStr = selectId();
           clearSelects();
           // MessageBox.Show("bestt"+best);


           loadNextSet();

           if (back == true && best == currentPage)
           {
               loadSelectedChecksq(currentPage - 1);

               //MessageBox.Show("anthimata nathara wetch eka");
               back = false;
               arrayList[currentPage - 2] = str;
                arrayList2[currentPage - 2] = isStr;
            }
           if (currentPage < best && back == true)
           {
               loadSelectedChecksq(currentPage - 1);
               // MessageBox.Show("parana");
               arrayList[currentPage - 2] = str;
                arrayList2[currentPage - 2] = isStr;
            }

           if (best < currentPage && back == false)
           {
               // MessageBox.Show("new"+str);
               arrayList[currentPage - 2] = str;
                arrayList2[currentPage - 2] = isStr;//parana eka update
                arrayList.Insert(currentPage - 1, "");
                arrayList2.Insert(currentPage - 1, "");//aluth eka danawa

            }
          
       
       }
       public void GoToBackPage() 
       {
           string str = selectRowq();
            string isStr = selectId();
            clearSelects();

           if (back == false)
           {
               best = currentPage;
               back = true;
               arrayList[currentPage - 1] = str;
               arrayList2[currentPage - 2] = isStr;
            }
           else
           {
               arrayList[currentPage - 1] = str;
               arrayList2[currentPage - 2] = isStr;

            }

           //  MessageBox.Show("arr count"+arrayList.Count);
           // foreach(string s in arrayList)
           // {
           // MessageBox.Show("elements "+ s);
           //   }

           // MessageBox.Show("best" + best);
           loadLastSet();
           loadSelectedChecksq(currentPage - 1);///7898
       
       
       
       
       }
       private string selectRow()
       {
           //Panel[] pns = new Panel[] { r1, r2 };//

           string st = "";

           foreach (Panel r in pns)
           {


               foreach (Control c in r.Controls)
               {
                   if (c.Tag == "cb")
                   {

                       if (((CheckBox)c).Checked == true)
                       {
                           st += "1";

                       }
                       else
                       {

                           st += "0";
                       }

                   }


               }



           }

           return st;

           //string name = ((CheckBox)sender).Name;
           //int id = Int32.Parse(name.Substring(1));


           //if (((CheckBox)sender).Checked == true)
           //{

           //    selected[id - 1] = id;



           //}
           //else 
           //{
           //    selected[id - 1] = 0;

           //}
           //string srt = String.Join(",", selected);

           /*
             if (((CheckBox)sender).Checked == true)
           {

               foreach (char c in sel)
               {
                   int f = (int)Char.GetNumericValue(c);

                   if (f == id)
                   {

                       Has = true;

                       break;
                   }
               }

               if (Has == false)
               {
                   sel += Convert.ToString(id);
               }




           }
           else 
           {

               foreach (char c in sel)
               {
                   int f = (int)Char.GetNumericValue(c);

                   if (f == id)
                   {

                       Has = true;

                       break;
                   }
               }

            
           }

           MessageBox.Show(" click kora  "+sel);
             
             
             
             
            */

       }



        private string selectRowq()
        {

            //Panel[] pns = new Panel[] { r1, r2 };//
     
            string st = "";
            

            int k = 0;
            foreach (Panel r in pns)
            {

               
              
                foreach (Control c in r.Controls)
                {
                    
                    if (c.Tag == "select")
                    {

                        if (((Panel)c).BackColor == Color.FromArgb(0, 122, 204))
                        {
                            st += "1";

                           
                            

                        }
                        else
                        {

                          
                            st += "0";
                        }

                    }
                   


                }
                k++;


            }
           // MessageBox.Show("selecte"+st);
            return st;


        }



        private string selectId()
        {

            //Panel[] pns = new Panel[] { r1, r2 };//
          
            string st = "";


            int k = 0;
            foreach (Panel r in pns)
            {



                foreach (Control c in r.Controls)
                {

                    if (c.Tag == "select")
                    {

                        if (((Panel)c).BackColor == Color.FromArgb(0, 122, 204))
                        {
                           

                            foreach (Control cc in r.Controls)
                            {

                                if (cc.Name == "r" + (k + 1) + "c0")
                                {

                                    //MessageBox.Show("h"+cc.Name);
                                   st+=((Label)cc).Text+",";
                                }

                            }


                        }
                        else
                        {

                         
                            foreach (Control cc in r.Controls)
                            {

                                if (cc.Name == "r" + (k + 1) + "c0")
                                {


                                    st += "0,";
                                }

                            }
                          
                        }

                    }



                }
                k++;


            }
            // MessageBox.Show("selecte"+st);
            return st;


        }








































        //private void loadSelectedChecks(int cp)
        //{

        //    int l = 0;


        //    string selectded = arrayList[cp];
        //    MessageBox.Show(selectded);
        //    foreach (char c in selectded)
        //    {





        //        if (!(c == '0'))
        //        {
        //            cbs[l].Checked = true;
        //        }
        //        else
        //        {
        //            cbs[l].Checked = false;
        //        }
        //        l++;



        //    }


        //}
        private void loadSelectedChecksq(int cp)
        {
           // MessageBox.Show(""+cp);
            int l = 0;


            string selectded = arrayList[cp];
          //  MessageBox.Show(selectded);
            foreach (char c in selectded)
            {



                if (c == '1')
                {
                    selects[l].BackColor = Color.FromArgb(0, 122, 204);
                    pns[l].BackColor = selectRows;
                    foreach (Control lbl in pns[l].Controls)
                    {

                        if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                        {
                           // MessageBox.Show("lbl" + lbl.Name);
                            lbl.ForeColor = Color.White;
                        }

                    }

                }
                else
                {

                    selects[l].BackColor = baseSelector ;
                    pns[l].BackColor = baseRow;
                    foreach (Control lbl in pns[l].Controls)
                    {

                        if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                        {
                            // MessageBox.Show("lbl" + lbl.Name);
                            lbl.ForeColor = baseSelector;
                        }

                    }

                }
                l++;
                //else
                //{

                //    MessageBox.Show("else" );

                //}

                //if (b==49)
                //{
                //    selects[l].BackColor = Color.Wheat;
                //    pns[l].BackColor = Color.SeaShell;
                //    //MessageBox.Show(pns[l].Name);


                //    foreach (Control lbl in pns[cp].Controls)
                //    {

                //        if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                //        {
                //            MessageBox.Show("lbl"+lbl.Name);
                //            lbl.ForeColor = Color.White;
                //        }

                //    }

                //}
                //else
                //{
                //    MessageBox.Show("Character"+Convert.ToString(c));
                //    //selects[l].BackColor = Color.Maroon;
                //    //pns[l].BackColor = Color.Silver;
                //    //foreach (Control lbl in pns[cp].Controls)
                //    //{

                //    //    if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                //    //    {
                //    //        MessageBox.Show("lblghghgh" + lbl.Name);
                //    //        lbl.ForeColor = Color.Black;

                //    //    }

                //    //}
                //}




            }


        }
        private void loadNextSet()
       {
           int var = 0;
           nextHop = currentPage + 1;
           var = (rowCount * nextHop) - rowCount;
           

            //if (currentPage == 1)
            //{

            //    var = 0;
            //}
            //else
            //{
            //    var = (2 * currentPage) - 2;
            //}
            //  MessageBox.Show(nextHop +"<=" +lastPage);
            if (nextHop <= lastPage)
           {



               clearAll();
               Previous.Show();
               int rnumber = 1;
               String connectionString = "Data Source=(local);Initial Catalog=testITP1;Integrated Security=True";
              // rnumber++;
               String query = Query + " OFFSET  " + var + " ROWS FETCH NEXT "+ rowCount + " ROWS ONLY; ";
               SqlConnection con = new SqlConnection(connectionString);
               SqlCommand cmd = new SqlCommand(query, con);
               con.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {

                    
                   insertToRow(rnumber, reader);///
                   rnumber++;
               }
               currentPage++;
               nextPage = currentPage + 1;
              // Page.Text = Convert.ToString(currentPage);
               //if (max == currentPage)//next yanta puluan aluth list item ekak danta haki
               //{

               //    MessageBox.Show("max"+max+" current"+currentPage);
               //   // arrayList.Insert(currentPage - 1, "");

               //}
               //else 
               //{
               //    MessageBox.Show("ol");
               //}



           }

           if (nextHop == lastPage)
           {
                rowHider();
                Next.Hide();
           }


       }

        private void QuickloadNextSet()
        {


           
            clearSelects();



            int var = 0;
            nextHop = currentPage + 1;
            var = (rowCount * nextHop) - rowCount;



            if (nextHop <= lastPage)
            {



                clearAll();
                Previous.Show();

                currentPage++;
                nextPage = currentPage + 1;


            }

            if (nextHop == lastPage)
            {
                rowHider();
                Next.Hide();
            }


            if (back == true && best == currentPage)
            {
                
                back = false;
               
            }
         


        

        }
        private void QuickloadLastSet()
        {
            max = nextHop;
            int var = 0;
            nextHoptoback = currentPage - 1;
            var = (rowCount * nextHoptoback) - rowCount;


          
            if (nextHoptoback >= 1)
            {


                //clearAll();
                Previous.Show();
              
                nextHoptoback = --currentPage;
              
                Next.Show();
                rowViwer();
              
            }

            if (nextHoptoback == 1)
            {
                Next.Show();
                Previous.Hide();
                nextPage = 2;
                currentPage = nextPage - 1;


              
            }







        }








        public void QuickGo() 
        {

            //MessageBox.Show("sdfsdf");
            if (totRows> 10)
            {
                //MessageBox.Show("total" + totRows);
                int predicted = totPages * rowCount;
                int actual = totRows;


                int def = predicted - actual;
                int point = rowCount - def;

                for (int i = 1; i <= totPages; i++)
                {

                    GoToNextPage();



                }


                pns[point - 1].BackColor = Color.Beige;



            }
            else 
            {

                //MessageBox.Show("total" + totRows);
                int predicted = totPages * rowCount;
                int actual = totRows;


                int def = predicted - actual;
                int point = rowCount - def;

               // GoToNextPage();
                pns[point - 1].BackColor = Color.Yellow;
            
            
            
            }
                

            
           
           
          



           
        }











       private void clearAll()
       {
            foreach (Control c in TblBg.Controls)
            {
                if (c.Tag == "r")
                {
                    c.Visible = true;
                    ((Panel)c).BackColor = baseRow;
                    foreach (Control co in c.Controls)
                    {

                        if (co.Tag == "cols")
                        {
                            if (co.GetType().ToString() == "System.Windows.Forms.PictureBox")


                            {
                                //MessageBox.Show("fff");
                                ((PictureBox)co).Image = null;

                            }
                            else
                            {
                                ((Label)co).Text = "";
                                if (((Label)co).ForeColor != baseSelector)
                                {
                                    ((Label)co).ForeColor =baseSelector;
                                }
                               

                            }



                        }

                    }


                }
            }
        }
       private void clearSelects()
       {
            foreach (Control lbl in selects)
            {

                lbl.BackColor = baseSelector;

            }




           
       }
       private void loadLastSet()
       {
           max = nextHop;
           int var = 0;
           nextHoptoback = currentPage - 1;
           var = (rowCount * nextHoptoback) - rowCount;
           

           //if (currentPage == 1)
           //{

           //    var = 0;
           //}
           //else
           //{
           //    var = (2 * currentPage) - 2;
           //}
           // MessageBox.Show(nextHop +"<=" +lastPage);
           if (nextHoptoback >= 1)
           {


               clearAll();
               Previous.Show();
               int rnumber = 1;
               String connectionString = "Data Source=(local);Initial Catalog=testITP1;Integrated Security=True";
               String query = Query + " OFFSET  " + var + " ROWS FETCH NEXT "+ rowCount + " ROWS ONLY; ";
               SqlConnection con = new SqlConnection(connectionString);
               SqlCommand cmd = new SqlCommand(query, con);
               con.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {

                   // MessageBox.Show(reader.GetString(1));
                   insertToRow(rnumber, reader);
                   rnumber++;
               }
               nextHoptoback = --currentPage;
               //arrayList.Insert(currentPage - 1, "");
               Next.Show();
                rowViwer();
               //Page.Text = Convert.ToString(currentPage);
               // arrayList.Insert(currentPage-1, "");

           }

           if (nextHoptoback == 1)
           {
               Next.Show();
               Previous.Hide();
               nextPage = 2;
               currentPage = nextPage - 1;
              

               //loadSelectedChecks(0);
           }







       }

        private void rowViwer()
        {
            int predicted = totPages * rowCount;
            int actual = totRows;

            int def = predicted - actual;
            int point = rowCount - def;

            // MessageBox.Show(""+point);
            for (int i = point; i <= rowCount - 1; i++)
            {
                pns[i].Visible = true;

            }
        }

        private void rowHider()
        {
           
            int predicted = totPages * rowCount;
            int actual = totRows;

           
            int def = predicted - actual;
            int point = rowCount - def;
          //  MessageBox.Show("d"+ totRows);


            if (totRows == 0)
            {

                for (int i = 0; i <= rowCount-1; i++)
                {
                    pns[i].Visible = false;
                    //MessageBox.Show("d" + totRows);

                }




              
            }
            else
            {

                for (int i = point; i <= rowCount - 1; i++)
                {
                    pns[i].Visible = false;

                }

            }

           // MessageBox.Show(""+point);
        

        }

        public void Selector(object sender)
        {
            Panel button = ((Panel)sender);
            Panel row = ((Panel)(button.Parent));

            if (button.BackColor == baseSelector)
            {
                button.BackColor = Color.FromArgb(0, 122, 204);
                row.BackColor = selectRows;
                foreach (Control lbl in row.Controls)
                {
                     if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                       {
                             lbl.ForeColor = Color.White;
                       }

               }
            }
            else
            {
                button.BackColor = baseSelector;
                row.BackColor = baseRow;
                foreach (Control lbl in row.Controls)
                {
                    if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
                    {
                        lbl.ForeColor = baseSelector;
                    }

                }

            }


            //Panel row = ((Panel)(button.Parent));


            //if (row.BackColor == Color.Silver)
            //{
            //    row.BackColor = Color.Black;
            //    foreach (Control lbl in row.Controls)
            //    {

            //        if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
            //        {
            //            lbl.ForeColor = Color.White;
            //        }

            //    }
               
            //}
            //else
            //{
            //    row.BackColor = Color.Silver;
            //    foreach (Control lbl in row.Controls)
            //    {

            //        if (lbl.GetType().ToString() == "System.Windows.Forms.Label")
            //        {
            //            lbl.ForeColor = Color.Black;
            //        }

            //    }
              
            //}
        }
       


    }
}
