using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class BedAssignment : BaseEntity
    {
        public int BedId { get; set; }
        public Bed Bed { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
