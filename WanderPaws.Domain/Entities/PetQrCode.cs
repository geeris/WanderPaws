namespace WanderPaws.Domain.Entities
{
    public class PetQrCode : BaseActiveEntity
    {
        public int PetId { get; set; }
        public int QrCodeUrl { get; set; } // Set to inactive when pet gets removed
    }
}
