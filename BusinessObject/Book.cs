using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public int CategoryID { get; set; }
        public decimal BookPrice { get; set; }
        public string Status { get; set; }
    }
}
