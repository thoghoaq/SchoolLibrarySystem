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
    public partial class frmBooks : Form
    {
        IBookRepository bookRepository = new BookRepository();
        BindingSource source;
        public frmBooks()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBookDetails frmBookDetails = new frmBookDetails
            {
                Text = "Add product",
                InsertOrUpdate = false,
                BookRepository = bookRepository
            };
            if (frmBookDetails.ShowDialog() == DialogResult.OK)
            {
                LoadBookList();
                source.Position = source.Count - 1;
            }
        }

        public void LoadBookList()
        {
            var pros = bookRepository.GetBooks();
            try
            {
                source = new BindingSource();
                source.DataSource = pros;

                txtBookID.DataBindings.Clear();
                txtBookTitle.DataBindings.Clear();
                txtAuthor.DataBindings.Clear();
                cboCategoryID.DataBindings.Clear();
                txtBookPrice.DataBindings.Clear();

                txtBookID.DataBindings.Add("Text", source, "BookID");
                txtBookTitle.DataBindings.Add("Text", source, "BookTitle");
                txtAuthor.DataBindings.Add("Text", source, "Author");
                cboCategoryID.DataBindings.Add("Text", source, "CategoryID");
                txtBookPrice.DataBindings.Add("Text", source, "BookPrice");

                dgvBookList.DataSource = null;
                dgvBookList.DataSource = source;

                if (pros.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load books list");
            };
        }

        private void ClearText()
        {
            txtBookID.Text = string.Empty;
            txtBookTitle.Text = string.Empty;
            txtBookPrice.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            cboCategoryID.Text = string.Empty;
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            LoadBookList();
            LoadListCategory();
        }

        private Book GetBookObject()
        {
            Book pro = null;
            try
            {
                pro = new Book
                {
                    BookID = int.Parse(txtBookID.Text),
                    BookTitle = txtBookTitle.Text,
                    Author = txtAuthor.Text,
                    BookPrice = decimal.Parse(txtBookPrice.Text),
                    CategoryID = int.Parse(cboCategoryID.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get book");
            }
            return pro;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBookList();
            LoadListCategory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Do you want to delete this book?";
                string title = "Delete a book";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var book = GetBookObject();
                    bookRepository.DeleteBook(book.BookID);
                    LoadBookList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a book");
            }
        }

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBookDetails frmProductDetails = new frmBookDetails
            {
                Text = "Update member",
                InsertOrUpdate = true,
                BookInfo = GetBookObject(),
                BookRepository = bookRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadBookList();
                source.Position = source.Count - 1;
            }
        }

        private void LoadListCategory()
        {
            var listCategory = new List<Category>();
            listCategory = bookRepository.GetListCategory();
            for (int i = 0; i < listCategory.Count; i++)
            {
                cboCategoryID.Items.Add(listCategory[i].CategoryID);
            }
        }
    }
}
