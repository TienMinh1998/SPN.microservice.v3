namespace Vocap.API.Application.Commands
{
    public class CreateCollocationCommand : IRequest<bool>
    {
        public string CollocationName { get; set; } = "";
        public string Define { get; set; } = "";
        public string AreaName { get; set; } = "";
    }
}
