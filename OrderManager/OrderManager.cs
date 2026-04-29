internal class OrderManager
{
    private string? _productName;
    private string? _productQuantity;
    private string? _userName;
    private string? _shippingAddress;
    private DateTime _todayDate = DateTime.Today;

    public void GetClientOrder()
    {
        Console.WriteLine( "1. Запрос данных у пользователя " );
        _productName = InputReader.ReadNonEmpty( " - Название товара: " );
        _productQuantity = InputReader.ReadQuantityInt( " - Количество товара: " );
        _userName = InputReader.ReadLettersOnly( " - Имя пользователя: " );
        _shippingAddress = InputReader.ReadNonEmpty( " - Адрес доставки: " );
    }

    public OrderResult OrderConfirmation()
    {
        Console.WriteLine( $"Здравствуйте, {_userName}, вы заказали {_productQuantity} {_productName} на адрес {_shippingAddress}, все верно?" );
        Console.WriteLine( "Да/Нет: " );
        string? userResponse = Console.ReadLine()?.Trim();

        while ( true )
        {
            if ( ( userResponse == "Да" ) || ( userResponse == "да" ) )
            {
                return OrderResult.Success;
            }
            else if ( ( userResponse == "Нет" ) || ( userResponse == "нет" ) )
            {
                return OrderResult.RepeatOrder;
            }
            else
            {
                Console.Write( "Введите Да/Нет" );
                userResponse = Console.ReadLine()?.Trim();
            }
        }
    }

    public void PrintOrderConfirmation()
    {
        Console.WriteLine( $"{_userName}! Ваш заказ {_productName} в количестве {_productQuantity} оформлен! Ожидайте доставку по адресу {_shippingAddress} к {_todayDate.AddDays( 3 ):dd.MM.yyyy}" );
    }
}
