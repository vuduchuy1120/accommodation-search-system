namespace ASSystem.Dtos
{
    public class MotelUpdateDto
    {
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityEmptyRooms { get; set; }
        public string? Contact { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
    }
}
