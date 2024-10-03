using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.SeekWork;

namespace User.Domain.AggregatesModel.UserAggreate
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
