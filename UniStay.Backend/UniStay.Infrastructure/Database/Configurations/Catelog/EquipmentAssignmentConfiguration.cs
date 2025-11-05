using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{

    public class EquipmentAssignmentConfiguration : IEntityTypeConfiguration<EquipmentAssignment>
    {
        public void Configure(EntityTypeBuilder<EquipmentAssignment> builder)
        {
            builder.ToTable("EquipmentAssignments");

            builder.HasKey(ea => ea.Id);

            builder.HasOne(ea => ea.Equipment)
                   .WithMany(e => e.EquipmentAssignments)
                   .HasForeignKey(ea => ea.EquipmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ea => ea.Room)
                   .WithMany(r => r.EquipmentAssignments)
                   .HasForeignKey(ea => ea.RoomId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ea => ea.Student)
                   .WithMany(u => u.EquipmentAssignments)
                   .HasForeignKey(ea => ea.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
