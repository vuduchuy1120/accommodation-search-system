namespace ASSystem.Models
{
    public partial class Convenient
    {
        public Convenient()
        {
            Rooms = new HashSet<Room>();
        }

        public int ConvenientId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
