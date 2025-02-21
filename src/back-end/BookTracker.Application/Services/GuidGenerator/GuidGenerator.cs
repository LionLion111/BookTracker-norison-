namespace BookTracker.Application.Services.GuidGenerator;

public class GuidGenerator : IGuidGenerator
{
    public Guid Generate()
    {
        return Guid.CreateVersion7();
    }
}