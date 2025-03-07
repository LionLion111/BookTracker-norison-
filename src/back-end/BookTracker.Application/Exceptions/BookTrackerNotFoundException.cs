namespace BookTracker.Application.Exceptions;

public class BookTrackerNotFoundException(string message) : BookTrackerException(message);