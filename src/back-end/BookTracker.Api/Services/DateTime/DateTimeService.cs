namespace BookTracker.Api.Services.DateTime;

public class DateTimeService : IDateTimeService
{
    public System.DateTime UtcNow => System.DateTime.UtcNow;
}