using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Flash.Park.Data
{
    public partial class Floor
    {
        public Floor()
        {
            Slot = new HashSet<Slot>();
        }

        public long FloorId { get; set; }
        public long LocationId { get; set; }
        public long FloorNumber { get; set; }
        public long SlotsTaken { get; set; }
        public long Capacity { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Slot> Slot { get; set; }
    }
}
