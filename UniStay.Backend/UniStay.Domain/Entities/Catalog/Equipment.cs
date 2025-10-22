using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;

namespace UniStay.Domain.Entities.Catalog
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal RentalPrice { get; set; }
        public string EquipmentType { get; set; } = string.Empty;

        public ICollection<EquipmentAssignment> EquipmentAssignments { get; set; } = new List<EquipmentAssignment>();
        public ICollection<Fault> Faults { get; set; } = new List<Fault>();
    }
}
