using BudgetBloom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBloom.DataAccess.Configurations
{
    public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity>
        where TBaseEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            builder.Property(x => x.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");

            ConfigureRules(builder);
        }

        public abstract void ConfigureRules(EntityTypeBuilder<TBaseEntity> builder);
    }

    public abstract class BaseActiveEntityConfiguration<TBaseActiveEntity> : BaseEntityConfiguration<TBaseActiveEntity>, IEntityTypeConfiguration<TBaseActiveEntity>
        where TBaseActiveEntity : BaseActiveEntity
    {
        public new void Configure(EntityTypeBuilder<TBaseActiveEntity> builder)
        {
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            base.Configure(builder);
        }
    }
}
