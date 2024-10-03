using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Exceptions
{
    public class UserDomainException : Exception
    {
        public UserDomainException()
        { }

        public UserDomainException(string message)
            : base(message)
        { }

        public UserDomainException(string message, Exception innterException)
            : base(message, innterException)
        { }
    }
}
