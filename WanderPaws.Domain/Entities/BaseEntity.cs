namespace WanderPaws.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public abstract class BaseActiveEntity : BaseEntity
    {
        public bool IsActive { get; set; }
    }
}
