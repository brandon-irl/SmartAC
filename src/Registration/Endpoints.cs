using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Registration
{
    public static class Endpoints
    {
        public static void MapRegistration(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
        }
    }
}