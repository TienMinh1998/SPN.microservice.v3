using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Commands
{
    public class CreateVocabularyCommandHandler : IRequestHandler<CreateVocabularyCommand, bool>
    {
        private readonly IVocabularyRepository _vocabularyRepository;

        public CreateVocabularyCommandHandler(IVocabularyRepository vocabularyRepository)
        {
            _vocabularyRepository = vocabularyRepository;
        }

        public async Task<bool> Handle(CreateVocabularyCommand request, CancellationToken cancellationToken)
        {
            Vocabulary? newVocap = new Vocabulary(new CamVocabulary(request.Name), request.Desc);
            newVocap.UpdateWorkFromDiction();

            _vocabularyRepository.Add(newVocap);
            return await _vocabularyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
