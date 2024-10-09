using Microsoft.AspNetCore.Mvc;
using Vocap.API.Application.Commands;
using Vocap.API.Application.Queries;

namespace Vocap.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ListeningController : ControllerBase
{

    private readonly IMediator mediator;
    private readonly IVocabularyQueries queries;
    public ListeningController(IMediator mediator, IVocabularyQueries queries)
    {
        this.mediator = mediator;
        this.queries = queries;
    }


    [HttpPost]
    public async Task<IActionResult> CreateNewListening([FromBody] CreateLogRequest request)
    {
        var createdCommand = new CreateNewListeningCommand();
        createdCommand.TimeListening = request.Time;
        var updateResult = await mediator.Send(createdCommand);
        return Ok(updateResult);
    }

}
public class CreateLogRequest
{
    public int Time { get; set; }
}
