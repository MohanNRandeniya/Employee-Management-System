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
    public partial class SetLeave : Form
    {

        private conDB conn;
        string datetime = DateTime.Now.ToString();

        public SetLeave()
        {
            InitializeComponent();

            tableLoad();
            addnewCol();

        }

        private void addnewCol()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "LeaveStatus";
            combo.Name = "combo";
            combo.Items.AddRange("Full Day", "Half Day", "Over Time");
            bunifuCustomDataGrid1.Columns.Add(combo);
        }

        private void tableLoad()
        {
            conn = new conDB();
            SqlDataReader rdr = conn.dataReader("select e.EmpID,e.EmpfName,e.EmplName,a.Date,a.ArivalTime,a.AttendanceStatus from Attendance a,Employee e where e.EmpID=a.EmpID and a.AttendanceStatus='Present' and MarkedStatus='on' and Date ='" + datetime + "' and LeaveStates is null ");
            BindingSource bs = new BindingSource();
            bs.DataSource = rdr;
            bunifuCustomDataGrid1.DataSource = bs;

            conn.closeConnection();
            
        }

        private void lblSetAtt_MouseClick(object sender, MouseEventArgs e)
        {
            string datetime = DateTime.Now.ToString();

            for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
            {
                String status = (String)bunifuCustomDataGrid1.Rows[i].Cells[0].Value;
                MessageBox.Show(status);

                String EmpID = bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString();
                MessageBox.Show(EmpID);

                String leavestatus = (String)bunifuCustomDataGrid1.Rows[i].Cells[0].Value;
                //MessageBox.Show(leavestatus);

                try
                {
                    if(leavestatus!=null)
                    {
                        conn = new conDB();
                        conn.executeQry("update Attendance set LeaveStates='" + status + "',LeaveTime='" + datetime + "' where EmpID='" + EmpID + "' and Date ='" + datetime + "' ");

                        MessageBox.Show("Successful");
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            tableLoad();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            attForm back = new attForm();
            back.Show();
            //Hide();
        }


    }
}
