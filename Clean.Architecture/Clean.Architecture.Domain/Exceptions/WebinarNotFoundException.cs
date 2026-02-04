using Clean.Architecture.Domain.Exceptions.Base;

namespace Clean.Architecture.Domain.Exceptions
{
    public sealed class WebinarNotFoundException : NotFoundException
    {
        public WebinarNotFoundException(Guid webinarId)
            : base($"The webinar with the identifier {webinarId} was not found.")
        {
        }
    }
}
