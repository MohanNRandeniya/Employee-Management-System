using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace EmployeeM
{
    public partial class EmailInfo : Form
    {
        public EmailInfo()
        {
            InitializeComponent();
            receiveMails();
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            attForm back = new attForm();
            back.Show();
            Hide();
        }

        private void btnSend_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Sending a Message", "Are you sure ?", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    Outlook._Application _app = new Outlook.Application();
                    Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                    mail.To = txtTo.Text;
                    mail.Subject = txtSubject.Text;
                    mail.Body = lblID.Text + " : " + txtID.Text + "\n" +
                                lblName.Text + " : " + txtName.Text + "\n" +
                                lblMessage.Text + " : " + txtMessage.Text ;

                    mail.Importance = Outlook.OlImportance.olImportanceNormal;
                    ((Outlook._MailItem)mail).Send();

                    MessageBox.Show("Your Message has been Successfully Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Request did not Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            clearText();
            receiveMails();
        }


        DataTable dt;
        private void receiveMails()
        {
            try
            {
                Outlook._Application _app = new Outlook.Application();
                Outlook._NameSpace _ns = _app.GetNamespace("MAPI");
                Outlook.MAPIFolder inbox = _ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                _ns.SendAndReceive(true);

                dt = new DataTable("Inbox");
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Sender Name", typeof(string));
                dt.Columns.Add("Sender Email", typeof(string));
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Body", typeof(string));
                bunifuCustomDataGrid1.DataSource = dt;

                foreach (Outlook.MailItem item in inbox.Items)
                {
                    dt.Rows.Add(new object[] { item.SentOn.ToLongDateString() + " " + item.SentOn.ToLongTimeString(), item.SenderName, item.SenderEmailAddress, item.Subject, item.HTMLBody });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearText()
        {
            txtTo.ResetText();
            txtCC.ResetText();
            txtSubject.ResetText();
            txtID.ResetText();
            txtName.ResetText();
            txtMessage.ResetText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dt.Rows.Count && e.RowIndex >= 0)
            {
                lblBody.Text = dt.Rows[e.RowIndex]["Body"].ToString();
            }
        }

        private void btnReject_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Sending a Message", "Are you sure ?", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    Outlook._Application _app = new Outlook.Application();
                    Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                    mail.To = txtTo.Text;
                    mail.Subject = "Response to Leaving Request !!!";
                    mail.Body = lblID.Text + " : " + txtID.Text + "\n" +
                                lblName.Text + " : " + txtName.Text + "\n" +
                                "Sorry, Your Request has been Rejected." ;

                    mail.Importance = Outlook.OlImportance.olImportanceNormal;
                    ((Outlook._MailItem)mail).Send();

                    MessageBox.Show("Your Message has been Successfully Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Request did not Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            clearText();
        }

        private void btnAccept_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Sending a Message", "Are you sure ?", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    Outlook._Application _app = new Outlook.Application();
                    Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                    mail.To = txtTo.Text;
                    mail.Subject = "Response to Leaving Request !!!";
                    mail.Body = lblID.Text + " : " + txtID.Text + "\n" +
                                lblName.Text + " : " + txtName.Text + "\n" +
                                "Your Request has been Accepted." ;

                    mail.Importance = Outlook.OlImportance.olImportanceNormal;
                    ((Outlook._MailItem)mail).Send();

                    MessageBox.Show("Your Message has been Successfully Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Request did not Sent !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            clearText();
        }



    }
}
