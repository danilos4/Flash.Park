using Flash.Park.Repositories;
using Flash.Park.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Flash.Park.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        private readonly IFloorRepository _floorRepository;
        private readonly ILogger<SlotService> _logger;

        public SlotService(ISlotRepository slotRepository, IFloorRepository floorRepository, ILogger<SlotService> logger)
        {
            _slotRepository = slotRepository ?? throw new ArgumentNullException(nameof(slotRepository));
            _floorRepository = floorRepository ?? throw new ArgumentNullException(nameof(floorRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> AddCar(int floorId)
        {
            try
            {
                await _slotRepository.AddCarAsync(floorId);
                var result = await _floorRepository.AddSlotByFloorIdAsync(floorId);

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on AddCar.", ex);
                return 0;
            }
        }

        public async Task<int> RemoveCar(int floorId)
        {
            try
            {
                await _slotRepository.RemoveCarAsync(floorId);
                var result = await _floorRepository.RemoveSlotByFloorIdAsync(floorId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on RemoveCar.", ex);
                return 0;
            }
        }
    }
}
