using Flash.Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories.Abstractions
{
    public interface IFloorRepository : IRepository<Floor>
    {
        Task<Floor> GetByFloorIdAsync(int floorId);
        Task<int> AddSlotByFloorIdAsync(int floorId);
        Task<int> RemoveSlotByFloorIdAsync(int floorId);
    }
}
