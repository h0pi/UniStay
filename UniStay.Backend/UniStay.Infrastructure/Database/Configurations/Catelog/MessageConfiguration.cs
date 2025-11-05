using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniStay.Infrastructure.Database.Configurations.Catelog
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(m => m.Id);

            // Basic properties
            builder.Property(m => m.Subject)
                   .IsRequired();

            builder.Property(m => m.MessageText)
                   .IsRequired();

            builder.Property(m => m.SentAt)
                   .IsRequired();

            builder.Property(m => m.IsRead)
                   .HasDefaultValue(false);

            // Relationships
            builder.HasOne(m => m.ReceiverUser)
                   .WithMany(u => u.MessagesReceived)
                   .HasForeignKey(m => m.ReceiverUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.SenderUser)
                   .WithMany(u => u.MessagesSent)
                   .HasForeignKey(m => m.SenderUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            


            // Metadata fields
            builder.Property(m => m.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(m => m.CreatedAtUtc)
                   .IsRequired();

            builder.Property(m => m.ModifiedAtUtc)
                   .IsRequired(false);
        }
    }
}
