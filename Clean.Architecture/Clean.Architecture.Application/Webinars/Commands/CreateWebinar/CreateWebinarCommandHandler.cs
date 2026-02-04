using Clean.Architecture.Application.Abstractions.Messaging;
using Clean.Architecture.Domain.Abstractions;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Webinars.Commands.CreateWebinar
{
    internal sealed class CreateWebinarCommandHandler : ICommandHandler<CreateWebinarCommand, Guid>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWebinarCommandHandler(IWebinarRepository webinarRepository, IUnitOfWork unitOfWork)
        {
            _webinarRepository = webinarRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
        {
            var webinar = new Webinar(Guid.NewGuid(), request.Name, request.ScheduledOn);

            _webinarRepository.Insert(webinar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return webinar.Id;
        }
    }
}
