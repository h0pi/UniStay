using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{

    public class FaultConfiguration : IEntityTypeConfiguration<Fault>
    {
        public void Configure(EntityTypeBuilder<Fault> builder)
        {
            builder.ToTable("Faults");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Title).IsRequired();
            builder.Property(f => f.Description).IsRequired();

            builder.HasOne(f => f.ReportedByUser)
                   .WithMany(u => u.FaultsReported)
                   .HasForeignKey(f => f.ReportedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.ResolvedByUser)
                   .WithMany(u => u.FaultsResolved)
                   .HasForeignKey(f => f.ResolvedByUserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
