namespace ArtisticSanctuarySkating.SubForms
{
    partial class frmAttendees
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
            this.cboEventID = new System.Windows.Forms.ComboBox();
            this.cboMemberID = new System.Windows.Forms.ComboBox();
            this.txtAttendeeRole = new System.Windows.Forms.TextBox();
            this.dgvAttendees = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // cboEventID
            // 
            this.cboEventID.FormattingEnabled = true;
            this.cboEventID.Location = new System.Drawing.Point(87, 39);
            this.cboEventID.Name = "cboEventID";
            this.cboEventID.Size = new System.Drawing.Size(208, 21);
            this.cboEventID.TabIndex = 34;
            // 
            // cboMemberID
            // 
            this.cboMemberID.FormattingEnabled = true;
            this.cboMemberID.Location = new System.Drawing.Point(87, 66);
            this.cboMemberID.Name = "cboMemberID";
            this.cboMemberID.Size = new System.Drawing.Size(208, 21);
            this.cboMemberID.TabIndex = 35;
            // 
            // txtAttendeeRole
            // 
            this.txtAttendeeRole.Location = new System.Drawing.Point(87, 94);
            this.txtAttendeeRole.Name = "txtAttendeeRole";
            this.txtAttendeeRole.Size = new System.Drawing.Size(208, 20);
            this.txtAttendeeRole.TabIndex = 36;
            // 
            // dgvAttendees
            // 
            this.dgvAttendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendees.Location = new System.Drawing.Point(0, 422);
            this.dgvAttendees.Name = "dgvAttendees";
            this.dgvAttendees.Size = new System.Drawing.Size(749, 150);
            this.dgvAttendees.TabIndex = 37;
            this.dgvAttendees.Click += new System.EventHandler(this.dgvAttendees_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Event ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Member ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Attendee Role";
            // 
            // frmAttendees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 632);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAttendees);
            this.Controls.Add(this.txtAttendeeRole);
            this.Controls.Add(this.cboMemberID);
            this.Controls.Add(this.cboEventID);
            this.Name = "frmAttendees";
            this.Text = "Attendees";
            this.Load += new System.EventHandler(this.frmAttendees_Load);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboEventID, 0);
            this.Controls.SetChildIndex(this.cboMemberID, 0);
            this.Controls.SetChildIndex(this.txtAttendeeRole, 0);
            this.Controls.SetChildIndex(this.dgvAttendees, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEventID;
        private System.Windows.Forms.ComboBox cboMemberID;
        private System.Windows.Forms.TextBox txtAttendeeRole;
        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}