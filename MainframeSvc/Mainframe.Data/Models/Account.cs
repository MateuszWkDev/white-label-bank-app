namespace Mainframe.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual User User { get; set; }
    }
}
