using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.ListeningAggreate
{
    public interface IListeningRepository : IRepository<Vocabulary>
    {
        Listening? Add(Listening? vocabulary);
    }
}
