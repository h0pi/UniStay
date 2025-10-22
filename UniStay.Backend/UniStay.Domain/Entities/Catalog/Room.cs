using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using static System.Net.Mime.MediaTypeNames;

namespace UniStay.Domain.Entities.Catalog
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public int MaxOccupancy { get; set; } = 2;
        public string Description { get; set; } = string.Empty;

        public ICollection<Bed> Beds { get; set; } = new List<Bed>();
        public ICollection<EquipmentAssignment> EquipmentAssignments { get; set; } = new List<EquipmentAssignment>();
        public ICollection<Application> ApplicationsAssigned { get; set; } = new List<Application>();
        public ICollection<Fault> Faults { get; set; } = new List<Fault>();
    }
}
