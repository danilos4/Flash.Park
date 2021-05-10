using Flash.Park.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories
{
    public class SlotRepository : Repository<Slot>, ISlotRepository
    {
        public SlotRepository(FlashParkContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddCarAsync(int floorId)
        {
            var lastSlotNumber = DbContext.Slot.Where(y => y.FloorId == floorId).Select(x => x.SlotNumber).Max();
            Slot slot = new Slot();
            slot.FloorId = floorId;
            slot.SlotNumber = lastSlotNumber++;
            var result = await AddAsync(slot);

            return (int)result.SlotId;
        }

        public async Task<int> RemoveCarAsync(int floorId)
        {
            var slot = await DbContext.Slot.Where(y => y.FloorId == floorId).FirstOrDefaultAsync();
            var result = await DeleteAsync(slot);

            return (int)result.SlotId;
        }
    }
}
