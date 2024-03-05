namespace ClashRoyaleManager.Application.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}