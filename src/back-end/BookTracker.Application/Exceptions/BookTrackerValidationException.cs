namespace BookTracker.Application.Exceptions;

public abstract class BookTrackerValidationException(string message) : BookTrackerException(message);