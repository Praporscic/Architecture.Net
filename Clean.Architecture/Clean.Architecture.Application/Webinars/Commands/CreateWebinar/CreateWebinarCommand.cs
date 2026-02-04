using Clean.Architecture.Application.Abstractions.Messaging;

namespace Clean.Architecture.Application.Webinars.Commands.CreateWebinar
{
    public sealed record CreateWebinarCommand(string Name, DateTime ScheduledOn) : ICommand<Guid>;
}
