using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningBank.Domain.Entities
{
    internal class BankInquiry : Inquiry
    {
        public Guid? OfferId { get; set; }
    }
}
