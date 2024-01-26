using Common.Interface;
using Common.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Plane>> GetAll()
        {
            List<Plane> results = new();
            var feed = _container.GetItemLinqQueryable<Plane>().ToFeedIterator();
            while(feed.HasMoreResults)
            {
                results.AddRange(await feed.ReadNextAsync());
            }
            return results;
        }
    }
}
