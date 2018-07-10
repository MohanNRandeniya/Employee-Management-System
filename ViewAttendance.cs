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
    public partial class ViewAttendance : Form
    {

        private conDB conn;
        //string datetime = DateTime.Now.ToString();

        public ViewAttendance()
        {
            InitializeComponent();

            tableLoad();

        }

        private void tableLoad()
        {
            conn = new conDB();
            SqlDataReader rdr = conn.dataReader("select * from ViewAllAttendance ");
            BindingSource bs = new BindingSource();
            bs.DataSource = rdr;
            bunifuCustomDataGrid1.DataSource = bs;

            conn.closeConnection();
            
        }

        private void pbSearchAll_MouseEnter(object sender, EventArgs e)
        {
            pbSearchAll.Image = Properties.Resources.searchSelect;
        }

        private void pbSearchAll_MouseLeave(object sender, EventArgs e)
        {
            pbSearchAll.Image = Properties.Resources.searchNormal;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            attForm back = new attForm();
            back.Show();
            //Hide();            
        }

        private void pbSearchAll_MouseClick(object sender, MouseEventArgs e)
        {

            if (txtSearchAll.Text == "")
            {
                MessageBox.Show("Search Box is Empty");
            }
            else
            {
                try
                {
                    conn = new conDB();
                    SqlDataReader rdr = conn.dataReader("select * from ViewAllAttendance where FullName like '%" + txtSearchAll.Text + "%' ");
                    BindingSource bs = new BindingSource();
                    bs.DataSource = rdr;
                    bunifuCustomDataGrid1.DataSource = bs;

                    conn.closeConnection();

                    txtSearchAll.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            tableLoad();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new conDB();
                SqlDataReader rdr = conn.dataReader("select * from ViewAllAttendance where Date = '" + dateTimePicker1.Value + "' ");
                BindingSource bs = new BindingSource();
                bs.DataSource = rdr;
                bunifuCustomDataGrid1.DataSource = bs;

                conn.closeConnection();

                txtSearchAll.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
