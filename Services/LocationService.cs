using AutoMapper;
using Flash.Park.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILogger<LocationService> logger, ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(ILocationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public async Task<List<LocationDto>> GetAllLocations()
        {
            try
            {
                var locations = await _locationRepository.GetAllLocationsAsync();

                var response = _mapper.Map<List<LocationDto>>(locations);

                response.ForEach(x => x.TotalAvailableSlots = x.Floors.Sum(d => d.Capacity - d.SlotsTaken));
                response.ForEach(x => x.TotalCapacity = x.Floors.Sum(d => d.Capacity));
                response.ForEach(x => x.Floors.ForEach(d => d.AvailableSlots = d.Capacity - d.SlotsTaken));

                return response;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on GetAllLocations.", ex);
                return null;
            }
            
        }
    }
}
