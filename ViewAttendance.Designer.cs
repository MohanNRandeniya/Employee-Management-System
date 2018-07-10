namespace EmployeeM
{
    partial class ViewAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.tbSearchAll = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchAll = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pbSearchAll = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.tbSearchAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchAll)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.dateTimePicker1);
            this.pnlBody.Controls.Add(this.pictureBox2);
            this.pnlBody.Controls.Add(this.pictureBox1);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Controls.Add(this.tbSearchAll);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1250, 670);
            this.pnlBody.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 136);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(253, 22);
            this.dateTimePicker1.TabIndex = 22;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EmployeeM.Properties.Resources.resetNormal;
            this.pictureBox2.Location = new System.Drawing.Point(1173, 608);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EmployeeM.Properties.Resources.back_button;
            this.pictureBox1.Location = new System.Drawing.Point(12, 608);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuCustomDataGrid1);
            this.panel1.Location = new System.Drawing.Point(44, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 413);
            this.panel1.TabIndex = 16;
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bunifuCustomDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGrid1.MultiSelect = false;
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.ReadOnly = true;
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.RowTemplate.Height = 24;
            this.bunifuCustomDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGrid1.ShowCellToolTips = false;
            this.bunifuCustomDataGrid1.ShowEditingIcon = false;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(1179, 413);
            this.bunifuCustomDataGrid1.TabIndex = 1;
            // 
            // tbSearchAll
            // 
            this.tbSearchAll.ColumnCount = 2;
            this.tbSearchAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.02174F));
            this.tbSearchAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.978261F));
            this.tbSearchAll.Controls.Add(this.txtSearchAll, 0, 0);
            this.tbSearchAll.Controls.Add(this.pbSearchAll, 1, 0);
            this.tbSearchAll.Location = new System.Drawing.Point(303, 107);
            this.tbSearchAll.Name = "tbSearchAll";
            this.tbSearchAll.RowCount = 1;
            this.tbSearchAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbSearchAll.Size = new System.Drawing.Size(920, 51);
            this.tbSearchAll.TabIndex = 5;
            // 
            // txtSearchAll
            // 
            this.txtSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchAll.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchAll.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtSearchAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchAll.HintForeColor = System.Drawing.Color.Empty;
            this.txtSearchAll.HintText = "";
            this.txtSearchAll.isPassword = false;
            this.txtSearchAll.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(150)))), ((int)(((byte)(234)))));
            this.txtSearchAll.LineIdleColor = System.Drawing.Color.Gray;
            this.txtSearchAll.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(150)))), ((int)(((byte)(234)))));
            this.txtSearchAll.LineThickness = 3;
            this.txtSearchAll.Location = new System.Drawing.Point(4, 9);
            this.txtSearchAll.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchAll.Name = "txtSearchAll";
            this.txtSearchAll.Size = new System.Drawing.Size(856, 33);
            this.txtSearchAll.TabIndex = 0;
            this.txtSearchAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pbSearchAll
            // 
            this.pbSearchAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSearchAll.Image = global::EmployeeM.Properties.Resources.searchNormal;
            this.pbSearchAll.Location = new System.Drawing.Point(867, 3);
            this.pbSearchAll.Name = "pbSearchAll";
            this.pbSearchAll.Size = new System.Drawing.Size(50, 45);
            this.pbSearchAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearchAll.TabIndex = 1;
            this.pbSearchAll.TabStop = false;
            this.pbSearchAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbSearchAll_MouseClick);
            this.pbSearchAll.MouseEnter += new System.EventHandler(this.pbSearchAll_MouseEnter);
            this.pbSearchAll.MouseLeave += new System.EventHandler(this.pbSearchAll_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(171)))), ((int)(((byte)(183)))));
            this.label1.Location = new System.Drawing.Point(-5, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1260, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee Attendance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewAttendance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1250, 670);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewAttendance";
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.tbSearchAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tbSearchAll;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtSearchAll;
        private System.Windows.Forms.PictureBox pbSearchAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}