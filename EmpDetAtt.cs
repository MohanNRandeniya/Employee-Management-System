using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeM
{
    public partial class EmpDetAtt : Form
    {
        conDB conn = new conDB();
        public Table tbl = null;
        DateTime datetime = DateTime.Now;
        string IDvalues;
        string FullIDvalues;
        int totaldays;
        int fulltotaldays;
        int days;
        int fulldays;
        int present;
        int fullpresent;
        int absent;
        int fullabsent;
        double monpreavg;
        double yrpreavg;


        public EmpDetAtt()
        {
            InitializeComponent();

            tbl = new Table(5, Next, Previous, pnltbl, true, 1, 4);
            tbl.setTblRowsImage(r1, r2, r3, r4, r5);
            tbl.setQuery1("select EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position from Employee where MarkedStatus='on' ORDER BY EmpID ASC");
            tbl.setQuery2("select count(*) from Employee where MarkedStatus='on' ");
            // tbl.setCBoxs(c1, c2);
            tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");
            tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
            tbl.setSelects();
            tbl.enablePagination();
            tbl.setPages();
            tbl.loadFirstPage();

  
            days = (int)conn.dataReaderScalar("select count(*) from tempAtt where Month='"+datetime.Month+"' and Year='"+datetime.Year+"' group by Date ");
            //MessageBox.Show(days.ToString());
            SqlDataReader dr = conn.dataReader("select EmpID from tempAtt group by EmpID ");
            
            for (int i = 0; i < days; i++)
            {
                while (dr.Read())
                {
                    IDvalues = dr[0].ToString();
                    //MessageBox.Show(IDvalues);

                    totaldays = (int)conn.dataReaderScalar("select count(*) from tempAtt where Month='" + datetime.Month + "' and Year='" + datetime.Year + "' group by Date ");
                    present = (int)conn.dataReaderScalar("select count(EmpID) from tempAtt where EmpID='" + IDvalues + "' and Month='" + datetime.Month + "' and Year='" + datetime.Year + "' and AttendanceStatus='Present' group by EmpID");
                    absent = (int)conn.dataReaderScalar("select count(EmpID) from tempAtt where EmpID='" + IDvalues + "' and Month='" + datetime.Month + "' and Year='" + datetime.Year + "' and AttendanceStatus='Absent' group by EmpID");
                    //MessageBox.Show(totaldays.ToString() + '=' + present.ToString() + '+' + absent.ToString());
                    monpreavg = (present / (double)totaldays)*100;
                    //MessageBox.Show(monpreavg.ToString("f2"));
                    
                    //conn.executeQry("INSERT INTO Attendance (Date,EmpID) VALUES ('" + datetime + "','" + IDvalues + "') ");

                }
            }

            fulldays = (int)conn.dataReaderScalar("select COUNT(*) from tempAtt group by EmpID ");
            //MessageBox.Show(fulldays.ToString());
            SqlDataReader sdr = conn.dataReader("select EmpID from tempAtt group by EmpID ");

            for (int i = 0; i < fulldays; i++)
            {
                while (sdr.Read())
                {
                    FullIDvalues = sdr[0].ToString();
                    //MessageBox.Show(FullIDvalues);

                    fulltotaldays = (int)conn.dataReaderScalar("select count(*) from tempAtt where Year='" + datetime.Year + "' group by Year,EmpID ");
                    fullpresent = (int)conn.dataReaderScalar("select count(EmpID) from tempAtt where EmpID='"+FullIDvalues+ "' and AttendanceStatus='Present' and Year='" + datetime.Year + "' group by Year,EmpID ");
                    fullabsent = (int)conn.dataReaderScalar("select count(EmpID) from tempAtt where EmpID='" + FullIDvalues + "' and AttendanceStatus='Absent' and Year='" + datetime.Year + "' group by Year,EmpID ");
                    //MessageBox.Show(fulltotaldays.ToString() + '=' + fullpresent.ToString() + '+' + fullabsent.ToString());
                    yrpreavg = (fullpresent / (double)fulltotaldays) * 100;
                    //MessageBox.Show(yrpreavg.ToString("f2"));

                    //conn.executeQry("INSERT INTO Attendance (Date,EmpID) VALUES ('" + datetime + "','" + IDvalues + "') ");

                }
            }
            
            conn.closeConnection();

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pbSearchAll.Image = Properties.Resources.searchSelect;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pbSearchAll.Image = Properties.Resources.searchNormal;
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            mainForm back = new mainForm();
            back.Show();
            Hide();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_buttonSelect;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_button;
        }

        private void pbSearchAll_MouseClick(object sender, MouseEventArgs e)
        {

            if(txtSearchAll.Text=="")
            {
                MessageBox.Show("Please enter a Keyword to Search");
            }
            else
            {
                tbl = new Table(5, Next, Previous, pnltbl, true, 0, 4);
                tbl.setTblRowsImage(r1, r2, r3, r4, r5);
                tbl.setQuery1(" SELECT EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position FROM Employee WHERE EmpfName LIKE '%" + txtSearchAll.Text + "%' ORDER BY EmpID");
                tbl.setQuery2("select count(*) from Employee WHERE EmpfName LIKE '%" + txtSearchAll.Text + "%' ");
                tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");

                tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
                tbl.setSelects();
                tbl.enablePagination();
                tbl.setPages();

                tbl.loadFirstPage();

                txtSearchAll.ResetText();
            }
            

        }

        private void Next_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.GoToNextPage();
        }

        private void Previous_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.GoToBackPage();
        }

        private void pbReset_MouseClick(object sender, MouseEventArgs e)
        {
            tbl = new Table(5, Next, Previous, pnltbl, true, 1, 4);
            tbl.setTblRowsImage(r1, r2, r3, r4, r5);
            tbl.setQuery1("select EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position from Employee where MarkedStatus='on' ORDER BY EmpID ASC");
            tbl.setQuery2("select count(*) from Employee where MarkedStatus='on' ");
            // tbl.setCBoxs(c1, c2);
            tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");
            tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
            tbl.setSelects();
            tbl.enablePagination();
            tbl.setPages();
            tbl.loadFirstPage();
        }


    }
}
