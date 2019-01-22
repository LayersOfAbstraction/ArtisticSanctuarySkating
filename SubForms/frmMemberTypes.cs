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
    public partial class frmMemberTypes : frmTemplateSubform
    {
        #region Object Declarations
        DatabaseConnection _objConnect = new DatabaseConnection();
        DataSet _ds;
        DataRow _dRow;
        int _intMaxRows;
        int _intCounter = 0;
        #endregion Object Declarations

        #region Initializers
        public frmMemberTypes()
        {
            InitializeComponent();
        }

        private void frmMemberTypes_Load(object sender, EventArgs e)
        {
            connectDB();
            displayData();
            displayDGV();
            SelectDGVRecord();
        }
        #endregion Initializers

        #region Methods/Functions

        /// <method>
        /// Connect the database, select the disired tables and fields
        /// and creates the max size of the table.
        /// </method>
        private void connectDB()
        {
            try
            {
                _objConnect.ConnString = ArtisticSanctuarySkating.Properties.Settings.Default.publicConnString;                
                _objConnect.QueryString = "SELECT * FROM tblMemberTypes";
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
                txtMemberType.Text = _dRow.ItemArray.GetValue(1).ToString();
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
        /// Populates DGV 
        /// </method>
        private void displayDGV()
        {
            try
            {
                foreach (DataRow dRow in _ds.Tables[0].Rows)
                {
                    dgvMemberTypes.DataSource = _ds.Tables[0];                    
                }                
            }

            catch (Exception ex)
            {
                lblAlert.Text = ("ERROR in displayDGV(): " + ex.Message);
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
        /// Selects an entire DGV row based on current ID cell in ID textbox.
        /// </method>
        private void SelectDGVRecord()
        {
            try
            {
                dgvMemberTypes.CurrentCell = dgvMemberTypes.Rows[_intCounter].Cells[0];
                dgvMemberTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            }
            displayData();            
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
            if (_intCounter != _intMaxRows - 1)
            {
                _intCounter = _intMaxRows - 1;
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
            dRow[1] = txtMemberType.Text;
            _objConnect.updateDB(_ds);

            lblAlert.ForeColor = Color.Blue;
            lblAlert.Text = ("Record updated");            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dRow = _ds.Tables[0].NewRow();
            dRow[1] = txtMemberType.Text;               

            _ds.Tables[0].Rows.Add(dRow);

            _objConnect.updateDB(_ds);

            _intMaxRows += 1;
            _intCounter = _intMaxRows;

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
        private void dgvMemberTypes_Click(object sender, EventArgs e)
        {
            try
            {
                //Counter
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dgvMemberTypes.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtID.Text = row.Cells["MemberTypeID"].Value.ToString();
                    txtMemberType.Text = row.Cells["MemberType"].Value.ToString();
                }
            }
            catch (Exception ex)
            {                
                lblAlert.Text = ("ERROR in connectDB(): " + ex.Message);            
            }
            lblAlert.ResetText();
        }//http://www.c-sharpcorner.com/Blogs/14790/display-selected-row-from-datagrid-to-textboxes.aspx       
        #endregion 
    }
}
