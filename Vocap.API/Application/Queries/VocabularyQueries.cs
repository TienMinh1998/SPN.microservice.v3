using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Infrastructure;

namespace Vocap.API.Application.Queries
{
    public class VocabularyQueries(VocabularyContext context) : IVocabularyQueries
    {
        public async Task<IEnumerable<VocabularyViewModel>> GetVocabularyAsync(string word)
        {
            try
            {
                var listVocabulary = await context.Vocabularies
                    .Where(v => v.DaftWord == word)
                    .Select(o => new VocabularyViewModel
                    {
                        CamVocabulary = o.CamVocabulary,
                        word = o.DaftWord
                    }).ToListAsync();
                return listVocabulary;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<VocabularyViewModel> SearchWork(string word)
        {
            VocabularyViewModel vocabulary = new VocabularyViewModel(word);
            // SEARCH FROM DB
            var listVocabulary = await context.Vocabularies
                .Where(x => x.DaftWord == word)
                .FirstOrDefaultAsync();


            // SEARCH FROM INTERNET
            if (listVocabulary == null)
            {
                CamVocabulary cam = new CamVocabulary(word);
                var work_OK = await cam.GetVocabularyFromCamDictionary(word);
                if (work_OK)
                {
                    vocabulary.CamVocabulary = cam;
                }
            }

            return vocabulary;
        }
    }
}
