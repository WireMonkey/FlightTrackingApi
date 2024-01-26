using System.Net;
using Common.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FlightControlApi
{
    public class PlaneApi
    {
        private readonly ILogger _logger;
        private readonly IPlaneService _planeService;

        public PlaneApi(ILoggerFactory loggerFactory, IPlaneService planeService)
        {
            _logger = loggerFactory.CreateLogger<PlaneApi>();
            _planeService = planeService;
        }

        [Function("PlaneApi")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            var planes = await _planeService.GetAll();

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            await response.WriteAsJsonAsync(planes);

            return response;
        }
    }
}
