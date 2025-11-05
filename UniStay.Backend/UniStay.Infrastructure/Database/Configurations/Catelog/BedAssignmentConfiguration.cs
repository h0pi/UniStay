using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class BedAssignmentConfiguration : IEntityTypeConfiguration<BedAssignment>
    {
        public void Configure(EntityTypeBuilder<BedAssignment> builder)
        {
            builder.ToTable("BedAssignments");

            builder.HasKey(b => b.Id);

            // Required fields
            builder.Property(b => b.FromDate)
                   .IsRequired();

            builder.Property(b => b.ToDate)
                   .IsRequired(false);

            // Relationships
            builder.HasOne(b => b.Bed)
                   .WithMany(bd => bd.BedAssignments)
                   .HasForeignKey(b => b.BedId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Student)
                   .WithMany(u => u.BedAssignments)
                   .HasForeignKey(b => b.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Metadata fields
            builder.Property(b => b.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(b => b.CreatedAtUtc)
                   .IsRequired();

            builder.Property(b => b.ModifiedAtUtc)
                   .IsRequired(false);

            
        }
    }
}
