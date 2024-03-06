namespace ASSystem.Models
{
    public partial class RoomImage
    {
        public int RoomImageId { get; set; }
        public int RoomId { get; set; }
        public string? ImageDetail { get; set; }
        public string? PathImageDetail { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
