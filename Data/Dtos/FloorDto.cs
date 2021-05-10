using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park
{
    public class FloorDto
    {
        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }
        public int SlotsTaken { get; set; }
        public int AvailableSlots { get; set; }
    }
}
