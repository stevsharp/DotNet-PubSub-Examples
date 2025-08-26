using MassTransit;

using Microsoft.Extensions.Options;

using Shared;

namespace MassTransitDemo.Publisher;

public class PublisherService(
    ILogger<PublisherService> logger,
    IServiceScopeFactory scopeFactory,
    IOptions<PublisherOptions> options) : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var delay = TimeSpan.FromSeconds(options.Value.PublishIntervalSeconds);

        logger.LogInformation("Publisher started, interval {Seconds} seconds", options.Value.PublishIntervalSeconds);

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = scopeFactory.CreateScope();
            
            var publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

            var msg = new OrderSubmitted(Guid.NewGuid(), "customer@example.com", Random.Shared.Next(50, 300));

            logger.LogInformation("Published OrderSubmitted, OrderId {OrderId}", msg.OrderId);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

        }
    }
}


