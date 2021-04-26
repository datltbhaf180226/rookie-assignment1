using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class BorrowRequestDetail
    {
        public int BorrowRequestId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public BorrowRequest BorrowRequest { get; set; }

    }
}
