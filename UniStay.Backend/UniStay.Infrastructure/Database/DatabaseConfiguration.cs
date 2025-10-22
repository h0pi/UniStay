using UniStay.Domain.Common;
using UniStay.Infrastructure.Database.Seeders;
using System.Linq.Expressions;
using DomApplication = UniStay.Domain.Entities.Catalog.Application;

namespace UniStay.Infrastructure.Database;

public partial class DatabaseContext
{
    private void ModifyTimestamps()
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            var entity = ((BaseEntity)entry.Entity);

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAtUtc = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.ModifiedAtUtc = DateTime.UtcNow;
            }
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<decimal?>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplyGlobalFielters(modelBuilder);

        StaticDataSeeder.Seed(modelBuilder); // static data

        modelBuilder.Entity<DomApplication>()
       .HasOne(a => a.Student)
       .WithMany(u => u.Applications)
       .HasForeignKey(a => a.StudentId)
       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DomApplication>()
            .HasOne(a => a.DecisionByUser)
            .WithMany(u => u.DecisionsMade)
            .HasForeignKey(a => a.DecisionByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BedAssignment>()
           .HasOne(b => b.Bed)
           .WithMany()
           .HasForeignKey(b => b.BedId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BedAssignment>()
            .HasOne(b => b.Student)
            .WithMany()
            .HasForeignKey(b => b.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // HallReservation konfiguracija
        // ----------------------------
        modelBuilder.Entity<HallReservation>()
            .HasOne(hr => hr.Hall)
            .WithMany()
            .HasForeignKey(hr => hr.HallId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HallReservation>()
            .HasOne(hr => hr.Student)
            .WithMany()
            .HasForeignKey(hr => hr.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // EquipmentAssignment konfiguracija
        // ----------------------------
        modelBuilder.Entity<EquipmentAssignment>()
            .HasOne(ea => ea.Equipment)
            .WithMany()
            .HasForeignKey(ea => ea.EquipmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EquipmentAssignment>()
            .HasOne(ea => ea.Room)
            .WithMany()
            .HasForeignKey(ea => ea.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EquipmentAssignment>()
            .HasOne(ea => ea.Student)
            .WithMany()
            .HasForeignKey(ea => ea.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Fault>()
            .HasOne(f => f.ReportedByUser)
            .WithMany(u => u.FaultsReported) // ova kolekcija iz User entiteta
            .HasForeignKey(f => f.ReportedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.ReceiverUser)
            .WithMany(u => u.MessagesReceived)
            .HasForeignKey(m => m.ReceiverUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.SenderUser)
            .WithMany(u => u.MessagesSent)
            .HasForeignKey(m => m.SenderUserId)
            .OnDelete(DeleteBehavior.Restrict);
        // ----------------------------
        // Hall, Room, Equipment konfiguracije
        // ----------------------------
        

        modelBuilder.Entity<Room>().Property(r => r.RoomNumber).HasMaxLength(10);
        modelBuilder.Entity<Bed>().Property(b => b.BedNumber).IsRequired();
        modelBuilder.Entity<Equipment>().Property(e => e.Name).HasMaxLength(100);
        modelBuilder.Entity<Hall>().Property(h => h.Name).HasMaxLength(50);
    }

    private void ApplyGlobalFielters(ModelBuilder modelBuilder)
    {
        // Apply a global filter to all entities inheriting from BaseEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var prop = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var compare = Expression.Equal(prop, Expression.Constant(false));
                var lambda = Expression.Lambda(compare, parameter);

                modelBuilder.Entity(entityType.ClrType)
                            .HasQueryFilter(lambda);
            }
        }
    }

    public override int SaveChanges()
    {
        ModifyTimestamps();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ModifyTimestamps();

        return base.SaveChangesAsync(cancellationToken);
    }
}