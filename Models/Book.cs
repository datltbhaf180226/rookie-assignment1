using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BorrowRequestDetail> BorrowRequestDetails { get; set; } = new List<BorrowRequestDetail>();
    }
}
