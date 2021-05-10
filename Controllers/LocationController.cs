using Flash.Park.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flash.Park.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
        }

        [HttpGet("getAllLocations")]
        public async Task<ActionResult<List<LocationDto>>> GetAllLocationsAsync()
        {
            var locations = await _locationService.GetAllLocations();

            return locations != null ? (ActionResult) Ok(locations) : NotFound();
        }
    }
}
