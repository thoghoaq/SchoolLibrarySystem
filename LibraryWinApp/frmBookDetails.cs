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
    public partial class frmBookDetails : Form
    {
        public IBookRepository BookRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Book BookInfo { get; set; }
        public frmBookDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtBookPrice.Text) < 0)
                {
                    throw new Exception("Book Price must be larger than 0");
                } else
                {
                    var pro = new Book
                    {
                        BookID = int.Parse(txtBookID.Text),
                        BookTitle = txtBookTitle.Text,
                        Author = txtAuthor.Text,
                        CategoryID = GetCategoryIDFromName(cboCategoryID.Text),
                        BookPrice = decimal.Parse(txtBookPrice.Text),
                        Status = "Instock"
                    };
                    if (InsertOrUpdate == false)
                    {
                        BookRepository.InsertBook(pro);
                        MessageBox.Show("Add successful");
                    }
                    else
                    {
                        BookRepository.UpdateProduct(pro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new book" : "Update a book");
            }
        }

        private void frmBookDetails_Load(object sender, EventArgs e)
        {
            LoadListCategory();
            txtBookID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtBookID.Text = BookInfo.BookID.ToString();
                txtBookTitle.Text = BookInfo.BookTitle.ToString();
                txtAuthor.Text = BookInfo.Author.ToString();
                cboCategoryID.Text = GetCategoryNameFromID(BookInfo.CategoryID).ToString();
                txtBookPrice.Text = BookInfo.BookPrice.ToString();
            }
        }

        private void LoadListCategory()
        {
            var listCategory = new List<Category>();
            listCategory = BookRepository.GetListCategory();
            for (int i = 0; i < listCategory.Count; i++)
            {
                cboCategoryID.Items.Add(listCategory[i].CategoryName);
            }
        }

        private int GetCategoryIDFromName(string categoryName)
        {
            int categoryID = 1;
            var listCategory = new List<Category>();
            listCategory = BookRepository.GetListCategory();
            for (int i = 0; i < listCategory.Count; i++)
            {
                if (listCategory[i].CategoryName.Equals(categoryName))
                {
                    categoryID = listCategory[i].CategoryID;
                }
            }
            return categoryID;
        }

        private string GetCategoryNameFromID(int categoryID)
        {
            string categoryName = "Ngu Ngon";
            var listCategory = new List<Category>();
            listCategory = BookRepository.GetListCategory();
            for (int i = 0; i < listCategory.Count; i++)
            {
                if (listCategory[i].CategoryID == categoryID)
                {
                    categoryName = listCategory[i].CategoryName;
                }
            }
            return categoryName;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
