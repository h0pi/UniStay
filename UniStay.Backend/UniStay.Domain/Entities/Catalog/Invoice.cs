using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class Invoice : BaseEntity
    {
        public int StudentId { get; set; }
        public User Student { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public bool EmailSent { get; set; } = false;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
