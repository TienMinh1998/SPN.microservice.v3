using DatabaseCore.Infrastructure.ConfigurationEFContext;

namespace DatabaseCore.Infrastructure.Repositories;

public class GrammarRepository : BaseRepository<DatabaseCore.Domain.Entities.Normals.Grammar>, IGrammarRepository
{
    public GrammarRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}
