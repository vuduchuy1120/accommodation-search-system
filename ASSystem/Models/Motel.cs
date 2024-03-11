﻿using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class Motel
    {
        public Motel()
        {
            RoomImages = new HashSet<RoomImage>();
            Votes = new HashSet<Vote>();
            Covenients = new HashSet<Convenient>();
        }

        public int MotelId { get; set; }
        public int? AccountId { get; set; }
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityEmptyRooms { get; set; }
        public string? Contact { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Status { get; set; }
        public DateTime? DeleteAt { get; set; }

        public virtual ICollection<RoomImage> RoomImages { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Convenient> Covenients { get; set; }
    }
}
