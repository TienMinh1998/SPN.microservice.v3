namespace Vocap.API.Application.Commands
{
    public class CreateNewListeningCommand : IRequest<CreateListeningResult>
    {
        public int TimeListening { get; set; }
    }
}
