
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Domain.SeekWork;
namespace Vocap.Domain.AggregatesModel.CollocationsAggreate;



public interface ICollocationRepository : IRepository<Collocation>
{
    Collocation? Add(string Name, string define, string area);
}
