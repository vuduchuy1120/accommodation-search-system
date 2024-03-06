namespace ASSystem.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomImages = new HashSet<RoomImage>();
            Votes = new HashSet<Vote>();
            Covenients = new HashSet<Convenient>();
        }

        public int RoomId { get; set; }
        public int? MotelId { get; set; }
        public decimal? Price { get; set; }
        public string? UnitPrice { get; set; }
        public string? Acreage { get; set; }
        public int? Quanlity { get; set; }
        public DateTime? DeleteAt { get; set; }

        public virtual Motel? Motel { get; set; }
        public virtual ICollection<RoomImage> RoomImages { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Convenient> Covenients { get; set; }
    }
}
