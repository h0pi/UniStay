using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class Application : BaseEntity
    {
        public int StudentId { get; set; }
        public User Student { get; set; }

        public DateTime AppliedAt { get; set; }

        public int StatusId { get; set; }
        public ApplicationStatus Status { get; set; }

        public int? AssignedRoomId { get; set; }
        public Room? AssignedRoom { get; set; }

        public string PreferredRoomType { get; set; } = string.Empty;

        public int? DecisionByUserId { get; set; }
        public User? DecisionByUser { get; set; }

        public DateTime? DecisionAt { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
