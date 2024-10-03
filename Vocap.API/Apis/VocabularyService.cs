

namespace Vocap.API.Apis;

public class VocabularyService(
    IMediator mediator,
    ILogger<VocabularyService> logger
    )
{
    public IMediator Mediator { get; set; } = mediator;

}
