using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtisticSanctuarySkating.SubForms;

namespace ArtisticSanctuarySkating
{
    public partial class frmMainMenu : Form
    {
        frmMembers membersForm = new frmMembers();
        frmMemberTypes memberTypesForm = new frmMemberTypes();
        frmPayments paymentsForm = new frmPayments();
        frmEvents eventsForm = new frmEvents();
        frmAttendees attendeesForm = new frmAttendees();
        
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {            
            membersForm.ShowDialog();            
        }

        private void btnMemberTypes_Click(object sender, EventArgs e)
        {
            memberTypesForm.ShowDialog();
        }        

        private void btnPayments_Click(object sender, EventArgs e)
        {
            paymentsForm.ShowDialog();
        }        

        private void btnEvents_Click(object sender, EventArgs e)
        {
            eventsForm.ShowDialog();
        }        

        private void btnAttendees_Click(object sender, EventArgs e)
        {
            attendeesForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
