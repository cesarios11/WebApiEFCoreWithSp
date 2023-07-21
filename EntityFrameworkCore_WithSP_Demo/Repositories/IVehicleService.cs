using EntityFrameworkCore_WithSP_Demo.DTOs;
using EntityFrameworkCore_WithSP_Demo.Entities;

namespace EntityFrameworkCore_WithSP_Demo.Repositories
{
    public interface IVehicleService
    {
        public Task<List<VehicleDto>> GetVehicleListAsync();
        public Task<VehicleDto> GetVehicleByIdAsync(int Id);
        public Task<VehicleDto> AddVehicleAsync(Vehicle vehicle);
        public Task<VehicleDto> UpdateVehicleAsync(Vehicle vehicle);
        public Task<bool> DeleteVehicleAsync(int Id);
    }
}
