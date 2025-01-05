namespace BudgetBloom.Domain.Entities
{
    public class User : BaseActiveEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
