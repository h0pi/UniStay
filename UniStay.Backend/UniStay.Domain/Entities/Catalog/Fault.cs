using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class Fault : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int ReportedByUserId { get; set; }
        public User ReportedByUser { get; set; }

        public int? ResolvedByUserId { get; set; }
        public User? ResolvedByUser { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public int? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string Priority { get; set; } = string.Empty;
    }
}
