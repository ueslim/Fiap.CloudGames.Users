namespace FIAP.CloudGames.Core.Messages.Integration
{
    // TODO: This integration event was designed for RabbitMQ messaging.
    // Consider implementing Azure Service Bus or other messaging solutions if needed.
    public class OrderStockDeductedIntegrationEvent : IntegrationEvent
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }

        public OrderStockDeductedIntegrationEvent(Guid clienteId, Guid pedidoId)
        {
            ClientId = clienteId;
            OrderId = pedidoId;
        }
    }
}