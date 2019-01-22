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
    public partial class frmMembers : frmTemplateSubform
    {
        #region Object Declarations
        DatabaseConnection _objConnect = new DatabaseConnection();
        DataSet _ds;
        DataRow _dRow;
        int _intMaxRows;
        int _intCounter = 0;        
        #endregion Object Declarations

        #region Initializers
        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {            
            connectDB();
            displayData();
            displayMemberTypeIDs();
            displayDGV();
            SelectDGVRecord();          
        }
        #endregion Initializers
        
        #region Methods/Functions
        
        /// <method>
        /// Connect the database, selects the disired tables and fields
        /// and creates the max size of the table.
        /// </method>
        private void connectDB()
        {
            try
            {
                _objConnect.ConnString = ArtisticSanctuarySkating.Properties.Settings.Default.publicConnString;
                _objConnect.QueryString = @"SELECT tblMembers.* FROM tblMemberTypes INNER JOIN tblMembers 
                                            ON tblMemberTypes.MemberTypeID = tblMembers.MemberTypeID ORDER BY MemberName";
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
                cboMemberTypeID.Text = _dRow.ItemArray.GetValue(1).ToString();                
                txtMemberName.Text = _dRow.ItemArray.GetValue(2).ToString();
                txtAddress.Text = _dRow.ItemArray.GetValue(3).ToString();
                txtContactInfo.Text = _dRow.ItemArray.GetValue(4).ToString();
                dtpRegisterDate.Text = _dRow.ItemArray.GetValue(5).ToString();
                txtUsername.Text = _dRow.ItemArray.GetValue(6).ToString();
                txtPassword.Text = _dRow.ItemArray.GetValue(7).ToString();
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
                lblRecord.Text = (_intCounter +1 + " of " + _intMaxRows);
            }

            catch(Exception ex)
            {
                lblAlert.Text = ("ERROR in displayCurrentRecordOutOfMaxInLabel(): " + ex.Message);
            }
        }

        /// <method>
        /// Display all foreign key IDs in combo box drop down.
        /// </method>
        private void displayMemberTypeIDs()
        {
            try
            {
                foreach (DataRow dRow in _ds.Tables[0].Rows)
                {
                    cboMemberTypeID.Items.Add(dRow["MemberTypeID"]);
                }
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("Error in displayMemberTypeID(): " + ex.Message);
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
                    dgvMembers.DataSource = _ds.Tables[0];
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
                dgvMembers.CurrentCell = dgvMembers.Rows[_intCounter].Cells[0];
                dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in SelectDGVRecord(): " + ex.Message);
            }
        }       

        #endregion Methods/Functions

        #region Navigation Buttons

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (_intCounter  > 0)
            {
                _intCounter = 0;
            }
            displayData();
            SelectDGVRecord();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_intCounter > 0)
            {
                _intCounter--;
            }
            displayData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_intCounter != _intMaxRows - 1)
            {
                _intCounter++;
            }        
            displayData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        { 
            if (_intCounter != _intMaxRows -1)
            {
                _intCounter = _intMaxRows -1;
            }            
            displayData();            
        }
        #endregion Navigation Buttons

        #region Action Buttons        
        //btnNew Inherited from frmTemplateSubform
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            displayData();            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                DataRow dRow = _ds.Tables[0].Rows[_intCounter];
                dRow[1] = cboMemberTypeID.Text;
                dRow[2] = txtMemberName.Text;
                dRow[3] = txtAddress.Text;
                dRow[4] = txtContactInfo.Text;
                dRow[5] = dtpRegisterDate.Text;
                dRow[6] = txtUsername.Text;
                dRow[7] = txtPassword.Text;
                _objConnect.updateDB(_ds);

                lblAlert.ForeColor = Color.Blue;
                lblAlert.Text = ("Record updated");            
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
                DataRow dRow = _ds.Tables[0].NewRow();
                dRow[1] = cboMemberTypeID.Text;
                dRow[2] = txtMemberName.Text;
                dRow[3] = txtAddress.Text;
                dRow[4] = txtContactInfo.Text;
                dRow[5] = dtpRegisterDate.Text;
                dRow[6] = txtUsername.Text;
                dRow[7] = txtPassword.Text;
                
                _ds.Tables[0].Rows.Add(dRow);

                _objConnect.updateDB(_ds);

                _intMaxRows += 1;
                _intCounter = _intMaxRows ;

                lblAlert.ForeColor = Color.Blue;
                lblAlert.Text = ("Record saved");

                btnSave.Enabled = false;
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

        #endregion Action Buttons                                

        #region Grid View Selection Event        
        
        /// <event>
        /// Opens the current record in the 
        /// textboxes based on the grid view.
        /// </event>        
        private void dgvMembers_Click(object sender, EventArgs e)
        {
            try
            {
                //Counter                
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dgvMembers.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtID.Text = row.Cells["MemberID"].Value.ToString();
                    cboMemberTypeID.Text = row.Cells["MemberTypeID"].Value.ToString();
                    txtMemberName.Text = row.Cells["MemberName"].Value.ToString();
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                    txtContactInfo.Text = row.Cells["ContactInfo"].Value.ToString();
                    dtpRegisterDate.Text = row.Cells["RegisterDate"].Value.ToString();
                    txtUsername.Text = row.Cells["MemberUsername"].Value.ToString();
                }
                lblAlert.ResetText();
            }
            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in dgvMembers: " + ex.Message);
            }
        }        
        #endregion Grid View Selection Event
    }
}
