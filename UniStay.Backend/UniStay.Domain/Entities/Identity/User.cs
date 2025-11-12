
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Catalog;
using static System.Net.Mime.MediaTypeNames;
using DomApplication = UniStay.Domain.Entities.Catalog.Application;

namespace UniStay.Domain.Entities.Identity;

public sealed class User : BaseEntity
{
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }

    public ICollection<BedAssignment> BedAssignments { get; set; } = new List<BedAssignment>();
    public ICollection<HallReservation> HallReservations { get; set; } = new List<HallReservation>();
    public ICollection<EquipmentAssignment> EquipmentAssignments { get; set; } = new List<EquipmentAssignment>();
    public ICollection<Announcement> AnnouncementsCreated { get; set; } = new List<Announcement>();
    public ICollection<Fault> FaultsReported { get; set; } = new List<Fault>();
    public ICollection<Fault> FaultsResolved { get; set; } = new List<Fault>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<DomApplication> Applications { get; set; } = new List<DomApplication>();
    public ICollection<DomApplication> DecisionsMade { get; set; } = new List<DomApplication>();
    public ICollection<Message> MessagesSent { get; set; } = new List<Message>();
    public ICollection<Message> MessagesReceived { get; set; } = new List<Message>();

    public static class Constraints
    {
        public const int UsernameMaxLength = 50;
        public const int PasswordMinLength = 6;
    }

}