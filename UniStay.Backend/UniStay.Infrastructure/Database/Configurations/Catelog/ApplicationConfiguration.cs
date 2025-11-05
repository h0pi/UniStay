using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomApplication = UniStay.Domain.Entities.Catalog.Application;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<DomApplication>
    {
        public void Configure(EntityTypeBuilder<DomApplication> builder)
        {
            builder.ToTable("Applications");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Student)
                   .WithMany(u => u.Applications)
                   .HasForeignKey(a => a.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.DecisionByUser)
                   .WithMany(u => u.DecisionsMade)
                   .HasForeignKey(a => a.DecisionByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.AssignedRoom)
                   .WithMany()
                   .HasForeignKey(a => a.AssignedRoomId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Status)
                   .WithMany()
                   .HasForeignKey(a => a.StatusId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
