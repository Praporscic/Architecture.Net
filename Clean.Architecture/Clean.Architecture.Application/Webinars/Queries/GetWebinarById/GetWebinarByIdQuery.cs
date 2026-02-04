using Clean.Architecture.Application.Abstractions.Messaging;

namespace Clean.Architecture.Application.Webinars.Queries.GetWebinarById
{
    public sealed record GetWebinarByIdQuery(Guid WebinarId) : IQuery<WebinarResponse>;
}
