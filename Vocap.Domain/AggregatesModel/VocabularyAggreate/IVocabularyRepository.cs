using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.VocabularyAggreate
{
    public interface IVocabularyRepository : IRepository<Vocabulary>
    {
        Vocabulary? Add(Vocabulary? vocabulary);

        Task<Vocabulary?> GetVocabularyById(int Id);

        Task<IEnumerable<Vocabulary>> GetAllByWork(string word);
    }
}
