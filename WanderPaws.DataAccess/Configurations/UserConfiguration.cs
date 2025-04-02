using WanderPaws.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WanderPaws.DataAccess.Configurations
{
    internal class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).IsRequired();
        }
    }
}
