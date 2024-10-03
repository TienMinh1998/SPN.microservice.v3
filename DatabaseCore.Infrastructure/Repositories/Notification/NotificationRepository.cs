using DatabaseCore.Domain.Entities.Normals;
using DatabaseCore.Infrastructure.ConfigurationEFContext;

namespace DatabaseCore.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(EnglishDbContext DbContext) : base(DbContext)
    {

    }
}
