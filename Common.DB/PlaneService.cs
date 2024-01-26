using Common.Interface;
using Common.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Common.DB.Util;

namespace Common.DB
{
    public class PlaneService : IPlaneService
    {
        private readonly string _connString;
        private readonly CosmosClient _client;
        private Container _container { get => _client.GetDatabase("Plane").GetContainer("Plane"); }

        public PlaneService()
        {
            _connString = Environment.GetEnvironmentVariable("PlaneConnString") ?? throw new ArgumentNullException("Missing Plane Conn String");
            _client = new CosmosClient(_connString);
        }

        public IAsyncEnumerable<Plane> GetAll()
        {
            return _container.GetItemLinqQueryable<Plane>().ToFeedIterator().ToAsyncEnumerable();
        }
    }
}
