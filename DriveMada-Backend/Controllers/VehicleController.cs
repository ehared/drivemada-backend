using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DriveMada_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(ILogger<VehicleController> logger, IVehicleManager vehicleManager)
        {
            _logger = logger;
            _vehicleManager = vehicleManager ?? throw new ArgumentNullException(nameof(vehicleManager));
        }
       
        [HttpPost]
        [Route("AddVehicleByUserId")]
        public IActionResult AddVehicleByUserId([FromQuery]uint id, [FromBody] Vehicle vehicle)
        {
            try
            {
                var successfulSave = _vehicleManager.AddVehicle(id,vehicle);

                if (successfulSave)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Unable to register driver with provided data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        [Route("GetVehicleByUserId")]
        public IActionResult GetVehicleByUserId([FromQuery] uint id)
        {
            try
            {
                var vehicles = _vehicleManager.GetVehicles(id).ToList();

                return Ok(vehicles);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
        [HttpDelete]
        [Route("DeleteVehicleById")]
        public IActionResult DeleteVehicleByUserId([FromQuery] uint id)
        {
            try
            {
                var result = _vehicleManager.DeleteVehicle(id);

                if(result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Unable to find vehicle");
                }
            } catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("UpdateVehicleByUserId")]
        public IActionResult UpdateVehicleByUserId([FromBody] Vehicle vehicle)
        {
            try
            {
                var result = _vehicleManager.UpdateVehicle(vehicle);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}