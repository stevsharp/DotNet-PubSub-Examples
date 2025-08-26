namespace Shared;


public record OrderSubmitted(Guid OrderId, string CustomerEmail, decimal Total);
