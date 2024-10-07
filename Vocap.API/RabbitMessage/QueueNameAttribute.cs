namespace Vocap.API.RabbitMessage
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class QueueNameAttribute : Attribute
    {
        public string Name { get; }

        public QueueNameAttribute(string name)
        {
            Name = name;
        }
    }
}
