using FinancialManager.Business.Core.Models;
using FinancialManager.Business.Models.Enums;

namespace FinancialManager.Business.Models
{
    public class Transaction : Entity
    {
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BankAccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreateOn { get; set; }
        public string CreatedBy { get; set; }

        public Category Category { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
