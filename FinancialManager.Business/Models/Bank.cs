using FinancialManager.Business.Core.Models;

namespace FinancialManager.Business.Models
{
    public class Bank : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Agency { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
