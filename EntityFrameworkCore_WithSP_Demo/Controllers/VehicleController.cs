using EntityFrameworkCore_WithSP_Demo.Entities;
using EntityFrameworkCore_WithSP_Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_WithSP_Demo.Controllers
{
    [ApiController]
    [Route("Vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;
        public VehicleController(IVehicleService _vehicleService)
        {
            this.vehicleService = _vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleListAsync()
        {
            try
            {
                var vehicleList = await this.vehicleService.GetVehicleListAsync();
                return Ok(vehicleList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{vehicleId:int}")]
        public async Task<IActionResult> GetVehicleByIdAsync(int vehicleId)
        {
            try
            {
                var vehicle = await this.vehicleService.GetVehicleByIdAsync(vehicleId);
                if(vehicle!= null)
                {
                    return Ok(vehicle);
                }
                return NotFound();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync(Vehicle model)
        {
            try
            {
                if (model != null)
                {
                    var response = await this.vehicleService.AddVehicleAsync(model);
                    return Ok(model);

                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicleAsync(Vehicle model)
        {
            try
            {
                if (model != null)
                {
                    var response = await this.vehicleService.UpdateVehicleAsync(model);
                    return Ok(model);
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{vehicleId:int}")]
        public async Task<IActionResult> DeleteVehicleAsync(int vehicleId)
        {
            try
            {
                var response = await this.vehicleService.DeleteVehicleAsync(vehicleId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}