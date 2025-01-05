namespace BudgetBloom.Domain.Entities
{
    public class Transaction : BaseActiveEntity
    {
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Img { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
    }
}
