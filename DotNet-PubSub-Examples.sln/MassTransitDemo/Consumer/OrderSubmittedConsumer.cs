using MassTransit;

using Shared;

namespace MassTransitDemo.Consumer;

public sealed class OrderSubmittedConsumer(ILogger<OrderSubmittedConsumer> logger) : IConsumer<OrderSubmitted>
{
    public Task Consume(ConsumeContext<OrderSubmitted> context)
    {
       var message = context.Message;
         logger.LogInformation("Order submitted: {OrderId}, Customer: {CustomerEmail}, Total: {Total}",
              message.OrderId, message.CustomerEmail, message.Total);

        return Task.CompletedTask;
    }
}
