using FinancialManager.Business.Core.Models;

namespace FinancialManager.Business.Models
{
    public class BankAccount : Entity
    {
        public Guid UserId { get; set; }
        public Guid BankId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public User User { get; set; }
        public Bank Bank { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
