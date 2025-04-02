namespace WanderPaws.Domain.Entities
{
    public class Report : BaseActiveEntity
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int Type { get; set; } // Lost/Found -> enum
        public string Details { get; set; }
        public string LastSeenLocation { get; set; }
    }
}
