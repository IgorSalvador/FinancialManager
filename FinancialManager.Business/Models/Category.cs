using FinancialManager.Business.Core.Models;

namespace FinancialManager.Business.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
