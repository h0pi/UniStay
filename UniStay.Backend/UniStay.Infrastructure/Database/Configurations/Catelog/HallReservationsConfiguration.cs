using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class HallReservationsConfiguration : IEntityTypeConfiguration<HallReservation>
    {
        public void Configure(EntityTypeBuilder<HallReservation> builder)
        {

            builder.ToTable("HallReservations");

            builder.HasKey(hr => hr.Id);

            // Required fields
            builder.Property(hr => hr.ReservedAt)
                   .IsRequired();

            builder.Property(hr => hr.FromDate)
                   .IsRequired();

            builder.Property(hr => hr.ToDate)
                   .IsRequired();

            builder.Property(hr => hr.Status)
                   .IsRequired();

            // Relationships
            builder.HasOne(hr => hr.Hall)
                   .WithMany(h => h.HallReservations)
                   .HasForeignKey(hr => hr.HallId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(hr => hr.Student)
                   .WithMany(u => u.HallReservations)
                   .HasForeignKey(hr => hr.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Metadata fields
            builder.Property(hr => hr.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(hr => hr.CreatedAtUtc)
                   .IsRequired();

            builder.Property(hr => hr.ModifiedAtUtc)
                   .IsRequired(false);

            
        }
    }
}
