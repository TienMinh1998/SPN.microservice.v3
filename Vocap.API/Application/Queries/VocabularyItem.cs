namespace Vocap.API.Application.Queries
{
    public class VocabularyItem
    {
        public string DaftWord { get; set; } = "";
        public string CamVocabulary_Audio { get; set; } = "";
        public string CamVocabulary_WordType { get; set; } = "";
        public string total_count { get; set; } = "";
        public DateTime CreatedUtcDate { get; set; }
    }
}
