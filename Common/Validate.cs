using Microsoft.Azure.Functions.Worker.Http;

namespace Common
{
    public static class Validate
    {
        public static bool IsValid(string Key, HttpRequestData req)
        {
            req.Headers.TryGetValues("x-flight-tracking", out var value);

            return value != null || value.Contains(Key);
        }
    }
}
