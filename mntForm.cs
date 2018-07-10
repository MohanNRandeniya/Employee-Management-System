using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeM
{
    public partial class mntForm : Form
    {
        public Table tbl = null;

        public mntForm()
        {
            InitializeComponent();

            lblmsgadd.Visible = false;
            lblmsgremove.Visible = false;
            lblmsgupdate.Visible = false;
            lblmsgReset.Visible = false;

            tbl = new Table(5, Next, Previous, pnltbl, true, 1, 9);
            tbl.setTblRowsImage(r1, r2, r3, r4, r5);
            tbl.setQuery1("select EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position,DOB,ContactNo,Email,No+','+Street+','+City as HomeAddress,MarkedStatus from Employee where MarkedStatus='on' ORDER BY EmpID ASC");
            tbl.setQuery2("select count(*) from Employee where MarkedStatus='on' ");
            // tbl.setCBoxs(c1, c2);
            tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");
            tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
            tbl.setSelects();
            tbl.enablePagination();
            tbl.setPages();
            tbl.loadFirstPage();
            
        }
        

        private void pbAdd_MouseEnter(object sender, EventArgs e)
        {
            pbAdd.Image = Properties.Resources.addSelected;
            lblmsgadd.Visible = true;
        }

        private void pbAdd_MouseLeave(object sender, EventArgs e)
        {
            pbAdd.Image = Properties.Resources.addNormal;
            lblmsgadd.Visible = false;
        }

        private void pbEdit_MouseEnter(object sender, EventArgs e)
        {
            pbEdit.Image = Properties.Resources.editSelect;
            lblmsgupdate.Visible = true;
        }

        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            pbEdit.Image = Properties.Resources.editNormal;
            lblmsgupdate.Visible = false;
        }

        private void pbRemove_MouseEnter(object sender, EventArgs e)
        {
            pbRemove.Image = Properties.Resources.removeSelected;
            lblmsgremove.Visible = true;
        }

        private void pbRemove_MouseLeave(object sender, EventArgs e)
        {
            pbRemove.Image = Properties.Resources.removeNormal;
            lblmsgremove.Visible = false;
        }

        private void pbSearch_MouseEnter(object sender, EventArgs e)
        {
            pbSearch.Image = Properties.Resources.searchSelect;
        }

        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            pbSearch.Image = Properties.Resources.searchNormal;
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            mainForm back = new mainForm();
            back.Show();
            Hide();
        }

        private void pbReset_MouseEnter(object sender, EventArgs e)
        {
            pbReset.Image = Properties.Resources.resetSelect;
            lblmsgReset.Visible = true;
        }

        private void pbReset_MouseLeave(object sender, EventArgs e)
        {
            pbReset.Image = Properties.Resources.resetNormal;
            lblmsgReset.Visible = false;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_buttonSelect;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_button;
        }

        private void pbAdd_MouseClick(object sender, MouseEventArgs e)
        {
            AddDetails add = new AddDetails(this);
            this.Enabled = true;
            add.Show();
            
        }

       

        private void pbEdit_MouseClick(object sender, MouseEventArgs e)
        {
            string s = tbl.getSelecdedIds();
            string id = "";
            string[] words = s.Split(',');
            int row = 0;
            foreach (string word in words)
            {

                if (word != "0" && word != "End")
                {
                    id = word;
                    row++;
                }

            }
            
            if (row == 0)
            {
                MessageBox.Show("Please, Select a Row !!!");
            }
            else if (row > 1)
            {
                MessageBox.Show("Please, Select only a Row !!!");
            }
            else
            {
                UpdateDetails addEdit = new UpdateDetails(id,this);
                addEdit.Show();
            }
            
        }

        private void pbRemove_MouseClick(object sender, MouseEventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            string s = tbl.getSelecdedIds().ToString();

            string[] words = s.Split(',');
            int row = 0;
            foreach (string word in words)
            {

                if (word != "0" && word != "End")
                {
                    string query = "UPDATE Employee SET MarkedStatus = 'off' WHERE EmpID='" + word + "'; ";
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    row += cmd.ExecuteNonQuery();
                }

            }
            if (row > 0)
            {
                tbl.loadFirstPage();
            }
            else
            {
                MessageBox.Show("Please, Select a Row or More !!!");
            }

        }

        private void pbReset_MouseClick(object sender, MouseEventArgs e)
        {
            tbl = new Table(5, Next, Previous, pnltbl, true, 1, 9);
            tbl.setTblRowsImage(r1, r2, r3, r4, r5);
            tbl.setQuery1("select EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position,DOB,ContactNo,Email,No+','+Street+','+City as HomeAddress,MarkedStatus from Employee where MarkedStatus='on' ORDER BY EmpID ASC");
            tbl.setQuery2("select count(*) from Employee where MarkedStatus='on' ");
            // tbl.setCBoxs(c1, c2);
            tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");
            tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
            tbl.setSelects();
            tbl.enablePagination();
            tbl.setPages();
            tbl.loadFirstPage();
        }

        private void pbSearch_MouseClick(object sender, MouseEventArgs e)
        {

            if(txtSearch.Text=="")
            {
                MessageBox.Show("Please enter a Keyword to Search");
            }
            else
            {
                tbl = new Table(5, Next, Previous, pnltbl, true, 0, 9);
                tbl.setTblRowsImage(r1, r2, r3, r4, r5);
                tbl.setQuery1(" select EmpID,Photo,EmpNIC,EmpfName+' '+EmplName as FullName,Position,DOB,ContactNo,Email,No+','+Street+','+City as HomeAddress FROM Employee WHERE EmpfName LIKE '%" + txtSearch.Text + "%' ORDER BY EmpID");
                tbl.setQuery2("select count(*) from Employee WHERE EmpfName LIKE '%" + txtSearch.Text + "%' ");
                tbl.setPath(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\");

                tbl.tblTheamSetter(Color.FromArgb(38, 95, 141), Color.FromArgb(47, 50, 67), Color.FromArgb(89, 89, 89, 89), Color.FromArgb(169, 171, 183));
                tbl.setSelects();
                tbl.enablePagination();
                tbl.setPages();

                tbl.loadFirstPage();

                txtSearch.ResetText();
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

        private void cc1_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.Selector(sender);
        }

        private void cc2_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.Selector(sender);
        }

        private void cc3_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.Selector(sender);
        }

        private void cc4_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.Selector(sender);
        }

        private void cc5_MouseClick(object sender, MouseEventArgs e)
        {
            tbl.Selector(sender);
        }


    }
}
