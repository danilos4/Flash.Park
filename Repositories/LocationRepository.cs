using Flash.Park.Data;
using Flash.Park.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(FlashParkContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            return await GetAll().Include(e => e.Floor).ToListAsync();
        }
    }
}
