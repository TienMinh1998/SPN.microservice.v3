

using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocap.API.Application.Queries;
using Vocap.Domain.AggregatesModel.ListeningAggreate;
using Vocap.Infrastructure.Dapper;

namespace Vocap.API.Application.Commands;

public class CreateNewListeningCommandHandler : IRequestHandler<CreateNewListeningCommand, CreateListeningResult>
{
    private readonly IListeningRepository _repository;
    private ILogger<CreateNewListeningCommandHandler> _logger;
    private readonly IDapper _dapper;
    public CreateNewListeningCommandHandler(IListeningRepository repository, ILogger<CreateNewListeningCommandHandler> logger, IDapper dapper)
    {
        _repository = repository;
        _logger = logger;
        _dapper = dapper;
    }

    public async Task<CreateListeningResult> Handle(CreateNewListeningCommand request, CancellationToken cancellationToken)
    {
        string query = "SELECT * FROM vocap.func_update_time_for_lestening(@time)";
        var parameters = new { time = request.TimeListening };
        return await _dapper.QueryFirstAsync<CreateListeningResult>(query, parameters);
    }
}
