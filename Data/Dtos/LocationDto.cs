using Flash.Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flash.Park
{
    public class LocationDto
    {
        public int LocationId { get; set; }

        public int TotalCapacity { get; set; } //=> Floors.Select(x => x.Capacity).Sum();

        public int TotalAvailableSlots { get; set; }//=> Floors.Select(x => x.AvailableSlots).Sum();       

        public string City { get; set; }

        public string State { get; set; }
        public int NumberOfFloors { get; set; }

        public List<FloorDto> Floors { get; set; }
    }
}
