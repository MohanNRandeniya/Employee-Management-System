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
    public partial class SetAtt : Form
    {
        private conDB conn;
        string datetime = DateTime.Now.ToString();

        public SetAtt()
        {
            InitializeComponent();
            TableLoad();
            addnewCol();
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            attForm back = new attForm();
            back.Show();
            //Hide();
        }

        private void addnewCol()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "AttendanceStatus";
            combo.Name = "combo";
            combo.Items.AddRange("Present", "Absent");
            bunifuCustomDataGrid1.Columns.Add(combo);
        }

        public void TableLoad()
        {
            conn = new conDB();
            SqlDataReader rdr = conn.dataReader("select e.EmpID,e.EmpfName,e.EmplName,e.Position from Attendance a,Employee e where e.EmpID=a.EmpID and e.MarkedStatus='on' and AttendanceStatus='Waiting' and Date='"+datetime+"' and a.ArivalTime is null ");
            BindingSource bs = new BindingSource();
            bs.DataSource = rdr;
            bunifuCustomDataGrid1.DataSource = bs;

            conn.closeConnection();
            
        }
        
        private void lblSet_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
            {
                try
                {
                    conn = new conDB();

                    String status = (String)bunifuCustomDataGrid1.Rows[i].Cells[0].Value;
                    //MessageBox.Show(status);

                    String EmpID = bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString();
                    //MessageBox.Show(EmpID);

                    if (status == "Present")
                    {
                        conn.executeQry("update Attendance set ArivalTime='" + datetime
                                        + "', AttendanceStatus='Present' where EmpID='" + EmpID + "' and Date='"+datetime+"' ");
                    }
                    else if(status == "Absent")
                    {
                        conn.executeQry("update Attendance set AttendanceStatus='Absent' where EmpID='" + EmpID + "' and Date='" + datetime + "' ");
                    }
                    else
                    {
                        conn.executeQry("update Attendance set AttendanceStatus='Waiting' where EmpID='" + EmpID + "' and Date='" + datetime + "' ");
                    }

                    MessageBox.Show("Successful");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            TableLoad();

        }



    }
}
