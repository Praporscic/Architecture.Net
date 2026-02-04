using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Vertical.Architecture.Net.Contracts;
using Vertical.Architecture.Net.Database;
using Vertical.Architecture.Net.Entities;
using Vertical.Architecture.Net.Shared;

namespace Vertical.Architecture.Net.Features.Articles
{

    /// <summary>
    /// Contains the functionality required to create an article:
    /// - the MediatR `Command` representing the create request,
    /// - the `Validator` that enforces required fields,
    /// - the `Handler` that persists the article to the database and returns the created article Id,
    /// - and the `CreateArticleEndpoint` that exposes an API endpoint for creating articles.
    /// </summary>
    public static class CreateArticle
    {

        public class Command : IRequest<Result<Guid>>
        {
            public string Title { get; set; } = string.Empty;

            public string Content { get; set; } = string.Empty;

            public List<string> Tags { get; set; } = new();
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Title).NotEmpty();
                RuleFor(c => c.Content).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<Guid>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IValidator<Command> _validator;

            public Handler(ApplicationDbContext dbContext, IValidator<Command> validator)
            {
                _dbContext = dbContext;
                _validator = validator;
            }

            public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result.Failure<Guid>(new Error(
                        "CreateArticle.Validation",
                        validationResult.ToString()));
                }

                var article = new Article
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Content = request.Content,
                    Tags = request.Tags,
                    CreatedOnUtc = DateTime.UtcNow
                };

                _dbContext.Add(article);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return article.Id;
            }
        }
    }

    public class CreateArticleEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/articles", async (CreateArticleRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateArticle.Command>();

                var result = await sender.Send(command);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                return Results.Ok(result.Value);
            });
        }
    }

}
