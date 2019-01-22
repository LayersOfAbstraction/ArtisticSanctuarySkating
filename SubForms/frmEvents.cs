using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ArtisticSanctuarySkating
{
    public partial class frmEvents : frmTemplateSubform
    {
        #region Object Declarations
        DatabaseConnection _objConnectEvents = new DatabaseConnection();
        DatabaseConnection _objConnectAttendees = new DatabaseConnection();
        DataSet _dsEvents;
        DataSet _dsAttendees; //Yes it's not assigned but it's not null!
        DataRow _dRow;

        int _intMaxEventRows;
        int _intMaxAttendeeRows;

        int _intEventCounter = 0;
        int _intAttendeeCounter = 0;
        #endregion Object Declarations

        #region Initializers
        public frmEvents()
        {
            InitializeComponent();
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            connectEvents();
            displayEventTableData();            
            connectAndDisplayMembers();            
        }
        #endregion Initializers

        #region Methods & Functions

        /// <method>
        /// Connect database object refrence for Member table, sorts  MemberName field
        /// by Primary Key and creates the max size of the table. 
        /// </method>
        private void connectAndDisplayMembers()
        {
            try
            { 
                DatabaseConnection objConnectMembers = new DatabaseConnection();
                objConnectMembers.ConnString = Properties.Settings.Default.publicConnString;
                // populate the attendees cbo
                objConnectMembers.QueryString = "SELECT * FROM (tblMembers)";
                DataSet ds = objConnectMembers.getDataset;

                cboMembers.DataSource = ds.Tables[0];
                cboMembers.DisplayMember = "MemberName";
                cboMembers.ValueMember = "MemberID";
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in connectAndDisplayMembers(): " + ex.Message);
            }

        }

        /// <method>
        /// Connect database object refrence for Events table
        /// and creates the max size of the table. 
        /// </method>
        private void connectEvents()
        {
            try
            {
                _objConnectEvents.ConnString = ArtisticSanctuarySkating.Properties.Settings.Default.publicConnString;
                _objConnectEvents.QueryString = "SELECT * FROM (tblEvents);";
                _dsEvents = _objConnectEvents.getDataset;                

                _intMaxEventRows = _dsEvents.Tables[0].Rows.Count;
             }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in connectDB(): " + ex.Message);
            }
        }

        /// <method>
        /// Get's first record in memory when the form opens.
        /// </method>
        private void displayEventTableData()
        {
            try
            {
                _dRow = _dsEvents.Tables[0].Rows[_intEventCounter];
                txtID.Text = _dRow.ItemArray.GetValue(0).ToString();
                dtpEventDate.Value = DateTime.Parse(_dRow.ItemArray.GetValue(1).ToString());
                txtEventName.Text = _dRow.ItemArray.GetValue(2).ToString();
                txtRound_Test_Level.Text = _dRow.ItemArray.GetValue(3).ToString();
                txtLocation.Text = _dRow.ItemArray.GetValue(4).ToString();
                dtpClosingDate.Value = DateTime.Parse( _dRow.ItemArray.GetValue(5).ToString());

                displayCurrentEventRecordOutOfMaxInLabel();
                lblAlert.ResetText();
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in displayEventTableData(): " + ex.Message);
            }
        }

        /// <method>
        /// Populates DGV
        /// </method>
        private void displayCurrentEventRecordOutOfMaxInLabel()
        {
            try
            {
                lblRecord.Text = (_intEventCounter + 1 + " of " + _intMaxEventRows);
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in displayCurrentRecordOutOfMaxInLabel(): " + ex.Message);
            }
        }
        #endregion Methods & Functions        

        #region EventTable - Navigation & Action buttons

        #region Navigation Buttons
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (_intEventCounter > 0)
            {
                _intEventCounter = 0;
            }
            displayEventTableData();                 
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_intEventCounter > 0)
            {
                _intEventCounter--;
            }
            displayEventTableData();            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_intEventCounter != _intMaxEventRows - 1)
            {
                _intEventCounter++;
            }
            displayEventTableData();                
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (_intEventCounter != _intMaxEventRows - 1)
            {
                _intEventCounter = _intMaxEventRows - 1;
            }
            displayEventTableData();          
        }
        #endregion Navigation Buttons        

        #region Action Buttons
        //btnNew Inherited

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dRow = _dsEvents.Tables[0].Rows[_intEventCounter];
            dRow[1] = dtpEventDate.Value;
            dRow[2] = txtEventName.Text;
            dRow[3] = txtRound_Test_Level.Text;
            dRow[4] = txtLocation.Text;
            dRow[5] = dtpClosingDate.Value;

            _objConnectEvents.updateDB(_dsEvents);
            _dsEvents.Tables[0].Rows.Add(dRow);                

            _intEventCounter += 1;
            _intEventCounter = _intMaxEventRows;

            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record saved");

            btnSave.Enabled = false;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                displayEventTableData();
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnCancel: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow dRow = _dsEvents.Tables[0].Rows[_intEventCounter];
            dRow[1] = dtpEventDate.Text;
            dRow[2] = txtEventName.Text;
            dRow[3] = txtRound_Test_Level.Text;
            dRow[4] = txtLocation.Text;
            dRow[5] = dtpClosingDate.Text;
            _objConnectEvents.updateDB(_dsEvents);

            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _dsEvents.Tables[0].Rows[_intEventCounter].Delete();
            _objConnectEvents.updateDB(_dsEvents);

            _intMaxEventRows = _dsEvents.Tables[0].Rows.Count;
            _intEventCounter--;
            displayEventTableData();
            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record updated");            
        }
        #endregion Action Buttons        

        #endregion EventTable - Navigation & Action buttons

        #region AttendeeTable - Action buttons & Textbox Search Event
        
        private void btnDeleteAttendee_Click(object sender, EventArgs e)
        {             
            DataGridViewCell cell = null;
                
            foreach (DataGridViewCell selectedCell in dgvAttendees.SelectedCells)
            {
                cell = selectedCell;

                if (cell != null)
                {
                    _dsAttendees.Tables[0].Rows[_intAttendeeCounter].Delete();
                    _objConnectAttendees.updateDB(_dsAttendees);
                    _intMaxAttendeeRows = _dsAttendees.Tables[0].Rows.Count;
                    _intAttendeeCounter--;
                }
            }
            lblAlert.ForeColor = Color.Blue;            
        }//END btnDeleteAttendee

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            PopulateAttendeesIntoDGV();            
        }

        /// <method>
        /// Searches for all Attendees equal to current EventID in textbox
        /// and displays those attendee records based on current EventID. 
        /// </method>
        private void PopulateAttendeesIntoDGV()
        {
            try
            {
                _objConnectAttendees.ConnString = Properties.Settings.Default.publicConnString;
                _objConnectAttendees.QueryString = "SELECT * FROM (qryAttendees) WHERE (EventID) = " + txtID.Text;
                DataSet attendees = _objConnectAttendees.getDataset;
                dgvAttendees.DataSource = attendees.Tables[0];
                dgvAttendees.Columns[0].ReadOnly = true;
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("Error in PopulateAttendeesIntoDGV(): " + ex.Message);
            }

        }

        private void btnAddAttendee_Click(object sender, EventArgs e)
        {
            try
            { 
                _objConnectAttendees.ConnString = Properties.Settings.Default.publicConnString;
                _objConnectAttendees.QueryString = "SELECT * FROM (tblAttendees)";
                DataSet ds = _objConnectAttendees.getDataset;
                // ID Event Member Role

                DataRow r = ds.Tables[0].NewRow();
                r["EventID"] = txtID.Text;
                r["MemberID"] = cboMembers.SelectedValue;
                r["AttendeeRole"] = txtAttendeeRole.Text;

                ds.Tables[0].Rows.Add(r);
                _objConnectAttendees.updateDB(ds);

                PopulateAttendeesIntoDGV();
            }

            catch(Exception ex)
            {
                lblAlert.Text = ("Error in btnAddAttendee(): " + ex.Message);
            }
        }
        #endregion AttendeeTable -  Action buttons             
    }
}
