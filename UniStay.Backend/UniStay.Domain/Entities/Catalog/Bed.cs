using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;

namespace UniStay.Domain.Entities.Catalog
{
    public class Bed : BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int BedNumber { get; set; }

        public ICollection<BedAssignment> BedAssignments { get; set; } = new List<BedAssignment>();
    }
}
