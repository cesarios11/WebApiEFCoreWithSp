using EntityFrameworkCore_WithSP_Demo.Data;
using EntityFrameworkCore_WithSP_Demo.DTOs;
using EntityFrameworkCore_WithSP_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkCore_WithSP_Demo.Repositories
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext dbContext;
        public VehicleService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<VehicleDto>> GetVehicleListAsync()
        {
            var vehicleList = await this.dbContext.Vehicle.ToListAsync();

            var vehicleListDto = from vehicle in vehicleList
                                 select new VehicleDto()
                                 {
                                     VehicleId = vehicle.VehicleId,
                                     VehicleBrand = vehicle.VehicleBrand,
                                     Model = vehicle.Model,
                                     Color = vehicle.Color
                                 };

            return vehicleListDto.ToList();
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            var vehicle = await this.dbContext.Vehicle.FindAsync(new object[] { id });

            if (vehicle == null)
            {
                return null;
            }

            return new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleBrand = vehicle.VehicleBrand,
                Model = vehicle.Model,
                Color = vehicle.Color
            };
        }

        public async Task<VehicleDto> AddVehicleAsync(Vehicle vehicle)
        {
            var newVehicle = new Vehicle()
            {                
                VehicleBrand = vehicle.VehicleBrand,
                Model = vehicle.Model,
                Color = vehicle.Color
            };

            this.dbContext.Vehicle.Add(newVehicle);

            await this.dbContext.SaveChangesAsync();

            return new VehicleDto
            {
                VehicleId = newVehicle.VehicleId,
                VehicleBrand = newVehicle.VehicleBrand,
                Model = newVehicle.Model,
                Color = newVehicle.Color
            };
        }

        public async Task<VehicleDto> UpdateVehicleAsync(Vehicle vehicle)
        {
            var updatedVehicle = await this.dbContext.Vehicle.FindAsync(new object[] { vehicle.VehicleId });

            if (updatedVehicle == null)
            {
                return null;
            }

            updatedVehicle.VehicleBrand = vehicle.VehicleBrand;
            updatedVehicle.Model = vehicle.Model;
            updatedVehicle.Color = vehicle.Color;

            await this.dbContext.SaveChangesAsync();

            return new VehicleDto
            {
                VehicleId = updatedVehicle.VehicleId,
                VehicleBrand = updatedVehicle.VehicleBrand,
                Model = updatedVehicle.Model,
                Color = updatedVehicle.Color
            };           
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var deletedVehicle = await this.dbContext.Vehicle.FindAsync(new object[] { id });

            if (deletedVehicle == null)
            {
                return false;
            }

            this.dbContext.Vehicle.Remove(deletedVehicle);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}
