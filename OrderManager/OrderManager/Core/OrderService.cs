using OrderManager.Utilities;
using OrderManager.Models;

namespace OrderManager.Core;

internal class OrderService
{
    private Order? _order;

    public void GetClientOrder()
    {
        Console.WriteLine( "1. Запрос данных у пользователя " );
        string productName = InputValidator.ReadNonEmpty( " - Название товара: " );
        int quantity = InputValidator.ReadQuantityInt( " - Количество товара: " );
        string userName = InputValidator.ReadLettersOnly( " - Имя пользователя: " );
        string shippingAddress = InputValidator.ReadNonEmpty( " - Адрес доставки: " );

        _order = new Order( productName, quantity, userName, shippingAddress );
    }

    public OrderResult OrderConfirmation()
    {
        Console.WriteLine( $"Здравствуйте, {_order!.UserName}, вы заказали {_order.Quantity} {_order.ProductName} на адрес {_order.ShippingAddress}, все верно?" );
        Console.WriteLine( "Да/Нет: " );
        string? userResponse = Console.ReadLine()?.Trim();

        while ( true )
        {
            if ( string.Equals( userResponse, "да", StringComparison.OrdinalIgnoreCase ) )
            {
                return OrderResult.Success;
            }
            else if ( string.Equals( userResponse, "нет", StringComparison.OrdinalIgnoreCase ) )
            {
                return OrderResult.RepeatOrder;
            }
            else
            {
                Console.Write( "Введите Да/Нет: " );
                userResponse = Console.ReadLine()?.Trim();
            }
        }
    }

    public void PrintOrderSummary()
    {
        var deliveryDate = DateTime.Today.AddDays( 3 );
        Console.WriteLine( $"{_order!.UserName}! Ваш заказ {_order.ProductName} в количестве {_order.Quantity} оформлен! Ожидайте доставку по адресу {_order.ShippingAddress} к {deliveryDate:dd.MM.yyyy}" );
    }
}