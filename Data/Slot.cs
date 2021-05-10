using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Flash.Park.Data
{
    public partial class Slot
    {
        public long SlotId { get; set; }
        public long SlotNumber { get; set; }
        public long? FloorId { get; set; }

        public virtual Floor Floor { get; set; }
    }
}
