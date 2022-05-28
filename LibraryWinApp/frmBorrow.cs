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
    public partial class frmBorrow : Form
    {

        IBookRepository bookRepository = new BookRepository();
        IBorrowRepository borrowRepository = new BorrowRepository();
        public IBorrowRepository BorrowRepository { get; set; }
        public frmBorrow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BorrowRepository = borrowRepository;
            try
            {
                //Check Book instock, if instock => borrow else cancel
                Book book = bookRepository.checkBookInstock(int.Parse(txtBookID.Text));
                if (book != null)
                {
                    var borrow = new Borrow
                    {
                        BorrowID = borrowRepository.GenerateBorrowID(),
                        BorrowerID = int.Parse(txtBorrowerID.Text),
                        BorrowerName = txtName.Text,
                        Contact = txtContact.Text,
                        BookID = int.Parse(txtBookID.Text),
                        BorrowDate = DateTime.Now
                    };
                    BorrowRepository.AddNew(borrow);
                    bookRepository.RemoveBookToBorrow(book.BookID);
                    MessageBox.Show("Add successful");
                }
                else
                {
                    MessageBox.Show("Book is not Instock, can not borrow!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add a new borrow");
            }
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            dateBorrow.Value = DateTime.Now;
            dateBorrow.Enabled = false;
        }
    }
}
