using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtisticSanctuarySkating.SubForms
{
    public partial class frmAttendees : frmTemplateSubform
    {
        #region Object Declarations
        DatabaseConnection _objConnect = new DatabaseConnection();
        DataSet _ds;
        DataRow _dRow;
        int _intMaxRows;
        int _intCounter = 0;        
        #endregion Object Declarations

        #region Initializers
        public frmAttendees()
        {
            InitializeComponent();
        }

        private void frmAttendees_Load(object sender, EventArgs e)
        {
            connectDB();
            displayData();
            displayEventIDs();
            displayMemberIDs();
            displayDGV();
            SelectDGVRecord();
        }
        #endregion Initializers
        
        #region Methods & Functions
        
        /// <method>
        /// Connect the database, selects the disired tables and fields
        /// and creates the max size of the table.
        /// </method>
        private void connectDB()
        {
            try
            {
                _objConnect.ConnString = ArtisticSanctuarySkating.Properties.Settings.Default.publicConnString;
                
                //Select AttendeeID
                _objConnect.QueryString = @"SELECT tblAttendees.* FROM tblMembers INNER JOIN (tblEvents INNER JOIN tblAttendees 
                                            ON tblEvents.EventID = tblAttendees.EventID) ON tblMembers.MemberID = tblAttendees.MemberID;";
                //Select EventID
                _objConnect.QueryString = @"SELECT * FROM tblAttendees";
                _ds = _objConnect.getDataset;
                _intMaxRows = _ds.Tables[0].Rows.Count;                
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in connectDB(): " + ex.Message);
            }
        }

        /// <method>
        /// Get's first record in memory when the form opens.
        /// </method>
        private void displayData()
        {
            try
            {
                _dRow = _ds.Tables[0].Rows[_intCounter];
                txtID.Text = _dRow.ItemArray.GetValue(0).ToString();
                cboEventID.Text = _dRow.ItemArray.GetValue(1).ToString();
                cboMemberID.Text = _dRow.ItemArray.GetValue(2).ToString();
                txtAttendeeRole.Text = _dRow.ItemArray.GetValue(3).ToString();                
                displayCurrentRecordOutOfMaxInLabel();
                SelectDGVRecord();
                lblAlert.ResetText();
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in loadData(): " + ex.Message);
            }
        }

        /// <method>
        /// Get's postion of the record in memory and prints it to the form.
        /// </method>
        private void displayCurrentRecordOutOfMaxInLabel()
        {
            try
            {
                lblRecord.Text = (_intCounter + 1 + " of " + _intMaxRows);
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in displayCurrentRecordOutOfMaxInLabel(): " + ex.Message);
            }
        }

        /// <method>
        /// Display all foreign key IDs in combo box drop down.
        /// </method>
        private void displayEventIDs()
        {
            try
            {
                foreach (DataRow dRow in _ds.Tables[0].Rows)
                {
                    cboEventID.Items.Add(dRow["EventID"]);
                }
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("Error in displayEventIDs(): " + ex.Message);
            }
        }

        /// <method>
        /// Display all foreign key IDs in combo box drop down.
        /// </method>
        private void displayMemberIDs()
        {
            try
            {
                foreach (DataRow dRow in _ds.Tables[0].Rows)
                {
                    cboMemberID.Items.Add(dRow["MemberID"]);
                }
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("Error in displayMemberID(): " + ex.Message);
            }
        }

        /// <method>
        /// Populates DGV
        /// </method>
        private void displayDGV()
        {
            try
            {
                foreach (DataRow dRow in _ds.Tables[0].Rows)
                {
                    dgvAttendees.DataSource = _ds.Tables[0];
                }
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in displayDGV(): " + ex.Message);
            }
        }

        /// <method>
        /// Selects an entire DGV row based on current ID cell in ID textbox.
        /// </method>
        private void SelectDGVRecord()
        {
            try
            {
                dgvAttendees.CurrentCell = dgvAttendees.Rows[_intCounter].Cells[0];
                dgvAttendees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in SelectDGVRecord(): " + ex.Message);
            }
        }
        #endregion Methods & Functions
        
        #region Navigation Buttons
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (_intCounter > 0)
                {
                    _intCounter = 0;
                }
                displayData();
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnFirst: " + ex.Message);
            }       
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (_intCounter > 0)
                {
                    _intCounter--;
                }
                displayData();
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnFirst: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (_intCounter != _intMaxRows - 1)
                {
                    _intCounter++;
                }
                displayData();
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnNext: " + ex.Message);
            }     
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_intCounter != _intMaxRows - 1)
                {
                    _intCounter = _intMaxRows - 1;
                }
                displayData();
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnLast: " + ex.Message);
            }
        }
        #endregion Navigation Buttons                
        
        #region Action Buttons

        //btnNew Inherited from frmTemplateSubform

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                displayData();
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in btnCancel: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow dRow = _ds.Tables[0].Rows[_intCounter];
            dRow[1] = cboMemberID.Text;
            dRow[2] = cboEventID.Text;
            dRow[3] = txtAttendeeRole.Text;
            _objConnect.updateDB(_ds);

            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record updated");            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            _ds.Tables[0].Rows[_intCounter].Delete();
            _objConnect.updateDB(_ds);

            _intMaxRows = _ds.Tables[0].Rows.Count;
            _intCounter--;
            displayData();
            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record updated");            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dRow = _ds.Tables[0].NewRow();
            dRow[1] = cboMemberID.Text;
            dRow[2] = cboEventID.Text;
            dRow[3] = txtAttendeeRole.Text;

            _ds.Tables[0].Rows.Add(dRow);

            _objConnect.updateDB(_ds);

            _intMaxRows += 1;
            _intCounter = _intMaxRows;

            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record saved");

            btnSave.Enabled = false;            
        }


        #endregion Action Buttons

        /// <event>
        /// Opens the current record in the 
        /// textboxes based on the grid view.
        /// </event>    
        #region Grid View Selection Event

        private void dgvAttendees_Click(object sender, EventArgs e)
        {
            try
            {
                //Counter                
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dgvAttendees.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtID.Text = row.Cells["AttendeeID"].Value.ToString();
                    cboMemberID.Text = row.Cells["MemberID"].Value.ToString();
                    cboEventID.Text = row.Cells["EventID"].Value.ToString();
                    txtAttendeeRole.Text = row.Cells["AttendeeRole"].Value.ToString();
                }
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in dgvMembers: " + ex.Message);
            }
            lblAlert.ResetText();
        }
        #endregion Grid View Selection Event         
    }
}
