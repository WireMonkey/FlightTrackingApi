using System.Net;
using Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FlightControlApi
{
    public class PlaneApi
    {
        private readonly ILogger _logger;

        public PlaneApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PlaneApi>();
        }

        [Function("PlaneApi")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var planes = new List<Plane>()
            {
                new Plane("T-28",1.1f,true,null,true),
                new Plane("Turbo Timber",1.5f,true,null,true),
                new Plane("Stick",1.1f,true,null,true),
                new Plane("Mambo",1.1176f,true,null,true),
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            response.WriteAsJsonAsync(planes);

            return response;
        }
    }
}
