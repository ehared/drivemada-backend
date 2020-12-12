using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using Microsoft.Extensions.Logging;

namespace DriveMada_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestManager _requestManager;

        public RequestController(ILogger<RequestController> logger, IRequestManager requestManager)
        {
            _logger = logger;
            _requestManager = requestManager ?? throw new ArgumentNullException(nameof(requestManager));
        }

        [HttpPost]
        [Route("AddRequestByUserId")]
        public IActionResult AddVehicleByUserId([FromQuery]uint id, [FromBody] Request request)
        {
            try
            {
                var successfulSave = _requestManager.AddRequest(id, request);

                if (successfulSave)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Unable to add request with provided data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        
    }
}