namespace FIAP.CloudGames.Core.Messages.Integration
{
    // TODO: This integration event was designed for RabbitMQ messaging.
    // Consider implementing Azure Service Bus or other messaging solutions if needed.
    public class OrderPlacedIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }

        public OrderPlacedIntegrationEvent(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}