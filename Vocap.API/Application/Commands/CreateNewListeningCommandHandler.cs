

using Vocap.Domain.AggregatesModel.ListeningAggreate;

namespace Vocap.API.Application.Commands;

public class CreateNewListeningCommandHandler : IRequestHandler<CreateNewListeningCommand, bool>
{
    private readonly IListeningRepository _repository;
    private ILogger<CreateNewListeningCommandHandler> _logger;

    public CreateNewListeningCommandHandler(IListeningRepository repository, ILogger<CreateNewListeningCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(CreateNewListeningCommand request, CancellationToken cancellationToken)
    {
        Listening newListening = new Listening();
        newListening.TimeToListening = request.TimeListening;
        var result = _repository.Add(newListening);
        return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
