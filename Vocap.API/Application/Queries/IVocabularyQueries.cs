using System.Runtime.CompilerServices;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Queries
{
    public interface IVocabularyQueries
    {
        Task<IEnumerable<VocabularyViewModel>> GetVocabularyAsync(string word);

        Task<VocabularyViewModel> SearchWork(string word);
    }
}
