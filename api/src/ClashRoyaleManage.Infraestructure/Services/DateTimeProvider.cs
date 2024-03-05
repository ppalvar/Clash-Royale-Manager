using ClashRoyaleManager.Application.Services;

namespace ClashRoyaleManage.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}