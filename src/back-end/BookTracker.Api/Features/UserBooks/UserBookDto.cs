using BookTracker.Api.Data.Enums;

namespace BookTracker.Api.Features.UserBooks;

public class UserBookDto : AuditDto
{
    public Guid Id { get; set; }
    public UserBookStatus Status { get; set; }
    public UserBookMood Mood { get; set; }
    public int PageRead { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    //public ICollection<UserBookTrackerDto>? UserBookTrackers { get; set; }
}

