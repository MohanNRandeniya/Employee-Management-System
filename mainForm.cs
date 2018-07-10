using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace EmployeeM
{
    public partial class mainForm : Form
    {
        public Form MDI = null;
        public mainForm()
        {
            InitializeComponent();
            this.Location = new Point(0,0);
            TextAnim make = new TextAnim("EMPLOYEE MANAGEMENT", label1, panel14, 20, 45);
            make.Start();
        }


        private void BoxEmp_MouseClick(object sender, MouseEventArgs e)
        {
            mntForm f1 = new mntForm();
            f1.Show();
            Hide();
        }

        private void BoxAtt_MouseClick(object sender, MouseEventArgs e)
        {
            attForm f2 = new attForm();
            f2.Show();
            Hide();
        }

        private void BoxAll_MouseClick(object sender, MouseEventArgs e)
        {
            EmpDetAtt f3 = new EmpDetAtt();
            f3.Show();
            Hide();
        }

        private void lblEmp_MouseClick(object sender, MouseEventArgs e)
        {
            mntForm f1 = new mntForm();
            f1.Show();
            Hide();
        }

        private void lblAtt_MouseClick(object sender, MouseEventArgs e)
        {
            attForm f2 = new attForm();
            f2.Show();
            Hide();
        }

        private void lblAll_MouseClick(object sender, MouseEventArgs e)
        {
            EmpDetAtt f3 = new EmpDetAtt();
            f3.Show();
            Hide();
        }

        private void BoxEmp_MouseEnter(object sender, EventArgs e)
        {

            BoxEmp.Image = Properties.Resources.empmntSelect;
            lblEmp.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void BoxEmp_MouseLeave(object sender, EventArgs e)
        {
            BoxEmp.Image = Properties.Resources.empmntNormal;
            lblEmp.ForeColor = Color.FromArgb(169, 171, 183);

        }

        private void BoxAtt_MouseEnter(object sender, EventArgs e)
        {
            BoxAtt.Image = Properties.Resources.attmntSelect;
            lblAtt.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void BoxAtt_MouseLeave(object sender, EventArgs e)
        {
            BoxAtt.Image = Properties.Resources.attmntNormal;
            lblAtt.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void BoxAll_MouseEnter(object sender, EventArgs e)
        {
            BoxAll.Image = Properties.Resources.empdetattSelect;
            lblAll.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void BoxAll_MouseLeave(object sender, EventArgs e)
        {
            BoxAll.Image = Properties.Resources.empdetattNormal;
            lblAll.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblEmp_MouseEnter(object sender, EventArgs e)
        {
            BoxEmp.Image = Properties.Resources.empmntSelect;
            lblEmp.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblEmp_MouseLeave(object sender, EventArgs e)
        {
            BoxEmp.Image = Properties.Resources.empmntNormal;
            lblEmp.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblAtt_MouseEnter(object sender, EventArgs e)
        {
            BoxAtt.Image = Properties.Resources.attmntSelect;
            lblAtt.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblAtt_MouseLeave(object sender, EventArgs e)
        {
            BoxAtt.Image = Properties.Resources.attmntNormal;
            lblAtt.ForeColor = Color.FromArgb(169, 171, 183);
        }

        private void lblAll_MouseEnter(object sender, EventArgs e)
        {
            BoxAll.Image = Properties.Resources.empdetattSelect;
            lblAll.ForeColor = Color.FromArgb(29, 150, 234);
        }

        private void lblAll_MouseLeave(object sender, EventArgs e)
        {
            BoxAll.Image = Properties.Resources.empdetattNormal;
            lblAll.ForeColor = Color.FromArgb(169, 171, 183);
        }


    }
}
