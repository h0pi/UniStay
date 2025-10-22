using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class Payment : BaseEntity
    {
        public int StudentId { get; set; }
        public User Student { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;

        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}
