using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.TotalAmount)
                   .HasPrecision(18, 2);

            builder.HasOne(i => i.Student)
                   .WithMany()
                   .HasForeignKey(i => i.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
