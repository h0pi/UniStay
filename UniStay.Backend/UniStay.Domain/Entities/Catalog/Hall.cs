using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;

namespace UniStay.Domain.Entities.Catalog
{
    public class Hall : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }
        public bool IsAvailable { get; set; } = true;

        public ICollection<HallReservation> HallReservations { get; set; } = new List<HallReservation>();
    }
}
