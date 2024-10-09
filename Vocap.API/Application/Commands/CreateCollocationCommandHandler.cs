
using Vocap.Domain.AggregatesModel.CollocationsAggreate;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Commands
{
    public class CreateCollocationCommandHandler : IRequestHandler<CreateCollocationCommand, bool>
    {
        private readonly ICollocationRepository collocationRepository;
        private ILogger<CreateCollocationCommandHandler> _logger;

        public CreateCollocationCommandHandler(ICollocationRepository collocationRepository, ILogger<CreateCollocationCommandHandler> logger)
        {
            this.collocationRepository = collocationRepository;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateCollocationCommand request, CancellationToken cancellationToken)
        {
            var result = collocationRepository.Add(request.CollocationName, request.Define, request.AreaName);
            await collocationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
