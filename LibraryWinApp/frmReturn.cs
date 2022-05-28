using BusinessObject;
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
    public partial class frmReturn : Form
    {
        IBorrowRepository borrowRepository = new BorrowRepository();
        IBookRepository bookRepository = new BookRepository();
        BindingSource source;
        public frmReturn()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = int.Parse(txtBookID.Text);

                var pros = borrowRepository.GetBorrowByBookID(bookID);
                source = new BindingSource();
                source.DataSource = pros;
                dgvBook.DataSource = null;
                dgvBook.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load borrow list by BookID");
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int bookID = int.Parse(txtBookID.Text);
            DateTime returnDate = DateTime.Parse(dateTimePicker1.Text);
            Borrow borrow = borrowRepository.GetBorrowByBookID(bookID);
            if (returnDate.CompareTo(borrow.BorrowDate) < 0)
            {
                MessageBox.Show("Return Date Must After Borrow Date");
            } else
            {
                borrowRepository.UpdateReturnDate(bookID, returnDate);
                bookRepository.UpdateBookToStock(bookID);
                MessageBox.Show("Update Return Date Successful");
            }
        }
    }
}
