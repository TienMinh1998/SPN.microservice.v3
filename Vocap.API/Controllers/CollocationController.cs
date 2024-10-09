using Microsoft.AspNetCore.Mvc;
using Vocap.API.Application.Commands;
using Vocap.API.Application.Queries;

namespace Vocap.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CollocationController : ControllerBase
{
    private readonly IMediator mediator;

    public CollocationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Collocation([FromBody] CreateCollocationCommand request)
    {
        var newCollocation = await mediator.Send(request);
        return Ok(newCollocation);
    }
}
