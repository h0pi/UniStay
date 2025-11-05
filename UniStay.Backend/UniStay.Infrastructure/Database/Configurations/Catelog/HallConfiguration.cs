using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.ToTable("Halls");

            builder.HasKey(h => h.Id);

            // Basic properties
            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.Capacity)
                   .IsRequired();

            builder.Property(h => h.Description)
                   .IsRequired(false);

            builder.Property(h => h.AvailableFrom)
                   .IsRequired();

            builder.Property(h => h.AvailableTo)
                   .IsRequired();

            builder.Property(h => h.IsAvailable)
                   .HasDefaultValue(true);

            // Metadata fields
            builder.Property(h => h.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(h => h.CreatedAtUtc)
                   .IsRequired();

            builder.Property(h => h.ModifiedAtUtc)
                   .IsRequired(false);

        }
    }
}
