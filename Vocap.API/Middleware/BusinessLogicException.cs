namespace Vocap.API.Middleware
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message) : base(message) { }
    }
}

