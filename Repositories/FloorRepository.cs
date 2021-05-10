using Flash.Park.Data;
using Flash.Park.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        private readonly ILogger<FloorRepository> _logger;

        public FloorRepository(FlashParkContext dbContext, ILogger<FloorRepository> logger)
            : base(dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Floor> GetByFloorIdAsync(int floorId)
        {
            try
            {
                return await GetAll().Where(x => x.FloorId == floorId).FirstOrDefaultAsync();                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on GetByFloorIdAsync.", ex);
                return null;
            }
        }

        public async Task<int> AddSlotByFloorIdAsync(int floorId)
        {
            try
            {
                var floor = await GetByFloorIdAsync(floorId);
                floor.SlotsTaken++;
                await UpdateAsync(floor);

                return (int)floor.SlotsTaken;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on UpdateSlotsTaken.", ex);
                return 0;
            }
        }

        public async Task<int> RemoveSlotByFloorIdAsync(int floorId)
        {
            try
            {
                var floor = await GetByFloorIdAsync(floorId);
                floor.SlotsTaken--;
                await UpdateAsync(floor);

                return (int)floor.SlotsTaken;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on UpdateSlotsTaken.", ex);
                return 0;
            }
        }
    }
}
