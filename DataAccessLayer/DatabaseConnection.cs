using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;

namespace ArtisticSanctuarySkating
{
    /// <class>
    /// Connects Database, querys and processes external methods and functions
    /// like SELECT,INSERT,UPDATE and DELETE.
    /// </class>
    class DatabaseConnection
    {
        #region Object Declarations 
        string _strConn;
        string _strQuery;
        OleDbDataAdapter _da;
        
        #endregion Object Declarations 
              
        #region Properties
        public string QueryString
        {
            set { _strQuery = (value); }
        }
        
        public string ConnString
        {
            set { _strConn = (value); }
        }        

        public DataSet getDataset
        {
            get { return CreateDataSet(); }
        }        
        #endregion Properties

        #region Methods & Functions
        
        /// <function>
        /// Opens and closes database and logs any errors to 
        /// text file upon compiling.
        /// </function>
        /// <returns>database table to user</returns>
        private DataSet CreateDataSet()
        {
            OleDbConnection conn = new OleDbConnection(_strConn);
            _da = new OleDbDataAdapter(_strQuery, _strConn);
            DataSet ds = new DataSet(); 

            try
            {
                conn.Open();
                _da.Fill(ds, "Table_Data_1");                                
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR in getDataSet(): " + ex.Message);
                FileLogger fw = new FileLogger("ErrorLog", "Text");
                fw.write(ex.ToString());
            }

            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <method>
        /// Processes external queries and allows them to change data in Database.
        /// Logs any errors to text file if query is illogical to C# compiler.
        /// </method>
        /// <param name="ds">External Dataset is 
        /// written into this one and altered. </param>
        public void updateDB(DataSet ds)
        {
            try
            {
                OleDbCommandBuilder cb = new OleDbCommandBuilder(_da);
                cb.DataAdapter.Update(ds.Tables[0]);
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR in updateDB(): " + ex.Message);
                FileLogger fw = new FileLogger("ErrorLog", "Text");
                fw.write(ex.ToString());
            }
        }
        #endregion Methods & Functions
    }
}
