namespace EmployeeM
{
    partial class SuccessUpdate
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
            this.pnlMsgUpdate = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.pnlMsgUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMsgUpdate
            // 
            this.pnlMsgUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.pnlMsgUpdate.Controls.Add(this.label39);
            this.pnlMsgUpdate.Controls.Add(this.label40);
            this.pnlMsgUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsgUpdate.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgUpdate.Name = "pnlMsgUpdate";
            this.pnlMsgUpdate.Size = new System.Drawing.Size(400, 200);
            this.pnlMsgUpdate.TabIndex = 54;
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(171)))), ((int)(((byte)(145)))));
            this.label39.Location = new System.Drawing.Point(155, 120);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 40);
            this.label39.TabIndex = 1;
            this.label39.Text = "OK";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.DarkGreen;
            this.label40.Location = new System.Drawing.Point(25, 25);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(350, 50);
            this.label40.TabIndex = 0;
            this.label40.Text = "Successfully Updated !!!";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuccessUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.pnlMsgUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuccessUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuccessUpdate";
            this.pnlMsgUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMsgUpdate;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
    }
}