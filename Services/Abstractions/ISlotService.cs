using System.Threading.Tasks;

namespace Flash.Park.Services
{
    public interface ISlotService
    {
        Task<int> AddCar(int floorId);
        Task<int> RemoveCar(int floorId);
    }
}
