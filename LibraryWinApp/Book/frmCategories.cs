using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibrarySystem
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            btnnew_Click(sender, e);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
        }

        private void dtglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
