DotNet-PubSub-Examples

This repository contains three different implementations of the Publish/Subscribe (Pub/Sub) pattern in .NET.
The goal is to demonstrate how you can decouple publishers and subscribers using different tools, from in-memory solutions to distributed message brokers.

📖 Overview

Pub/Sub is a messaging pattern where a Publisher sends messages without knowing who receives them, and Subscribers consume those messages independently.
It enables decoupling, scalability, and flexibility in system design.

This repo includes three implementations:

MassTransit + RabbitMQ – a production-ready approach for distributed systems.

Reactive Extensions (Rx) – an in-memory, event-driven approach using observables.

BlockingCollection – a thread-safe producer/consumer approach inside a single process.

🚀 Projects
1. MassTransitDemo

Location: /MassTransitDemo

Uses MassTransit
 with RabbitMQ
.

Publishes an OrderSubmitted event every few seconds.

A consumer subscribes to the same event and logs received messages.

Run RabbitMQ locally with Docker:

docker run -it --rm -p 5672:5672 -p 15672:15672 rabbitmq:3-management


Management UI: http://localhost:15672
 (user: guest / pass: guest)

Start the demo:

cd MassTransitDemo
dotnet run


You’ll see published and consumed messages in the console.

2. ReactiveExtensionsDemo

Location: /ReactiveExtensionsDemo

Uses System.Reactive
.

Demonstrates in-memory event streams with Subject<T>.

Multiple subscribers react to the same published messages.

Run the demo:

cd ReactiveExtensionsDemo
dotnet run


Output:

[Email] Send receipt to a@example.com
[Analytics] Order ... VAT 35.76
...

3. BlockingCollectionDemo

Location: /BlockingCollectionDemo

Uses .NET BlockingCollection
.

Implements a thread-safe producer/consumer queue.

Multiple subscribers consume messages concurrently.

Run the demo:

cd BlockingCollectionDemo
dotnet run


Output:

[Email] Send receipt to user49.50@example.com
[Analytics] Track order ...

🔎 Comparison
Approach	Scope	Durability	Best For
MassTransit + RabbitMQ	Distributed services	✅ Durable	Microservices, cross-service messaging
Reactive Extensions	In-memory streams	❌ No	Reactive pipelines, UI events
BlockingCollection	Single process	❌ No	Producer/consumer, background workers
📂 Solution Structure
DotNet-PubSub-Examples/
│
├── DotNet-PubSub-Examples.sln
│
├── MassTransitDemo/              # MassTransit + RabbitMQ
│
├── ReactiveExtensionsDemo/       # Reactive Extensions
│
└── BlockingCollectionDemo/       # BlockingCollection

📚 References

MassTransit Documentation

RabbitMQ Tutorials

System.Reactive GitHub

BlockingCollection Overview

Microsoft Docs: Publisher-Subscriber Pattern

✅ With these three projects you can see the Pub/Sub pattern in action in .NET, from lightweight in-memory event streams to robust distributed messaging.
