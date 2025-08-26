## Connect with Me

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Profile-blue)](https://www.linkedin.com/in/spyros-ponaris-913a6937/)

# DotNet-PubSub-Examples

This repository contains **three different implementations of the Publish/Subscribe (Pub/Sub) pattern in .NET**.  
The goal is to demonstrate how you can decouple publishers and subscribers using different tools, from in-memory solutions to distributed message brokers.

---

## 📖 Overview

**Publish/Subscribe (Pub/Sub)** is a messaging pattern where a **Publisher** sends messages without knowing who receives them, and **Subscribers** consume those messages independently.  

This enables:
- 🔗 **Decoupling** – publishers don’t need to know subscribers  
- ⚡ **Scalability** – multiple subscribers can process messages in parallel  
- 🛠️ **Flexibility** – new subscribers can be added without changing the publisher  

This repo includes three implementations:

1. **MassTransit + RabbitMQ** – a production-ready approach for distributed systems  
2. **Reactive Extensions (Rx)** – an in-memory, event-driven approach using observables  
3. **BlockingCollection** – a thread-safe producer/consumer approach inside a single process  

---

## 🚀 Projects

### 1. MassTransitDemo
📂 Path: `/MassTransitDemo`  

- Uses [MassTransit](https://masstransit.io/) with [RabbitMQ](https://www.rabbitmq.com/)  
- Publishes an `OrderSubmitted` event every few seconds  
- A consumer subscribes to the same event and logs received messages  

Run RabbitMQ locally with Docker:

```bash
docker run -it --rm -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

RabbitMQ Management UI → http://localhost:15672
 (user: guest, pass: guest)

Run the demo:
```bash
cd MassTransitDemo
dotnet run
```
2. ReactiveExtensionsDemo

📂 Path: /ReactiveExtensionsDemo

Uses System.Reactive

Demonstrates in-memory event streams with Subject<T>

Multiple subscribers react to the same published messages

Run the demo:
```bash
cd ReactiveExtensionsDemo
dotnet run
```
Sample output:

[Email] Send receipt to a@example.com
[Analytics] Order ... VAT 35.76
...

3. BlockingCollectionDemo

📂 Path: /BlockingCollectionDemo

Uses .NET BlockingCollection

Implements a thread-safe producer/consumer queue

Multiple subscribers consume messages concurrently

Run the demo:
```bash
cd BlockingCollectionDemo
dotnet run
```

Sample output:
```bash
[Email] Send receipt to user49.50@example.com
[Analytics] Track order ...
```


## Connect with Me

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Profile-blue)](https://www.linkedin.com/in/spyros-ponaris-913a6937/)
