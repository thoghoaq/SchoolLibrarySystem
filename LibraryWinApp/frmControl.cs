using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWinApp
{
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooks frmBooks = new frmBooks();
            frmBooks.Show();
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrow frmBorrow = new frmBorrow();
            frmBorrow.Show();
        }

        private void borrowManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowManager frmBorrowManager = new frmBorrowManager();
            frmBorrowManager.Show();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturn frmReturn = new frmReturn();
            frmReturn.Show();
        }
    }
}
