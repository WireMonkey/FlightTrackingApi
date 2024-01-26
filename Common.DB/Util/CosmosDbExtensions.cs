using Microsoft.Azure.Cosmos;

namespace Common.DB.Util
{
    public static class CosmosDbExtensions
    {
        public static async IAsyncEnumerable<TModel> ToAsyncEnumerable<TModel>(this FeedIterator<TModel> setIterator)
        {
            while (setIterator.HasMoreResults)
                foreach (var item in await setIterator.ReadNextAsync())
                {
                    yield return item;
                }
        }
    }
}
