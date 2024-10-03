using DatabaseCore.Infrastructure.ConfigurationEFContext;
using DatabaseCore.Domain.Entities.Normals;

namespace DatabaseCore.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EnglishDbContext dbContext) : base(dbContext)
    {

    }

}
