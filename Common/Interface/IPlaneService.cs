using Common.Model;

namespace Common.Interface
{
    public interface IPlaneService
    {
        IAsyncEnumerable<Plane> GetAll();
    }
}
