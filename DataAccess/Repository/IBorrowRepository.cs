using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBorrowRepository
    {
        void AddNew(Borrow borrow);
        int GenerateBorrowID();

        IEnumerable<BorrowReturn> GetBorrows();
        IEnumerable<Borrow> GetBorrowsNotReturn();
        Borrow GetBorrowByBookID(int bookID);

        void UpdateReturnDate(int bookID, DateTime returnDate);
    }
}
