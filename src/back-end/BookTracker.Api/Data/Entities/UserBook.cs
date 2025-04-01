using BookTracker.Api.Data.Enums;

namespace BookTracker.Api.Data.Entities;

public class UserBook : AuditEntity
{
    public UserBookStatus Status { get; set; }
    public UserBookMood Mood { get; set; }
    public int PageRead { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid BookId { get; set; }
    public Book? Book { get; set; }

    public ICollection<UserBookTracker>? UserBookTrackers { get; set; }
}