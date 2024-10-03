using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.SeekWork;

namespace User.Domain.AggregatesModel.UserAggreate
{
    public interface IUserRepository : IRepository<User>
    {
        User? Add(User? User);

        Task<User?> GetUserById(int Id);

        Task<IEnumerable<User>> GetAllByWork(string word);
    }
}
