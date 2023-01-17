using WildAlert.Shared.DateTimeProvider;

namespace WildAlert.Tests.Shared.DateTimeProvider;

public class TestDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => new DateTime(1996, 12, 02, 12,35, 10);
}