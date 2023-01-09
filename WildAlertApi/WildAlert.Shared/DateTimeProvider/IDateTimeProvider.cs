namespace WildAlert.Shared.DateTimeProvider;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}