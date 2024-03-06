namespace ASSystem.Models
{
    public partial class Vote
    {
        public int AccountId { get; set; }
        public int RoomId { get; set; }
        public string? ReviewStar { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
