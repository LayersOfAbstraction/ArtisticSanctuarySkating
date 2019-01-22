namespace ArtisticSanctuarySkating
{
    partial class frmEvents
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
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtRound_Test_Level = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpClosingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvAttendees = new System.Windows.Forms.DataGridView();
            this.AttendeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendeeRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteAttendee = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddAttendee = new System.Windows.Forms.Button();
            this.txtAttendeeRole = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMembers = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(110, 60);
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 63);
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(110, 112);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(208, 20);
            this.txtEventName.TabIndex = 35;
            // 
            // txtRound_Test_Level
            // 
            this.txtRound_Test_Level.Location = new System.Drawing.Point(110, 138);
            this.txtRound_Test_Level.Name = "txtRound_Test_Level";
            this.txtRound_Test_Level.Size = new System.Drawing.Size(208, 20);
            this.txtRound_Test_Level.TabIndex = 36;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(110, 164);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(208, 20);
            this.txtLocation.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Event Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Event Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Round Test Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "ClosingDate";
            // 
            // dtpClosingDate
            // 
            this.dtpClosingDate.Location = new System.Drawing.Point(110, 190);
            this.dtpClosingDate.Name = "dtpClosingDate";
            this.dtpClosingDate.Size = new System.Drawing.Size(208, 20);
            this.dtpClosingDate.TabIndex = 44;
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Location = new System.Drawing.Point(110, 87);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(208, 20);
            this.dtpEventDate.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 31);
            this.label7.TabIndex = 46;
            this.label7.Text = "Events";
            // 
            // dgvAttendees
            // 
            this.dgvAttendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendeeID,
            this.EventID,
            this.MemberName,
            this.AttendeeRole});
            this.dgvAttendees.Location = new System.Drawing.Point(0, 423);
            this.dgvAttendees.Name = "dgvAttendees";
            this.dgvAttendees.Size = new System.Drawing.Size(599, 150);
            this.dgvAttendees.TabIndex = 47;
            // 
            // AttendeeID
            // 
            this.AttendeeID.DataPropertyName = "AttendeeID";
            this.AttendeeID.HeaderText = "AttendeeID";
            this.AttendeeID.Name = "AttendeeID";
            this.AttendeeID.Visible = false;
            // 
            // EventID
            // 
            this.EventID.DataPropertyName = "EventID";
            this.EventID.HeaderText = "EventID";
            this.EventID.Name = "EventID";
            this.EventID.Visible = false;
            // 
            // MemberName
            // 
            this.MemberName.DataPropertyName = "MemberName";
            this.MemberName.HeaderText = "Attendee";
            this.MemberName.Name = "MemberName";
            // 
            // AttendeeRole
            // 
            this.AttendeeRole.DataPropertyName = "AttendeeRole";
            this.AttendeeRole.HeaderText = "Role";
            this.AttendeeRole.Name = "AttendeeRole";
            // 
            // btnDeleteAttendee
            // 
            this.btnDeleteAttendee.Location = new System.Drawing.Point(6, 30);
            this.btnDeleteAttendee.Name = "btnDeleteAttendee";
            this.btnDeleteAttendee.Size = new System.Drawing.Size(108, 23);
            this.btnDeleteAttendee.TabIndex = 49;
            this.btnDeleteAttendee.Text = "Delete Attendee";
            this.btnDeleteAttendee.UseVisualStyleBackColor = true;
            this.btnDeleteAttendee.Click += new System.EventHandler(this.btnDeleteAttendee_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteAttendee);
            this.groupBox4.Location = new System.Drawing.Point(605, 431);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 69);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attendees";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddAttendee);
            this.groupBox5.Controls.Add(this.txtAttendeeRole);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cboMembers);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(338, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 152);
            this.groupBox5.TabIndex = 56;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Members";
            // 
            // btnAddAttendee
            // 
            this.btnAddAttendee.Location = new System.Drawing.Point(81, 110);
            this.btnAddAttendee.Name = "btnAddAttendee";
            this.btnAddAttendee.Size = new System.Drawing.Size(102, 23);
            this.btnAddAttendee.TabIndex = 60;
            this.btnAddAttendee.Text = "Add Attendee";
            this.btnAddAttendee.UseVisualStyleBackColor = true;
            this.btnAddAttendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // txtAttendeeRole
            // 
            this.txtAttendeeRole.Location = new System.Drawing.Point(62, 77);
            this.txtAttendeeRole.Name = "txtAttendeeRole";
            this.txtAttendeeRole.Size = new System.Drawing.Size(121, 20);
            this.txtAttendeeRole.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Role";
            // 
            // cboMembers
            // 
            this.cboMembers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembers.FormattingEnabled = true;
            this.cboMembers.Location = new System.Drawing.Point(62, 27);
            this.cboMembers.Name = "cboMembers";
            this.cboMembers.Size = new System.Drawing.Size(121, 21);
            this.cboMembers.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Member";
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 632);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvAttendees);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpEventDate);
            this.Controls.Add(this.dtpClosingDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtRound_Test_Level);
            this.Controls.Add(this.txtEventName);
            this.Name = "frmEvents";
            this.Text = "Events";
            this.Load += new System.EventHandler(this.frmEvents_Load);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtEventName, 0);
            this.Controls.SetChildIndex(this.txtRound_Test_Level, 0);
            this.Controls.SetChildIndex(this.txtLocation, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dtpClosingDate, 0);
            this.Controls.SetChildIndex(this.dtpEventDate, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.dgvAttendees, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.TextBox txtRound_Test_Level;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpClosingDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.Button btnDeleteAttendee;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddAttendee;
        private System.Windows.Forms.TextBox txtAttendeeRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMembers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeRole;
    }
}