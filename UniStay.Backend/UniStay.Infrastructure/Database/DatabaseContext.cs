using UniStay.Application.Abstractions;
using DomApplication = UniStay.Domain.Entities.Catalog.Application;

namespace UniStay.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Bed> Beds => Set<Bed>();
    public DbSet<BedAssignment> BedAssignments => Set<BedAssignment>();
    public DbSet<Hall> Halls => Set<Hall>();
    public DbSet<HallReservation> HallReservations => Set<HallReservation>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<EquipmentAssignment> EquipmentAssignments => Set<EquipmentAssignment>(); 
    public DbSet<Fault> Faults => Set<Fault>();
    public DbSet<Announcement> Announcements => Set<Announcement>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<DomApplication> Applications => Set<DomApplication>();
    public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    // ----------------------------
    //    // DomApplication konfiguracija
    //    // ----------------------------
    //    modelBuilder.Entity<DomApplication>()
    //        .HasOne(a => a.Student)
    //        .WithMany(u => u.Applications)
    //        .HasForeignKey(a => a.StudentId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<DomApplication>()
    //        .HasOne(a => a.DecisionByUser)
    //        .WithMany(u => u.DecisionsMade)
    //        .HasForeignKey(a => a.DecisionByUserId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    // ----------------------------
    //    // BedAssignment konfiguracija
    //    // ----------------------------
    //    modelBuilder.Entity<BedAssignment>()
    //        .HasOne(b => b.Bed)
    //        .WithMany()
    //        .HasForeignKey(b => b.BedId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<BedAssignment>()
    //        .HasOne(b => b.Student)
    //        .WithMany()
    //        .HasForeignKey(b => b.StudentId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    // ----------------------------
    //    // HallReservation konfiguracija
    //    // ----------------------------
    //    modelBuilder.Entity<HallReservation>()
    //        .HasOne(hr => hr.Hall)
    //        .WithMany()
    //        .HasForeignKey(hr => hr.HallId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<HallReservation>()
    //        .HasOne(hr => hr.Student)
    //        .WithMany()
    //        .HasForeignKey(hr => hr.StudentId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    // ----------------------------
    //    // EquipmentAssignment konfiguracija
    //    // ----------------------------
    //    modelBuilder.Entity<EquipmentAssignment>()
    //        .HasOne(ea => ea.Equipment)
    //        .WithMany()
    //        .HasForeignKey(ea => ea.EquipmentId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<EquipmentAssignment>()
    //        .HasOne(ea => ea.Room)
    //        .WithMany()
    //        .HasForeignKey(ea => ea.RoomId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<EquipmentAssignment>()
    //        .HasOne(ea => ea.Student)
    //        .WithMany()
    //        .HasForeignKey(ea => ea.StudentId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    // ----------------------------
    //    // Hall, Room, Equipment konfiguracije
    //    // ----------------------------
    //    modelBuilder.Entity<Room>().Property(r => r.RoomNumber).HasMaxLength(10);
    //    modelBuilder.Entity<Bed>().Property(b => b.BedNumber).IsRequired();
    //    modelBuilder.Entity<Equipment>().Property(e => e.Name).HasMaxLength(100);
    //    modelBuilder.Entity<Hall>().Property(h => h.Name).HasMaxLength(50);

    //    // Možeš dodati i ostale konfiguracije kao što su max length, unique constraints itd.
    //}
}