using MessageService.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageService.EF.Mapping
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            //Key
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();

            //Properties
            builder.Property(m => m.MessageText)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(m => m.UserId)
                .IsRequired();
        }
    }
}
