using Common.Model;

namespace Common.Interface
{
    public interface IPlaneService
    {
        Task<IAsyncEnumerable<Plane>> GetAll();
    }
}
