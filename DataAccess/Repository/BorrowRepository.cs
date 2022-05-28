using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        public void AddNew(Borrow borrow) => BorrowDAO.Instance.AddNew(borrow);

        public int GenerateBorrowID() => BorrowDAO.Instance.GenerateBorrowID();

        public Borrow GetBorrowByBookID(int bookID) => BorrowDAO.Instance.GetBorrowByBookID(bookID);

        public IEnumerable<BorrowReturn> GetBorrows() => BorrowDAO.Instance.GetBorrows();

        public IEnumerable<Borrow> GetBorrowsNotReturn() => BorrowDAO.Instance.GetBorrowsNotReturn();

        public void UpdateReturnDate(int bookID, DateTime returnDate) => BorrowDAO.Instance.UpdateReturnDate(bookID,returnDate);
    }
}
