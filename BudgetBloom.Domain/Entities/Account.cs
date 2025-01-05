namespace BudgetBloom.Domain.Entities
{
    public class Account : BaseActiveEntity
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
