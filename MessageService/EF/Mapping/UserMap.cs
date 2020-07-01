using MessageService.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageService.EF.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Key
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();

            //Relationships
            builder.HasMany(u => u.Messages)
                .WithOne()
                .HasForeignKey(u => u.UserId);
        }
    }
}
