using Clean.Architecture.Domain.Abstractions;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Infrastructure.Repositories
{
    public sealed class WebinarRepository : IWebinarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WebinarRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Insert(Webinar webinar)
        {
            _dbContext.Set<Webinar>().Add(webinar);
        }
    }
}
