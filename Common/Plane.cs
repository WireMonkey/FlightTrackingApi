namespace Common
{
    public record Plane(string Name, float Wingspan, bool Electric, IEnumerable<string>? Notes, bool ReadyToFly = false)
    {

    }
}
