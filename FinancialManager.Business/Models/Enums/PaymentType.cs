using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.Business.Models.Enums
{
    public enum PaymentType
    {
        None = 0,
        Cash = 1,
        CreditCard = 2,
        DebitCard = 3,
        BankTransfer = 4,
    }
}
