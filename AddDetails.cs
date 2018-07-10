using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeM
{
    public partial class AddDetails : Form
    {
        conDB conn = new conDB();


        String realname;
        String FileName;
        Form container;

        public AddDetails(Form container)
        {
            InitializeComponent();
            this.container = container;
            
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

                    System.IO.File.Copy(FileName, @"C:\Users\House MoNaRa\Documents\Visual Studio 2015\Projects\EmployeeM\EmployeeM\Images\" + realname);

                    string query = "insert into Employee (EmpNIC,EmpfName,EmplName,JoinDate,Position,DOB,Email,No,Street,City,Photo,ContactNo) values ('"
                                    + txtNIC.Text + "','" + txtfName.Text + "','" + txtlName.Text + "','" + DateTime.Now + "','" + dropdPos.Text.ToString() + "','"
                                    + datetimeBD.Value.ToString() + "','" + txtEmail.Text + "','" + txtAddressNo.Text + "','" + txtAddressStreet.Text + "','"
                                    + txtAddressCity.Text + "','" + realname + "','" + txtTele.Text + "')";


                    conn.executeQry(query);

                    conn.closeConnection();

                    resetData();
                    mntForm hh = ((mntForm)container);
                    hh.Enabled = true;
                    hh.tbl.loadFirstPage();
                    hh.tbl.QuickGo();
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

            if(!ValidationClass.checkEmail(email))
            {
                MessageBox.Show("Email is Invalid");
            }

            if(!ValidationClass.checkFname(firstName))
            {
                MessageBox.Show("First Name is Invalid");
            }

            if (!ValidationClass.checkLname(lastName))
            {
                MessageBox.Show("Last Name is Invalid");
            }

            if(!ValidationClass.checkTele(teleNo))
            {
                MessageBox.Show("Contact No is Invalid");
            }

            if(!ValidationClass.checkNIC(nic))
            {
                MessageBox.Show("Invalid format");
            }

            if(photoBox==null)
            {
                MessageBox.Show("Insert a Photo");
            }



        }

        private void lblReset_MouseClick(object sender, MouseEventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
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
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            
        }
    }
}
