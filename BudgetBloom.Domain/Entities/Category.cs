namespace BudgetBloom.Domain.Entities
{
    public class Category : BaseActiveEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? UserId { get; set; }
        public bool IsPredefined { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; } = new HashSet<Category>();
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
