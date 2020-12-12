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
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IDriverManager _driverManager;

        public RegistrationController(ILogger<RegistrationController> logger, IDriverManager driverManager)
        {
            _logger = logger;
            _driverManager = driverManager ?? throw new ArgumentNullException(nameof(driverManager));
        }
        [HttpGet]
        public IEnumerable<int> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5)
            .ToArray();
        }

        [HttpPost]
        public IActionResult Register([FromBody] Driver driver)
        {
            try
            {
                // Validate Driver model

                var successfulSave = _driverManager.RegisterDriver(driver);

                if (successfulSave)
                {
                    return Ok();
                } else
                {
                    return BadRequest("Unable to register driver with provided data");
                }                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}