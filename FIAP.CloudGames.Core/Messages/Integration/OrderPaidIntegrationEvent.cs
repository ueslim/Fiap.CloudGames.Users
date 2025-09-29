namespace FIAP.CloudGames.Core.Messages.Integration
{
    // TODO: This integration event was designed for RabbitMQ messaging.
    // Consider implementing Azure Service Bus or other messaging solutions if needed.
    public class OrderPaidIntegrationEvent : IntegrationEvent
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }

        public OrderPaidIntegrationEvent(Guid clientId, Guid orderId)
        {
            ClientId = clientId;
            OrderId = orderId;
        }
    }
}