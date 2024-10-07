using System.Reflection;

namespace Vocap.API.RabbitMessage
{
    public class RabbitExtension
    {
        public static string GetQueueName<T>()
        {
            // Get the type of the class
            Type classType = typeof(T);

            // Get the custom attribute from the class
            var attribute = classType.GetCustomAttribute<QueueNameAttribute>();

            // Return the queue name if the attribute is present
            if (attribute != null)
            {
                return attribute.Name;
            }

            // Fallback: generate queue name from class name
            return $"{classType.Name.ToLower()}";
        }
    }
}
