using System;
using System.Collections.Generic;
using System.Text;

namespace Mainframe.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }

        public virtual User User { get; set; }
        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
    }
}
