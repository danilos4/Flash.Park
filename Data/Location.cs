using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Flash.Park.Data
{
    public partial class Location
    {
        public Location()
        {
            Floor = new HashSet<Floor>();
        }

        public long LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? NumberOfFloors { get; set; }

        //public virtual Floor Floors { get; set; }
        public virtual ICollection<Floor> Floor { get; set; }
    }
}
