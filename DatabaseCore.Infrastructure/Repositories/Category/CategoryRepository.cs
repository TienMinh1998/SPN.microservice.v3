using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;
namespace DatabaseCore.Infrastructure.Repositories;


public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}

