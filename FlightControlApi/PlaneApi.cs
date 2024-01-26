using System.Net;
using Common;
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
        private readonly string _apiKey;

        public PlaneApi(ILoggerFactory loggerFactory, IPlaneService planeService)
        {
            _logger = loggerFactory.CreateLogger<PlaneApi>();
            _planeService = planeService;
            _apiKey = Environment.GetEnvironmentVariable("ApiKey") ?? throw new ArgumentNullException("Missing Api Key");
        }

        [Function("PlaneApi")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            if (!Validate.IsValid(_apiKey, req))
            {
                return req.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            await response.WriteAsJsonAsync(_planeService.GetAll());

            return response;
        }
    }
}
