using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Services
{
    public interface ILocationService
    {
        Task<List<LocationDto>> GetAllLocations();

        //Task<List<LocationDto>> GetLocationsAsync();
    }
}
