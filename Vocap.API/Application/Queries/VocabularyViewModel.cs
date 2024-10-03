using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.API.Application.Queries;

public class VocabularyViewModel
{
    public string word { get; set; }
    public CamVocabulary CamVocabulary { get; set; } = new();

    public VocabularyViewModel(string word)
    {
        this.word = word;
    }

    public VocabularyViewModel()
    {

    }
}
