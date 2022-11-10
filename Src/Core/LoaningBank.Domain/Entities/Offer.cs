using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningBank.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public OfferStatus Status { get; set; }
    }
}
