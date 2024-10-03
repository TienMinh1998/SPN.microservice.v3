using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocap.Domain.Exceptions
{
    public class VocabularyDomainException : Exception
    {
        public VocabularyDomainException()
        { }

        public VocabularyDomainException(string message)
            : base(message)
        { }

        public VocabularyDomainException(string message, Exception innterException)
            : base(message, innterException)
        { }
    }
}
