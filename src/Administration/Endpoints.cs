using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Administration
{
    public static class Endpoints
    {
        public static void MapAdministration(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
        }
    }
}