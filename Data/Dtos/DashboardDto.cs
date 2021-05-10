using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park
{
    public class DashboardDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public int? NumberOfFloors { get; set; }
        public int FloorNumber { get; set; }

        public int SlosTaken { get; set; }

        public int Capacity { get; set; }
    }
}
