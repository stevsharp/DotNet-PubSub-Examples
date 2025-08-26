using MassTransit;

using MassTransitDemo.Consumer;
using MassTransitDemo.Publisher;

using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<PublisherOptions>(builder.Configuration);

builder.Services.AddMassTransit(mt =>
{
    mt.AddConsumer<OrderSubmittedConsumer>();

    mt.UsingRabbitMq((ctx, cfg) =>
    {
        var section = builder.Configuration.GetSection("RabbitMq");
        var host = section["Host"] ?? "localhost";
        var user = section["Username"] ?? "guest";
        var pass = section["Password"] ?? "guest";

        cfg.Host(host, h =>
        {
            h.Username(user);
            h.Password(pass);
        });

        // one queue for this process, both publisher and consumer can live here for demo
        cfg.ReceiveEndpoint("masstransitdemo-order-submitted", e =>
        {
            e.ConfigureConsumer<OrderSubmittedConsumer>(ctx);
        });

        cfg.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
    });
});

builder.Services.AddHostedService<PublisherService>();

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(o =>
{
    o.SingleLine = true;
    o.TimestampFormat = "HH:mm:ss ";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

