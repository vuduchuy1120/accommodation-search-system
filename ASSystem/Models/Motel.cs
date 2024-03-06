namespace ASSystem.Models
{
    public partial class Motel
    {
        public Motel()
        {
            Rooms = new HashSet<Room>();
        }

        public int MotelId { get; set; }
        public int? AccountId { get; set; }
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? QuantityEmptyRooms { get; set; }
        public string? Contact { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
