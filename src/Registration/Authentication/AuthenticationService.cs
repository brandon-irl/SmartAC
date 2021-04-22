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

        public string Authenticate(DeviceCredentials DeviceCredentials)
        {
            _deviceService.ValidateCredentials(DeviceCredentials);
            string securityToken = _tokenService.GetToken();

            return securityToken;
        }
    }
}