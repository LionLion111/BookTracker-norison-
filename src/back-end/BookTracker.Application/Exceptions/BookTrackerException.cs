namespace BookTracker.Application.Exceptions;

public abstract class BookTrackerException(string message) : Exception(message)
{
    public abstract string Details { get; }
}