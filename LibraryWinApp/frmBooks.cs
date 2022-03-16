using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmBooks : Form
    {
        public frmBooks()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
