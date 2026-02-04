using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Domain.Abstractions
{
    public interface IWebinarRepository
    {
        void Insert(Webinar webinar);
    }
}
