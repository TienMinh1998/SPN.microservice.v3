using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;


namespace DatabaseCore.Infrastructure.Repositories;

public class UserManualRepository : BaseRepository<UserManual>, IUserManualRepository
{
    public UserManualRepository(EnglishDbContext DbContext) : base(DbContext)
    {
    }
}
