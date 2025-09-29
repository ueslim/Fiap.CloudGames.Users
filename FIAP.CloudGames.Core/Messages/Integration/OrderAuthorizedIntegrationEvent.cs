namespace FIAP.CloudGames.Core.Messages.Integration
{
    // TODO: This integration event was designed for RabbitMQ messaging.
    // Consider implementing Azure Service Bus or other messaging solutions if needed.
    public class OrderAuthorizedIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public IDictionary<Guid, int> Items { get; private set; }

        public OrderAuthorizedIntegrationEvent(Guid clienteId, Guid pedidoId, IDictionary<Guid, int> itens)
        {
            CustomerId = clienteId;
            OrderId = pedidoId;
            Items = itens;
        }
    }
}