using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCore.Domain.Questions;
using DatabaseCore.Domain.Repositories;
using DatabaseCore.Domain.SeedWork;
using DatabaseCore.Infrastructure.ConfigurationEFContext;

namespace DatabaseCore.Infrastructure.Repositories.Vocabulary
{
    public class QuestionStandardRepository
        : IQuestionStandardDomainRepository
    {
        public QuestionStandardRepository(EnglishDbContext context)
        {
            _context = context;
        }
        private readonly EnglishDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public QuestionStandard SearchQuestion(string vocabulary)
        {
            return _context.QuestionStandards.First(q => q.English == vocabulary);
        }
    }
}
