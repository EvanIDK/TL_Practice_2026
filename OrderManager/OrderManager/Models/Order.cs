namespace OrderManager.Models;

internal sealed record Order(
    string ProductName,
    int Quantity,
    string UserName,
    string ShippingAddress
    );