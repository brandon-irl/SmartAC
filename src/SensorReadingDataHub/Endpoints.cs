using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SensorReadingDataHub
{
    public static class Endpoints
    {
        public static void MapSensorReadingDataHub(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
        }
    }
}