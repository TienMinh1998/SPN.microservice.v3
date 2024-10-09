using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.ListeningAggreate
{
    public class Listening : Entity
    {
        public int TimeToListening { get; set; }
        public string TypeListening { get; set; } = "";
    }
}
