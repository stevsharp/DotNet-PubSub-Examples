
using Shared;

using System.Collections.Concurrent;

using var queue = new BlockingCollection<OrderSubmitted>(boundedCapacity: 100);

// Subscriber 1:

var emailTask = Task.Run(() =>
{
    foreach (var order in queue.GetConsumingEnumerable())
    {
        // Simulate sending email
        Console.WriteLine($"[Email Service] Sending confirmation email for Order {order.OrderId} to {order.CustomerEmail}");
        Task.Delay(500).Wait(); // Simulate delay
    }
});

// Subscriber 2:

var inventoryTask = Task.Run(() =>
{
    foreach (var order in queue.GetConsumingEnumerable())
    {
        // Simulate updating inventory
        Console.WriteLine($"[Inventory Service] Updating inventory for Order {order.OrderId}, Total: {order.Total}");
        Task.Delay(700).Wait(); // Simulate delay
    }
});

foreach (var price in new[] { 49.50m, 129.00m, 250.00m, 15.00m })
{
    queue.Add(new OrderSubmitted(Guid.NewGuid(), $"user{price}@example.com", price));
}

queue.CompleteAdding();

await Task.WhenAll(emailTask, inventoryTask);

Console.WriteLine("All orders processed. Press any key to exit.");
Console.ReadKey();