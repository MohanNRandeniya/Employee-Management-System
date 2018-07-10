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
    public partial class attForm : Form
    {
        private conDB conn;
        string datetime = DateTime.Now.ToString();
        string IDvalues;

        public attForm()
        {
            InitializeComponent();
            makeAttendance();
            TextAnim make = new TextAnim("ATTENDANCE MANAGEMENT", label1, panel14, 20, 45);
            make.Start();

            pnlAM.Visible = false;
            panel1.Visible = false;
            pictureBox9.Visible = false;

        }

        private void lblSet_MouseClick(object sender, MouseEventArgs e)
        {
            SetAtt satt = new SetAtt();
            satt.Show();
            Hide();

            makeAttendance();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            SetAtt satt = new SetAtt();
            satt.Show();
            Hide();

            makeAttendance();

        }

        private void makeAttendance()
        {

            conn = new conDB();
            int count = (int)conn.dataReaderScalar("select count(AtID) from Attendance where Date = '" + datetime + "' ");
            //MessageBox.Show(count.ToString());

            if (count == 0)
            {
                int x = (int)conn.dataReaderScalar("select count(EmpID) from Employee where MarkedStatus='on' ");
                //MessageBox.Show(x.ToString());
                SqlDataReader dr = conn.dataReader("select EmpID from Employee where MarkedStatus='on' ");

                for (int i = 0; i < x; i++)
                {
                    while (dr.Read())
                    {
                        IDvalues = dr[0].ToString();
                        //MessageBox.Show(IDvalues);
                        conn = new conDB();
                        conn.executeQry("INSERT INTO Attendance (Date,EmpID) VALUES ('" + datetime + "','" + IDvalues + "') ");

                    }
                }
            }

            conn.closeConnection();
        }

        private void lblPresent_MouseClick(object sender, MouseEventArgs e)
        {
            ViewPresent vp = new ViewPresent();
            vp.Show();
            Hide();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ViewPresent vp = new ViewPresent();
            vp.Show();
            Hide();
        }

        private void lblAbsent_MouseClick(object sender, MouseEventArgs e)
        {
            ViewAbsent vab = new ViewAbsent();
            vab.Show();
            Hide();
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            ViewAbsent vab = new ViewAbsent();
            vab.Show();
            Hide();
        }

        private void lblLeave_MouseClick(object sender, MouseEventArgs e)
        {
            SetLeave sl = new SetLeave();
            sl.Show();
            Hide();
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            SetLeave sl = new SetLeave();
            sl.Show();
            Hide();
        }

        private void lblViewAtt_MouseClick(object sender, MouseEventArgs e)
        {
            ViewAttendance vatt = new ViewAttendance();
            vatt.Show();
            Hide();
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            ViewAttendance vatt = new ViewAttendance();
            vatt.Show();
            Hide();
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            mainForm back = new mainForm();
            back.Show();
            Hide();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.setAttSelect;
            lblSet.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.setAttNormal;
            lblSet.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.viewallattSelect;
            lblViewAtt.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.viewallattNormal;
            lblViewAtt.ForeColor = Color.FromArgb(169, 171, 183);

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.presentSelect;
            lblPresent.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.presentNormal;
            lblPresent.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.absentSelect;
            lblAbsent.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.absentNormal;
            lblAbsent.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.leaveSelect;
            lblLeave.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.leaveNormal;
            lblLeave.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_buttonSelect;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.back_button;
        }

        private void lblSet_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.setAttSelect;
            lblSet.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblSet_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.setAttNormal;
            lblSet.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblPresent_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.presentSelect;
            lblPresent.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblPresent_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.presentNormal;
            lblPresent.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblAbsent_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.absentSelect;
            lblAbsent.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblAbsent_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.absentNormal;
            lblAbsent.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblLeave_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.leaveSelect;
            lblLeave.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblLeave_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.leaveNormal;
            lblLeave.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblViewAtt_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.viewallattSelect;
            lblViewAtt.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblViewAtt_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.viewallattNormal;
            lblViewAtt.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            EmailInfo ema = new EmailInfo();
            ema.Show();
            Hide();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.mailSelect;
            label3.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.mailNormal;
            label3.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            EmailInfo ema = new EmailInfo();
            ema.Show();
            Hide();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.mailSelect;
            label3.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.mailNormal;
            label3.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            pnlAM.Visible = true;
            panel1.Visible = true;
            pictureBox9.Visible = true;

            pnlEM.Visible = false;
            pnlEDEA.Visible = false;
            pnlLeave.Visible = false;
            panel2.Visible = false;
            pictureBox8.Visible = false;
        }

        private void pictureBox9_MouseClick(object sender, MouseEventArgs e)
        {
            pnlAM.Visible = false;
            panel1.Visible = false;
            pictureBox9.Visible = false;

            pnlEM.Visible = true;
            pnlEDEA.Visible = true;
            pnlLeave.Visible = true;
            panel2.Visible = true;
            pictureBox8.Visible = true;
        }
    }
}
