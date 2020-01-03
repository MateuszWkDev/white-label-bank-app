namespace BankApp.Application.Models
{
    public class AccountDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}
