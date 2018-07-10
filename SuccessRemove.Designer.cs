namespace EmployeeM
{
    partial class SuccessRemove
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMsgRemove = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.pnlMsgRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMsgRemove
            // 
            this.pnlMsgRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.pnlMsgRemove.Controls.Add(this.label37);
            this.pnlMsgRemove.Controls.Add(this.label38);
            this.pnlMsgRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMsgRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsgRemove.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgRemove.Name = "pnlMsgRemove";
            this.pnlMsgRemove.Size = new System.Drawing.Size(400, 200);
            this.pnlMsgRemove.TabIndex = 53;
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(171)))), ((int)(((byte)(145)))));
            this.label37.Location = new System.Drawing.Point(155, 120);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 40);
            this.label37.TabIndex = 1;
            this.label37.Text = "OK";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.DarkGreen;
            this.label38.Location = new System.Drawing.Point(25, 25);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(350, 50);
            this.label38.TabIndex = 0;
            this.label38.Text = "Successfully Removed !!!";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuccessRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.pnlMsgRemove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuccessRemove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuccessMsg";
            this.pnlMsgRemove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMsgRemove;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
    }
}