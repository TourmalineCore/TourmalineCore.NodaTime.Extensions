using NodaTime;

namespace NodaTimeExtensions.Utils
{
    public static class MachineNodaTime
    {
        public static ZonedDateTime UtcNow => SystemClock
            .Instance
            .GetCurrentInstant()
            .InUtc();
    }
}