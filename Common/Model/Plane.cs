namespace Common.Model
{
    public record Plane(Guid PlaneId, string Name, float Wingspan, bool Electric, IEnumerable<string>? Notes, bool ReadyToFly = false)
    {
    }
}
