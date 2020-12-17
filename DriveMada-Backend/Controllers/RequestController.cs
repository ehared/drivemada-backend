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
        public IActionResult AddRequestByUserId([FromBody] Request request)
        {
            try
            {
                var successfulSave = _requestManager.AddRequest(request);

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
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

        }

        [HttpGet]
        [Route("GetRequest")]
        public IActionResult GetRequest()
        {
            try
            {
                var requests = _requestManager.GetAvailableRequests().ToList();

                return Ok(requests);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("GetClientRequests")]
        public IActionResult GetClientRequests([FromQuery]uint id)
        {
            try
            {
                var requests = _requestManager.GetClientRequests(id).ToList();

                return Ok(requests);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("GetDriverRequests")]
        public IActionResult GetDriverRequests([FromQuery]uint id)
        {
            try
            {
                var requests = _requestManager.GetDriverRequests(id).ToList();

                return Ok(requests);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("DeleteRequestById")]
        public IActionResult DeleteRequestById([FromQuery] uint id)
        {
            try
            {
                bool successfulResult = false;

                successfulResult = _requestManager.DeleteRequest(id);

                if (successfulResult)
                {
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }


        }

        [HttpPut]
        [Route("UpdateRequestById")]
        public IActionResult UpdateRequestById([FromBody] Request request)
        {
            try
            {
                bool successfulResult = false;

                successfulResult = _requestManager.UpdateRequest(request);

                if (successfulResult)
                {
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }


        }


    }
}