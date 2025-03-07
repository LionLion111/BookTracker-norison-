using BookTracker.Application.Exceptions;
using BookTracker.Application.Features.Base.Commands;
using BookTracker.Application.Services.Abstractions;
using BookTracker.Application.Services.DateTime;
using BookTracker.Application.Services.GuidGenerator;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace BookTracker.Application.Features.Books.Create;

public class CreateBookCommandHandler(
    AppDbContext dbContext,
    IDateTimeService dateTimeService,
    ICurrentUserService currentUserService,
    IGuidGenerator guidGenerator)
    : CreateCommandHandlerBase<CreateBookCommand, CreateBookCommandResult, Book>(dbContext, dateTimeService,
        currentUserService)
{
    private readonly AppDbContext _dbContext = dbContext;

    protected override Book MapToEntity(CreateBookCommand request)
    {
        var book = request.Adapt<Book>();
        book.Id = guidGenerator.Generate();
        return book;
    }

    protected override CreateBookCommandResult MapToResult(Book entity)
    {
        return entity.Adapt<CreateBookCommandResult>();
    }
    
    protected override async Task ValidateAsync(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(x => x.Isbn == request.Isbn, cancellationToken);

        if (existingBook is not null)
        {
            throw new BookTrackerValidationException("Book already exists.");
        }
        
        var existingPublisher = await _dbContext.Publishers.FirstOrDefaultAsync(x => x.Id == request.PublisherId, cancellationToken);
        
        if (existingPublisher is null)
        {
            throw new BookTrackerValidationException("Publisher does not exist.");
        }
    }
}