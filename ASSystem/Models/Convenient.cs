using System;
using System.Collections.Generic;

namespace ASSystem.Models
{
    public partial class Convenient
    {
        public Convenient()
        {
            Motels = new HashSet<Motel>();
        }

        public int ConvenientId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Motel> Motels { get; set; }
    }
}
