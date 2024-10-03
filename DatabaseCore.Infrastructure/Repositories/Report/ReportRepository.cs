using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;

namespace DatabaseCore.Infrastructure.Repositories;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    public ReportRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}
