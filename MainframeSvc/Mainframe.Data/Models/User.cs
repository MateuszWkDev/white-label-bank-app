using System;
using System.Collections.Generic;
using System.Text;

namespace Mainframe.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login  { get; set; }
        //Not hashed because this is only example mock app
        public string Password { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
