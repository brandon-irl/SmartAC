using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SensorReadingDataHub.Tests
{
    public class SensorReadingTests
    {
        // TODO: Get test endpoint from configuration and script it. Right now, you have to make sure it is running yourself BEFORE running tests
        [Fact]
        public async Task PostSensorReadingEndpointWithoutAuthorization()
        {
            var content = new StringContent("{\"someProperty\":\"someValue\"}", Encoding.UTF8, "application/json");
            var _httpClient = new HttpClient();
            var result = await _httpClient.PostAsync("https://localhost:8001/Sensors/SubmitReading", content); //or PostAsync for POST
            Assert.Equal(result.StatusCode, System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
