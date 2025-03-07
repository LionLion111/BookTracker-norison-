namespace BookTracker.Application.Exceptions;

public class BookTrackerValidationException(string message) : BookTrackerException(message);