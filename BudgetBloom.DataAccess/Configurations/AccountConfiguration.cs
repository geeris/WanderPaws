using BudgetBloom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBloom.DataAccess.Configurations
{
    internal class AccountConfiguration : BaseActiveEntityConfiguration<Account>
    {
        public override void ConfigureRules(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasMany(x => x.Transactions)
               .WithOne(x => x.Account)
               .HasForeignKey(x => x.AccountId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
