using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Domain.SeekWork;

namespace Vocap.Infrastructure.Repositories
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly VocabularyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public VocabularyRepository(VocabularyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Vocabulary? Add(Vocabulary? vocabulary)
        {
            return _context.Vocabularies.Add(vocabulary).Entity;
        }

        public async Task<Vocabulary?> GetVocabularyById(int Id)
        {
            return await _context.Vocabularies.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Vocabulary>> GetAllByWork(string word)
        {
            return await _context.Vocabularies.Where(v => v.DaftWord == word).ToListAsync();
        }
    }
}
