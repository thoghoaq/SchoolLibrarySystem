using DataAccess.Repository;
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
    public partial class frmBorrowManager : Form
    {
        IBorrowRepository borrowRepository = new BorrowRepository();
        public frmBorrowManager()
        {
            InitializeComponent();
        }

        public void LoadBorrowList()
        {
            var pros = borrowRepository.GetBorrows();
            BindingSource source;
            try
            {
                source = new BindingSource();
                source.DataSource = pros;


                dgvBorrowList.DataSource = null;
                dgvBorrowList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load borrow list");
            };
        }

        public void LoadBorrowNotReturnList()
        {
            var pros = borrowRepository.GetBorrowsNotReturn();
            BindingSource source;
            try
            {
                source = new BindingSource();
                source.DataSource = pros;


                dgvBorrowNotReturn.DataSource = null;
                dgvBorrowNotReturn.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load borrow list");
            };
        }

        private void dgvBorrowList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBorrowManager_Load(object sender, EventArgs e)
        {
            LoadBorrowList();
            LoadBorrowNotReturnList();
        }
    }
}
