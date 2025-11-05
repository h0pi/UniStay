using System;
using UniStay.Application.Abstractions;
using UniStay.Infrastructure.Database.Seeders;
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
    
}