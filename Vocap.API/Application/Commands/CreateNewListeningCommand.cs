namespace Vocap.API.Application.Commands
{
    public class CreateNewListeningCommand : IRequest<bool>
    {
        public int TimeListening { get; set; }
    }
}
