using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();
    }
}
