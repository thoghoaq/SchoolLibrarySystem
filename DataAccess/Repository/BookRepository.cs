using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book checkBookInstock(int bookID) => BookDAO.Instance.checkBookInstock(bookID);

        public void DeleteBook(int bookID) => BookDAO.Instance.Remove(bookID);

        public Book GetBookByID(int bookID) => BookDAO.Instance.GetBookByID(bookID);

        public IEnumerable<Book> GetBooks() => BookDAO.Instance.GetBooks();

        public List<Category> GetListCategory() => BookDAO.Instance.GetListCategory();

        public void InsertBook(Book book) => BookDAO.Instance.AddNew(book);

        public void RemoveBookToBorrow(int bookID) => BookDAO.Instance.RemoveBookToBorrow(bookID);

        public void UpdateBookToStock(int bookID) => BookDAO.Instance.UpdateBookToStock(bookID);
        public void UpdateProduct(Book book) => BookDAO.Instance.Update(book);
    }
}
