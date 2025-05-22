using FinancialManager.Business.Core.Models;
using FinancialManager.Business.Models.Enums;

namespace FinancialManager.Business.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileType Profile { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
