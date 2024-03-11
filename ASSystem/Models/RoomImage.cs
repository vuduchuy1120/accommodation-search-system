using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class RoomImage
    {
        public int RoomImageId { get; set; }
        public int MotelId { get; set; }
        public string? ImageDetail { get; set; }
        public string? PathImageDetail { get; set; }

        public virtual Motel Motel { get; set; } = null!;
    }
}
