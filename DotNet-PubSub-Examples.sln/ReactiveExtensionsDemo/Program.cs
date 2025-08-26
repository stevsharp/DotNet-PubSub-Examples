
using Shared;

using System.Reactive.Subjects;

var bus = new Subject<OrderSubmitted>();

// Subscriber

var subA = bus.Subscribe(
    order => Console.WriteLine($"Subscriber A: Order {order.OrderId} for {order.CustomerEmail} totaling {order.Total}"),
    ex => Console.WriteLine($"Subscriber A Error: {ex.Message}"),
    () => Console.WriteLine("Subscriber A Completed"));

var subB = bus
            .Where(o => o.Total >= 100)
            .Select(o => new { o.OrderId, Vat = o.Total * 0.24m })
            .Subscribe(x =>
                Console.WriteLine($"[Analytics] Order {x.OrderId}, VAT {x.Vat:F2}"));

bus.OnNext(new OrderSubmitted(Guid.NewGuid(), "oo1@pp.gr" , 150.75m));
bus.OnNext(new OrderSubmitted(Guid.NewGuid(), "oo2@pp.gr", 10.75m));
bus.OnNext(new OrderSubmitted(Guid.NewGuid(), "oo3@pp.gr", 12.75m));

bus.OnCompleted();

subA.Dispose();
subB.Dispose();

Console.WriteLine("Done, press any key");
Console.ReadKey();
