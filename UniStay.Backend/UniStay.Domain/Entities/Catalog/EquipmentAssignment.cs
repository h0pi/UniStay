using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class EquipmentAssignment : BaseEntity
    {
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public int? StudentId { get; set; }
        public User? Student { get; set; }

        public int Quantity { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
