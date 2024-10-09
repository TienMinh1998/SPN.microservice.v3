namespace Vocap.API.Application.Commands
{
    public class CreateListeningResult
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int TimeTolistening { get; set; }
        public string TypeListening { get; set; } = "";
    }
}
