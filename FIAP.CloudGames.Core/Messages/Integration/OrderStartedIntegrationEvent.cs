namespace FIAP.CloudGames.Core.Messages.Integration
{
    // TODO: This integration event was designed for RabbitMQ messaging.
    // Consider implementing Azure Service Bus or other messaging solutions if needed.
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public int PaymentType { get; set; }
        public decimal Value { get; set; }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string CvvCard { get; set; }
    }
}