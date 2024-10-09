using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.CollocationsAggreate;
using Vocap.Domain.SeekWork;

namespace Vocap.Infrastructure.Repositories
{
    public class CollocationRepository : ICollocationRepository
    {
        private readonly VocabularyContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public CollocationRepository(VocabularyContext context)
        {
            _context = context;
        }

        public Collocation? Add(string Name, string define, string area)
        {
            var newCollocation = new Collocation(Name, define, area);
            bool isOK = newCollocation.Validate();
            // check collocationOK
            if (isOK)
            {
                return _context.Collocations.Add(newCollocation).Entity;
            }
            throw new NotImplementedException();
        }
    }
}
