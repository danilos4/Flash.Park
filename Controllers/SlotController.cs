using Flash.Park.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flash.Park.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;
        public SlotController(ISlotService slotService)
        {
            _slotService = slotService ?? throw new ArgumentNullException(nameof(slotService));
        }

        [HttpPost("addCar")]
        public async Task<ActionResult<int>> AddCar([FromQuery] int floorId)
        {
            var result = await _slotService.AddCar(floorId);

            return Ok(result);
        }

        [HttpPost("removeCar")]
        public async Task<ActionResult<int>> RemoveCar([FromQuery] int floorId)
        {
            var result = await _slotService.RemoveCar(floorId);

            return Ok(result);
        }
    }
}
