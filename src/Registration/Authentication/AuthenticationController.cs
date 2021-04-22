using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Authenticate([FromBody] DeviceCredentials deviceCredentials)
        {
            try
            {
                string token = await authenticationService.Authenticate(deviceCredentials);
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
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Validate()
        {
            return Ok();
        }
    }
}