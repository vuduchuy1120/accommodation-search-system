using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class Vote
    {
        public int AccountId { get; set; }
        public int MotelId { get; set; }
        public string? ReviewStar { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Motel Motel { get; set; } = null!;
    }
}
