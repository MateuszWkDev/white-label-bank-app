using System.Collections.Generic;

namespace Mainframe.Data.Models
{
    public class User
    {
        public User()
        {
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        // Not hashed because this is only example mock app
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; }

        public virtual ICollection<Transaction> Transactions { get; }
    }
}
