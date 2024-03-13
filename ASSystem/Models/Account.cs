using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class Account
    {
        public Account()
        {
            Payments = new HashSet<Payment>();
            Votes = new HashSet<Vote>();
        }

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
        public bool? IsActive { get; set; }
        public string? Address { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
