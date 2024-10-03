using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocap.Domain.Events
{
    public class AddEnglishVocabularyDomainEvent : INotification
    {
        public string Vocabulary { get; set; }
        public AddEnglishVocabularyDomainEvent(string vocabulary)
        {
            Vocabulary = vocabulary;
        }
    }
}
