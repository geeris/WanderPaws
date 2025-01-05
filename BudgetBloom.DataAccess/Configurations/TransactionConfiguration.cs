using BudgetBloom.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBloom.DataAccess.Configurations
{
    internal class TransactionConfiguration : BaseActiveEntityConfiguration<Transaction>
    {
        public override void ConfigureRules(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TransactionDate).IsRequired();
        }
    }
}
