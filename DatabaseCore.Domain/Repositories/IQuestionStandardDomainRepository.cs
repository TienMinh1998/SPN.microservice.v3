using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCore.Domain.Questions;
using DatabaseCore.Domain.SeedWork;

namespace DatabaseCore.Domain.Repositories;

public interface IQuestionStandardDomainRepository : IRepository<QuestionStandard>
{
    QuestionStandard SearchQuestion(string vocabulary);
}
