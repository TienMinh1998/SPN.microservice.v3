using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;

namespace DatabaseCore.Infrastructure.Repositories;
public class ReadingRepository : BaseRepository<Reading>, IReadingRepository
{
    public ReadingRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}
