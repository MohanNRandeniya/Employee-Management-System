namespace EmployeeM
{
    partial class SuccessAdd
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
            this.pnlMsgAdd = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.pnlMsgAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMsgAdd
            // 
            this.pnlMsgAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.pnlMsgAdd.Controls.Add(this.label36);
            this.pnlMsgAdd.Controls.Add(this.label35);
            this.pnlMsgAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsgAdd.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgAdd.Name = "pnlMsgAdd";
            this.pnlMsgAdd.Size = new System.Drawing.Size(400, 200);
            this.pnlMsgAdd.TabIndex = 52;
            // 
            // label36
            // 
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(171)))), ((int)(((byte)(145)))));
            this.label36.Location = new System.Drawing.Point(155, 120);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 40);
            this.label36.TabIndex = 1;
            this.label36.Text = "OK";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.DarkGreen;
            this.label35.Location = new System.Drawing.Point(25, 25);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(350, 50);
            this.label35.TabIndex = 0;
            this.label35.Text = "Successfully Added !!!";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuccessAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.pnlMsgAdd);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuccessAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuccessAdd";
            this.pnlMsgAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMsgAdd;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
    }
}