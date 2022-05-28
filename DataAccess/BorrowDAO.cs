using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BorrowDAO : BaseDAL
    {
        //Singleton Pattern
        private static BorrowDAO instance = null;
        private static readonly object instanceLock = new object();
        private BorrowDAO() { }
        public static BorrowDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BorrowDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddNew(Borrow borrow)
        {
            string SQLInsert = "INSERT INTO Borrow "
                        + " VALUES(@BorrowID, @BorrowerID, @BorrowerName, @Contact, @BookID, @BorrowDate) ";
            try
            {    
               var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@BorrowID", 4, borrow.BorrowID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@BorrowerID", 4, borrow.BorrowerID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@BorrowerName", 50, borrow.BorrowerName, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Contact", 50, borrow.Contact, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@BookID", 4, borrow.BookID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@BorrowDate", 8, borrow.BorrowDate, DbType.DateTime));
                dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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

        public string GetMaxBorrowID()
        {
            string MaxBorrowID = null;
            IDataReader dataReader = null;
            try
            {
                string SQL = "Select Max(BorrowID) AS MaxBorrowID from Borrow";
                dataReader = dataProvider.GetDataReader(SQL, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    MaxBorrowID = dataReader.GetInt32(0).ToString();
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
            return MaxBorrowID;
        }

        public int GenerateBorrowID()
        {
            int borrowID = 1;
            string maxBorrowID = GetMaxBorrowID();
            if (maxBorrowID != null)
            {
                borrowID = int.Parse(maxBorrowID) + 1;
            }
            return borrowID;
         }

        public List<BorrowReturn> GetBorrows()
        {
            IDataReader dataReader = null;
            var list = new List<BorrowReturn>();
            string SQLSelect = "SELECT Borrow.BorrowID, BorrowerID, BorrowerName, Contact, BookID, BorrowDate, ReturnDate FROM Borrow "
                + "FULL JOIN [Return] ON Borrow.BorrowID = [Return].BorrowID WHERE ReturnDate IS NOT NULL";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    list.Add(new BorrowReturn
                    {
                        BorrowID = dataReader.GetInt32(0),
                        BorrowerID = dataReader.GetInt32(1),
                        BorrowerName = dataReader.GetString(2),
                        Contact = dataReader.GetString(3),
                        BookID = dataReader.GetInt32(4),
                        BorrowDate = dataReader.GetDateTime(5),
                        ReturnID = dataReader.GetInt32(0),
                        ReturnDate = dataReader.GetDateTime(6)
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

        public List<Borrow> GetBorrowsNotReturn()
        {
            IDataReader dataReader = null;
            var list = new List<Borrow>();
            string SQLSelect = "SELECT Borrow.BorrowID, BorrowerID, BorrowerName, Contact, BookID, BorrowDate, ReturnDate FROM Borrow "
                + "FULL JOIN [Return] ON Borrow.BorrowID = [Return].BorrowID WHERE ReturnDate IS NULL";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    list.Add(new Borrow
                    {
                        BorrowID = dataReader.GetInt32(0),
                        BorrowerID = dataReader.GetInt32(1),
                        BorrowerName = dataReader.GetString(2),
                        Contact = dataReader.GetString(3),
                        BookID = dataReader.GetInt32(4),
                        BorrowDate = dataReader.GetDateTime(5)
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

        public Borrow GetBorrowByBookID(int bookID)
        {
            IDataReader dataReader = null;
            Borrow borrow = null;
            string SQLSelect = "select BorrowID, BorrowerID, BorrowerName, Contact, Borrow.BookID, BorrowDate from Borrow "
                + "FULL JOIN Book ON Borrow.BookID = Book.BookID "
                + "where Borrow.BookID = @BookID AND Book.[Status] = 'Borrowed'";
            try
            {
                var param = dataProvider.CreateParameter("@BookID", 4, bookID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                while (dataReader.Read())
                {
                    borrow = new Borrow
                    {
                        BorrowID = dataReader.GetInt32(0),
                        BorrowerID = dataReader.GetInt32(1),
                        BorrowerName = dataReader.GetString(2),
                        Contact = dataReader.GetString(3),
                        BookID = dataReader.GetInt32(4),
                        BorrowDate = dataReader.GetDateTime(5)
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
            return borrow;
        }

        public void UpdateReturnDate(int bookID, DateTime returnDate)
        {
            try
            {
                Borrow pro = GetBorrowByBookID(bookID);
                if (pro != null)
                {
                    string SQL = "INSERT INTO [Return] VALUES(@ReturnID, @BorrowID, @ReturnDate)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ReturnID", 4, pro.BorrowID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@BorrowID", 4, pro.BorrowID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ReturnDate", 50, returnDate, DbType.DateTime));
                    dataProvider.Insert(SQL, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The borrow does not exist");
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
    }
}
