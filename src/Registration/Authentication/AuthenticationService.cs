using System.Threading.Tasks;

namespace Registration.Authentication
{
    public class AuthenticationService
    {
        readonly DeviceValidationService _deviceService;
        readonly TokenService _tokenService;
        public AuthenticationService(DeviceValidationService deviceService, TokenService tokenService)
        {
            _deviceService = deviceService;
            _tokenService = tokenService;
        }

        public async Task<string> Authenticate(DeviceCredentials DeviceCredentials)
        {
            await _deviceService.ValidateCredentials(DeviceCredentials);
            return _tokenService.GetToken();
        }
    }
}