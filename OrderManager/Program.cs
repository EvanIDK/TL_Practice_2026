OrderManager order = new OrderManager();
OrderResult confirmed = OrderResult.RepeatOrder;

while ( confirmed != OrderResult.Success )
{
    order.GetClientOrder();
    confirmed = order.OrderConfirmation();

    if ( confirmed == OrderResult.Success )
    {
        order.PrintOrderConfirmation();
    }
}

enum OrderResult
{
    Success,
    RepeatOrder
}

class OrderManager
{
    private string productName;
    private string productQuantity;
    private string yourName;
    private string shippingAddress;
    private DateTime todays_date = DateTime.Today;

    public void GetClientOrder()
    {
        Console.WriteLine( "1. Запрос данных у пользователя " );
        productName = ReadNonEmpty( " - Название товара: " );
        productQuantity = ReadQuantityInt( " - Количество товара: " );
        yourName = ReadLettersOnly( " - Имя пользователя: " );
        shippingAddress = ReadNonEmpty( " - Адрес доставки: " );
    }

    public OrderResult OrderConfirmation()
    {
        Console.WriteLine( $"Здравствуйте, {yourName}, вы заказали {productQuantity} {productName} на адрес {shippingAddress}, все верно?" );
        Console.WriteLine( "Да/Нет: " );
        string tryConfirmation = Console.ReadLine()?.Trim();

        while ( true )
        {
            if ( ( tryConfirmation == "Да" ) || ( tryConfirmation == "да" ) )
            {
                return OrderResult.Success;
            }
            else if ( ( tryConfirmation == "Нет" ) || ( tryConfirmation == "нет" ) )
            {
                return OrderResult.RepeatOrder;
            }
            else
            {
                Console.Write( "Введите Да/Нет" );
                tryConfirmation = Console.ReadLine()?.Trim();
            }
        }
    }

    public void PrintOrderConfirmation()
    {
        Console.WriteLine( $"{yourName}! Ваш заказ {productName} в количестве {productQuantity} оформлен! Ожидайте доставку по адресу {shippingAddress} к {todays_date.AddDays( 3 ):dd.MM.yyyy}" );
    }

    private string ReadQuantityInt( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim();

        while ( ( !int.TryParse( input, out int value ) ) || ( value <= 0 ) )
        {
            Console.WriteLine( "Введите целое положительное число!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim();
        }

        return input;
    }

    private string ReadLettersOnly( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim();

        while ( ( input == "" ) || ( !input.All( char.IsLetter ) ) )
        {
            Console.WriteLine( "Можно использовать только буквы!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim();
        }

        return input;
    }

    private string ReadNonEmpty( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim();

        while ( input == "" )
        {
            Console.WriteLine( "Поле не может быть пустым!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim();
        }

        return input;
    }
}
