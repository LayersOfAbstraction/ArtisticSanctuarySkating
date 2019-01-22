using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtisticSanctuarySkating
{
    public partial class frmPayments : frmTemplateSubform
    {
        #region Object Declarations
        DatabaseConnection _objConnect = new DatabaseConnection();
        DataSet _ds;
        DataRow _dRow;
        int _intMaxRows;
        int _intCounter = 0;
        #endregion Object Declarations

        #region Initializers 

        public frmPayments()
        {
            InitializeComponent();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            connectDB();
            displayData();
            displayMemberIDs();
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
                _objConnect.QueryString = @"SELECT tblPayments.* FROM tblMembers INNER JOIN tblPayments 
                                            ON tblMembers.MemberID = tblPayments.MemberID;"; 
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
                cboMemberID.Text = _dRow.ItemArray.GetValue(1).ToString();
                
                decimal decAnnualPayment = Convert.ToDecimal(_dRow.ItemArray.GetValue(2));
                txtAnnualPayment.Text = decAnnualPayment.ToString();

                decimal decMonthlyPayment = Convert.ToDecimal(_dRow.ItemArray.GetValue(3));
                txtMonthlyPayment.Text = decMonthlyPayment.ToString();
                
                dtpPaymentDate.Text = _dRow.ItemArray.GetValue(4).ToString();
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
        /// Display member all MemberType ID's in combo box drop down.
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
                lblAlert.Text = ("Error in displayMemberIDs(): " + ex.Message);
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
                    dgvPayments.DataSource = _ds.Tables[0];
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
                dgvPayments.CurrentCell = dgvPayments.Rows[_intCounter].Cells[0];
                dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            if (_intCounter > 0)
            {
                _intCounter = 0;
                displayData();
            }            
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_intCounter > 0)
            {
                _intCounter--;
                displayData();
            }            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_intCounter != _intMaxRows -1)
            {
                _intCounter++;
                displayData();
            }            
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (_intCounter != _intMaxRows -1)
            {
                _intCounter = _intMaxRows -1;
                displayData();
            }
        }
        #endregion Navigation Buttons        

        #region Action Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dRow = _ds.Tables[0].NewRow();
            dRow[1] = cboMemberID.Text;
                
            decimal decAnnualPayment = Convert.ToDecimal(_dRow.ItemArray.GetValue(2));
            dRow[2] = txtAnnualPayment.Text += decAnnualPayment.ToString();

            decimal decMonthlyPayment = Convert.ToDecimal(_dRow.ItemArray.GetValue(3));
            dRow[3] = txtMonthlyPayment.Text += decMonthlyPayment.ToString();

            dRow[4] = dtpPaymentDate.Text;
            _ds.Tables[0].Rows.Add(dRow);
            _objConnect.updateDB(_ds);
            _intMaxRows += 1;
            _intCounter = _intMaxRows;
            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record saved");

            btnSave.Enabled = false;            
        }

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
            dRow[1] = cboMemberID.Text;
            dRow[2] = txtAnnualPayment.Text;
            dRow[3] = txtMonthlyPayment.Text;
            dRow[4] = dtpPaymentDate.Text;
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
        #endregion Action Buttons        

        #region Grid View Selection Event

        /// <event>
        /// Opens the current record in the 
        /// textboxes based on the grid view.
        /// </event>    
        private void dgvPayments_Click(object sender, EventArgs e)
        {
            try
            {
                //Counter                
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dgvPayments.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtID.Text = row.Cells["PaymentID"].Value.ToString();
                    cboMemberID.Text = row.Cells["MemberID"].Value.ToString();
                    txtAnnualPayment.Text = row.Cells["AnnualPayment"].Value.ToString();
                    txtMonthlyPayment.Text = row.Cells["MonthlyPayment"].Value.ToString();
                    dtpPaymentDate.Text = row.Cells["PaymentDate"].Value.ToString();                    
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
