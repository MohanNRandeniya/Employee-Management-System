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
    public partial class UpdateDetails : Form
    {

        private string SelectedId = null;
        conDB conn = new conDB();

        String realname;
        String FileName;
        Form container;

        public UpdateDetails(string k, Form container)
        {
            InitializeComponent();
            this.SelectedId = k;
            this.container = container;
            //fillUpdateForm();

            loadData(k);
        }

        string[] fields = new string[13];

        private void loadData(string k)
        {
            //MessageBox.Show(k);
            string query = "select EmpID,Photo,EmpNIC,EmpfName,EmplName,Position,DOB,ContactNo,Email,No,Street,City,JoinDate from Employee where EmpID='"+k+"' ORDER BY EmpID ASC ";

            SqlDataReader sdr = conn.dataReader(query);

            while(sdr.Read())
            {
                for(int i=0;i<fields.Length;i++)
                {

                    if(i==12)
                    {
                        fields[i] = sdr.GetDateTime(i).ToString("dd MMM yyyy");
                    }
                    else
                    {
                        fields[i] = sdr.GetValue(i).ToString();
                    }

                    //MessageBox.Show(fields[i]);
                    
                }


            }

            lblID.Text = fields[0];
            photoBox.Image = Image.FromFile(@"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\" + fields[1]);
            txtNIC.Text = fields[2];
            txtfName.Text = fields[3];
            txtlName.Text = fields[4];
            dropdPos.Text = fields[5];
            datetimeBD.Text = fields[6];
            txtTele.Text = fields[7];
            txtEmail.Text = fields[8];
            txtAddressNo.Text = fields[9];
            txtAddressStreet.Text = fields[10];
            txtAddressCity.Text = fields[11];
            lblJoin.Text = fields[12];

            conn.closeConnection();

        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            mntForm mnt = new mntForm();
            mnt.Show();
        }

        private void photoBox_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Documents";
            ofd.Filter = "Choose Image(*.jpg;*.png)|*.jpg;*.png";
            ofd.FilterIndex = 1;
            ofd.Title = "Browse Image Files";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                realname = System.IO.Path.GetFileName(ofd.FileName);
                photoBox.Image = Image.FromFile(ofd.FileName);
                FileName = ofd.FileName;
            }
        }

        private void lblReset_MouseClick(object sender, MouseEventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            lblID.ResetText();
            photoBox.Image = null;
            txtNIC.ResetText();
            txtfName.ResetText();
            txtlName.ResetText();
            dropdPos.Text = null;
            datetimeBD.Value = DateTime.Now;
            txtTele.ResetText();
            txtEmail.ResetText();
            txtAddressNo.ResetText();
            txtAddressStreet.ResetText();
            txtAddressCity.ResetText();
            lblJoin.ResetText();
        }

        private void lblSubmit_MouseClick(object sender, MouseEventArgs e)
        {


            if (txtNIC.Text == "" || dropdPos.Text == "" || txtfName.Text == "" || txtlName.Text == "" || datetimeBD.Text == "" || txtAddressNo.Text == "" || txtAddressCity.Text == "" || txtAddressStreet.Text == "" || txtTele.Text == "" || txtEmail.Text == "" || photoBox.Image == null)
            {
                MessageBox.Show("Please Fill all the Details");
            }
            else
            {
                try
                {
                    //validatenow();

                    //MessageBox.Show(lblID.Text);
                    string query = ("update Employee set EmpNIC = '" + txtNIC.Text
                                        + "', EmpfName = '" + txtfName.Text
                                        + "', EmplName = '" + txtlName.Text
                                        + "', Position = '" + dropdPos.Text.ToString()
                                        + "', DOB = '" + datetimeBD.Value.ToString()
                                        + "', Email = '" + txtEmail.Text
                                        + "', ContactNo = '" + txtTele.Text
                                        + "', No = '" + txtAddressNo.Text
                                        + "', Street = '" + txtAddressStreet.Text
                                        + "', City = '" + txtAddressCity.Text
                                        + "', Photo = '" + realname
                                        + "' where EmpID = '" + lblID.Text.ToString() + "' ");

                    int h = conn.executeQry(query);
                    if (h == 1)
                    {
                        System.IO.File.Copy(FileName, @"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\" + realname);
                    }

                    conn.closeConnection();

                    mntForm hh = ((mntForm)container);
                    hh.Enabled = true;
                    hh.tbl.loadFirstPage();

                    resetData();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
            
        }

        private void validatenow()
        {

            String nic = txtNIC.Text.ToString();
            String position = dropdPos.Text.ToString();
            String firstName = txtfName.Text.ToString();
            String lastName = txtlName.Text.ToString();
            //String birthday = datetimeBD.Text.ToString();
            String addressNo = txtAddressNo.Text.ToString();
            String addressStreet = txtAddressStreet.Text.ToString();
            String addressCity = txtAddressCity.Text.ToString();
            String teleNo = txtTele.Text.ToString();
            String email = txtEmail.Text.ToString();

            if (String.IsNullOrWhiteSpace(position) || position.Any(Char.IsDigit))
            {
                MessageBox.Show("Employee's position cannot be digits");
                dropdPos.Select();
            }

            if (!ValidationClass.checkEmail(email))
            {
                MessageBox.Show("Email is Invalid");
            }

            if (!ValidationClass.checkFname(firstName))
            {
                MessageBox.Show("First Name is Invalid");
            }

            if (!ValidationClass.checkLname(lastName))
            {
                MessageBox.Show("Last Name is Invalid");
            }

            if (!ValidationClass.checkTele(teleNo))
            {
                MessageBox.Show("Contact No is Invalid");
            }

            if (!ValidationClass.checkNIC(nic))
            {
                MessageBox.Show("Invalid NIC format");
            }

            if (photoBox == null)
            {
                MessageBox.Show("Insert a Photo");
            }


        }
    }
}
