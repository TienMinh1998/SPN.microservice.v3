using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocap.Domain.Events
{
    public class CollocationCreatedDomainEvent : INotification
    {
        public string LeftVocabulary { get; set; }
        public string RightVocabulary { get; set; }

        public CollocationCreatedDomainEvent(string leftVocabulary, string rightVocabulary)
        {
            LeftVocabulary = leftVocabulary;
            RightVocabulary = rightVocabulary;
        }
    }
}
