namespace WanderPaws.Domain.Entities
{
    public class Pet : BaseActiveEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public int OwnerId { get; set; }
        public int QrCoded { get; set; }

        public virtual User Owner { get; set; }
        public virtual PetQrCode QrCode { get; set; }
    }
}
