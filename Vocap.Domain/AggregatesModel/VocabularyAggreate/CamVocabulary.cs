using Hola.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.Events;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.VocabularyAggreate
{
    public class CamVocabulary : ValueObject
    {
        public string DaftWord { get; private set; }

        public string Audio { get; private set; }

        public string Phonetic { get; private set; }
        public string WordType { get; private set; }


        public CamVocabulary(string daftWord)
        {
            this.DaftWord = daftWord;
        }

        public CamVocabulary()
        {

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetVocabularyFromCamDictionary(string work)
        {
            try
            {
                APICrossHelper api = new APICrossHelper();

                // get english dictionary
                var english = await api.GetWord(DaftWord);
                if (english != null)
                {
                    Audio = english.Mp3;
                    Phonetic = english.Phonetic;
                    WordType = english.Type;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
