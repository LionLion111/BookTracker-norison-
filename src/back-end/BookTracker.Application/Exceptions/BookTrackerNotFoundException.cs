namespace BookTracker.Application.Exceptions;

public abstract class BookTrackerNotFoundException(string message) : BookTrackerException(message);