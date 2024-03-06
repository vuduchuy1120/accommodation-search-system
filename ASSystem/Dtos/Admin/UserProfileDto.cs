namespace ASSystem.Dtos.Admin
{
    public class UserProfileDto
    {
        public int AccountId { get; set; }
        public string Email { get; set; } = null!;
        public string? Username { get; set; }
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public int RoleId { get; set; }
        public bool? Gender { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
