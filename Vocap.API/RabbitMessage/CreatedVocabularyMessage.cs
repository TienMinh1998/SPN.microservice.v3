using EventBus.Events;

namespace Vocap.API.RabbitMessage
{
    [QueueName("vocabulary_created_ok")]
    public class CreatedVocabularyMessage : BaseMessage
    {
        public string Daftword { get; set; } = "";

        public CreatedVocabularyMessage(string newVocabulary)
        {
            this.Daftword = newVocabulary;
        }
    }
}
