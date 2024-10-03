using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;
namespace DatabaseCore.Infrastructure.Repositories;

public class TopicRepository : BaseRepository<Topic>, ITopicRepository
{
    public TopicRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}
