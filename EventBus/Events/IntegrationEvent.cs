using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public class IntegrationEvent
    {
        [JsonInclude]
        public Guid Id { get; set; }

        [JsonInclude]
        public DateTime CreationDate { get; set; }


        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
