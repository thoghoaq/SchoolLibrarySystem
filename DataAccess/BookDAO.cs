using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* @author: ThongHT 
*/

namespace DataAccess
{
    public class BookDAO : BaseDAL
    {
        public List<Book> GetBooks()
        {
            IDataReader dataReader = null;
            var list = new List<Book>();
            string SQLSelect = "select BookID, BookTitle, Author, CategoryID, BookPrice, [Status] from Book";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    list.Add(new Book
                    {
                        BookID = dataReader.GetInt32(0),
                        BookTitle = dataReader.GetString(1),
                        Author = dataReader.GetString(2),
                        CategoryID = dataReader.GetInt32(3),
                        BookPrice = dataReader.GetDecimal(4),
                        Status = dataReader.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return list;
        }

        //Singleton Pattern
        private static BookDAO instance = null;
        private static readonly object instanceLock = new object();
        private BookDAO() { }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }

        public Book GetBookByID(int bookID)
        {
            Book pro = null;
            IDataReader dataReader = null;
            string SQL = "select BookID, BookTitle, Author, CategoryID, BookPrice, [Status] from Book where BookID = @BookID";
            try
            {
                var param = dataProvider.CreateParameter("@BookID", 4, bookID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQL, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    pro = new Book
                    {
                        BookID = dataReader.GetInt32(0),
                        BookTitle = dataReader.GetString(1),
                        Author = dataReader.GetString(2),
                        CategoryID = dataReader.GetInt32(3),
                        BookPrice = dataReader.GetDecimal(4),
                        Status = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return pro;
        }

        public void AddNew(Book book)
        {
            try
            {
                Book pro = GetBookByID(book.BookID);
                if (pro == null)
                {
                    string SQL = "INSERT INTO Book "
                        + " VALUES(@BookID, @BookTitle, @Author, @CategoryID, @BookPrice, @Status) ";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@BookID", 4, book.BookID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@BookTitle", 50, book.BookTitle, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Author", 50, book.Author, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@CategoryID", 4, book.CategoryID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@BookPrice", 8, book.BookPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@Status", 50, book.Status, DbType.String));
                    dataProvider.Insert(SQL, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The book is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Book product)
        {
            try
            {
                Book pro = GetBookByID(product.BookID);
                if (pro != null)
                {
                    string SQL = "Update Book set BookTitle = @BookTitle, Author = @Author, CategoryID = @CategoryID, BookPrice = @BookPrice where BookID = @BookID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@BookID", 4, product.BookID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@BookTitle", 50, product.BookTitle, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Author", 50, product.Author, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@CategoryID", 50, product.CategoryID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@BookPrice", 50, product.BookPrice, DbType.Decimal));
                    dataProvider.Update(SQL, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The book does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int productID)
        {
            try
            {
                Book pro = GetBookByID(productID);
                if (pro != null && pro.Status.Equals("Instock"))
                {
                    string SQL = "DELETE FROM Book WHERE BookID = @BookID";
                    var param = dataProvider.CreateParameter("@BookID", 4, productID, DbType.Int32);
                    dataProvider.Delete(SQL, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The book does not already exist or You can not remove this");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void RemoveBookToBorrow(int productID)
        {
            try
            {
                Book pro = GetBookByID(productID);
                if (pro != null)
                {
                    string SQL = "Update Book set [Status] = 'Borrowed' where BookID = @BookID";
                    var param = dataProvider.CreateParameter("@BookID", 4, pro.BookID, DbType.Int32);
                    dataProvider.Update(SQL, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The book does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Book checkBookInstock(int bookID)
        {
            Book book = GetBookByID(bookID);
            if (book != null)
            {
                if (book.Status.Equals("Instock"))
                {
                    return book;
                }
            }
            return null;
        }

        public void UpdateBookToStock(int bookID)
        {
            try
            {
                Book book = GetBookByID(bookID);
                if (book != null)
                {
                    string SQL = "Update Book set [Status] = 'Instock' where BookID = @BookID";
                    var param = dataProvider.CreateParameter("@BookID", 4, book.BookID, DbType.Int32);
                    dataProvider.Update(SQL, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The book does not already exist");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally
            {
                CloseConnection();
            }
            
        }

        public List<Category> GetListCategory()
        {
            IDataReader dataReader = null;
            var list = new List<Category>();
            string SQLSelect = "select CategoryID, CategoryName from Category";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    list.Add(new Category
                    {
                        CategoryID = dataReader.GetInt32(0),
                        CategoryName = dataReader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return list;
        }
    }
}
