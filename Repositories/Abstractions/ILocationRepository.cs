using Flash.Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> GetAllLocationsAsync();
    }
}
