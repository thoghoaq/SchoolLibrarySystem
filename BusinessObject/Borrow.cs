using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Borrow
    {
        public int BorrowID { get; set; }
        public int BorrowerID { get; set; }
        public string BorrowerName { get; set; }
        public string Contact { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
