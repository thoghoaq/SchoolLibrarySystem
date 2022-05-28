using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookID);
        void InsertBook(Book book);
        void DeleteBook(int bookID);
        void UpdateProduct(Book book);
        void RemoveBookToBorrow(int bookID);

        Book checkBookInstock(int bookID);

        void UpdateBookToStock(int bookID);

        List<Category> GetListCategory();
    }
}
