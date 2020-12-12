using System;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DriveMada_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginManager _loginManager;

        public LoginController(ILogger<LoginController> logger, ILoginManager loginManager)
        {
            _logger = logger;
            _loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                {
                    return BadRequest("Email and Password must be provided.");
                }

                var validatedUser = _loginManager.Authenticate(user);

                if (validatedUser != null)
                {
                    return Ok(validatedUser);
                }

                return BadRequest("Email or Password is incorrect.");
            } catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}