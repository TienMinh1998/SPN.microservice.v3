using Vocap.API.Middleware;
using Vocap.API.RabbitMessage;
using Vocap.API.RabbitMQSender;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Commands
{
    public class CreateVocabularyCommandHandler : IRequestHandler<CreateVocabularyCommand, bool>
    {
        private readonly IVocabularyRepository _vocabularyRepository;
        private ILogger<CreateVocabularyCommandHandler> _logger;
        public CreateVocabularyCommandHandler(IVocabularyRepository vocabularyRepository, ILogger<CreateVocabularyCommandHandler> logger)
        {
            _vocabularyRepository = vocabularyRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateVocabularyCommand request, CancellationToken cancellationToken)
        {
            var oldVocabulary = await _vocabularyRepository.GetVocabularyByString(request.Name);
            if (oldVocabulary is { })
            {
                _logger.LogInformation($"{request.Name} is available");
                return false;
            }
            else
            {
                // save to database: 
                Vocabulary? newVocap = new Vocabulary(new CamVocabulary(request.Name), request.Desc);
                newVocap.UpdateWorkFromDiction();
                _vocabularyRepository.Add(newVocap);
                return await _vocabularyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
