using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.ListeningAggreate;
using Vocap.Domain.SeekWork;

namespace Vocap.Infrastructure.Repositories
{
    public class ListeningRepository : IListeningRepository
    {

        private readonly VocabularyContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ListeningRepository(VocabularyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Listening? Add(Listening? listeningTask)
        {
            return _context.listenings.Add(listeningTask).Entity;
        }
    }
}
