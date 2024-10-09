
using Vocap.Domain.Events;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.CollocationsAggreate
{
    public class Collocation : Entity, IAggregateRoot
    {
        public string CollocationName { get; set; } = "";
        public string Define { get; set; } = "";
        public string AreaName { get; set; } = "";
        private string FirstVocabulary = "";
        private string LastVocabulary = "";

        public Collocation(string collocationName, string define, string areaName)
        {
            CollocationName = collocationName;
            Define = define;
            AreaName = areaName;
            SpitWork(collocationName);
        }

        public string GetFirstWork()
        {
            return FirstVocabulary;
        }

        public string GetLastWork()
        {
            return LastVocabulary;
        }

        /// <summary>
        /// Create :
        /// </summary>
        /// <param name="work"></param>
        private void SpitWork(string work)
        {
            string input = work; // Cụm từ cần tách
            string[] words = input.Split(' '); // Tách bằng dấu cách

            if (words.Length >= 2)
            {
                string firstWord = words[0]; // Lấy từ đầu tiên
                string secondWord = words[1]; // Lấy từ thứ hai
                // Create 2 work in database : 
                FirstVocabulary = firstWord;
                LastVocabulary = secondWord;
            }
            else
            {

            }
        }

        /// <summary>
        /// Validate, push message
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(FirstVocabulary) || string.IsNullOrEmpty(LastVocabulary))
            {
                return false;
            }
            else
            {
                // ADD DOMAIN EVENT FOR COLLOCATION IS OK;
                AddDomainEvent(new CollocationCreatedDomainEvent(FirstVocabulary, LastVocabulary));
            }
            return true;
        }
    }
}
