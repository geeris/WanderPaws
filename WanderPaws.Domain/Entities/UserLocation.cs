namespace WanderPaws.Domain.Entities
{
    public class UserLocation : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
