using Flash.Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash.Park.Repositories
{
    public interface ISlotRepository : IRepository<Slot>
    {
        Task<int> AddCarAsync(int floorId);

        Task<int> RemoveCarAsync(int floorId);
    }
}
