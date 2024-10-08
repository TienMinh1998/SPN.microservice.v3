using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Infrastructure;
using Vocap.Infrastructure.Dapper;

namespace Vocap.API.Application.Queries
{
    public class VocabularyQueries(VocabularyContext context, IDapper dapper) : IVocabularyQueries
    {
        private readonly IDapper _dapper;

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

        public async Task<IEnumerable<VocabularyItem>> ListWork(int page, int pageSize)
        {
            string query = "SELECT * FROM vocap.get_paged_vocabularies(@Page, @PageSize)";
            // Sử dụng anonymous object để truyền các tham số
            var parameters = new { Page = page, PageSize = pageSize };
            // Thực hiện truy vấn với Dapper
            return await dapper.GetAllAsync<VocabularyItem>(query, parameters);
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
