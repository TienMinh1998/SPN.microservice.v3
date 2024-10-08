using System.Runtime.CompilerServices;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Queries
{
    public interface IVocabularyQueries
    {
        Task<IEnumerable<VocabularyViewModel>> GetVocabularyAsync(string word);

        Task<VocabularyViewModel> SearchWork(string word);

        /// <summary>
        /// get list vocabulary from database 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<VocabularyItem>> ListWork(int pageNumber, int pageSize);

    }
}
