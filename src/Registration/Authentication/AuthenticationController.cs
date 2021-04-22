using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Registration.Authentication
{
    [Route("identity/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] DeviceCredentials deviceCredentials)
        {
            try
            {
                string token = authenticationService.Authenticate(deviceCredentials);
                return Ok(token);
            }
            catch (InvalidCredentialException)
            {
                return Unauthorized();
            }
        }
    }

    [Route("identity/[controller]")]
    public class ValidationController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}