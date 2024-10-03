using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Vocap.API.Application.Commands
{
    public class CreateVocabularyCommand : IRequest<bool>
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Desc { get; private set; }

        public CreateVocabularyCommand()
        {

        }
        public CreateVocabularyCommand(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
    }


}
