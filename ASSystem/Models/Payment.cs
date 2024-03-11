using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? AccountId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Status { get; set; }

        public virtual Account? Account { get; set; }
    }
}
