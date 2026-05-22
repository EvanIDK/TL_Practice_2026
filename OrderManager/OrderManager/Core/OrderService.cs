using OrderManager.Utilities;
using OrderManager.Models;

namespace OrderManager.Core;

internal class OrderService
{
    private Order? _order;

    public void ReadClientOrder()
    {
        Console.WriteLine( "Запрос данных у пользователя " );
        string productName = InputReader.ReadNonEmpty( " - Название товара: " );
        int quantity = InputReader.ReadPositiveInt( " - Количество товара: " );
        string userName = InputReader.ReadLettersOnly( " - Имя пользователя: " );
        string shippingAddress = InputReader.ReadNonEmpty( " - Адрес доставки: " );

        _order = new Order( productName, quantity, userName, shippingAddress );
    }

    public OrderResult ConfirmOrder()
    {
        if ( _order == null )
        {
            throw new InvalidOperationException( "Order не инициализирован. Вначале вызовите ReadClientOrder()" );
        }

        Console.WriteLine( $"Здравствуйте, {_order.UserName}, вы заказали {_order.Quantity} {_order.ProductName} на адрес {_order.ShippingAddress}, все верно?" );
        Console.WriteLine( "Да/Нет: " );

        while ( true )
        {
            string? userResponse = Console.ReadLine()?.Trim();
            if ( string.Equals( userResponse, "да", StringComparison.OrdinalIgnoreCase ) )
            {
                return OrderResult.Confirmed;
            }
            if ( string.Equals( userResponse, "нет", StringComparison.OrdinalIgnoreCase ) )
            {
                return OrderResult.Rejected;
            }
            Console.Write( "Введите Да/Нет: " );
        }

    }

    public void PrintOrderSummary()
    {
        if ( _order == null )
        {
            throw new InvalidOperationException( "Order не инициализирован. Вначале вызовите ReadClientOrder()" );
        }
        var deliveryDate = DateTime.Today.AddDays( 3 );
        Console.WriteLine( $"{_order.UserName}! Ваш заказ {_order.ProductName} в количестве {_order.Quantity} оформлен! Ожидайте доставку по адресу {_order.ShippingAddress} к {deliveryDate:dd.MM.yyyy}" );

    }
}