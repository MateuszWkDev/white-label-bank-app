namespace BankApp.Application.Models
{
    public class TransactionDTO
    {
        public int? Id { get; set; }

        public int UserId { get; set; }

        public int FromAccountId { get; set; }

        public int ToAccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
