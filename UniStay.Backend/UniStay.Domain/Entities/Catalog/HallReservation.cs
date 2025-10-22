using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class HallReservation : BaseEntity
    {
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }

        public DateTime ReservedAt { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
