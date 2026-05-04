internal class Casino
{
    private double _balance = 0;
    public bool _isGameFinished = false;

    public static void PrintHeader()
    {
        string[] header = [
        "#####   ##   #####  ####   #   #   ##  ",
        "#      #  #  #        #    ##  #  #  # ",
        "#      ####  #####    #    # # #  #  # ",
        "#      #  #      #    #    #  ##  #  # ",
        "#####  #  #  #####  #####  #   #   ##  "
        ];

        foreach ( string line in header )
        {
            Console.WriteLine( line );
        }
    }

    public void PrintMenu()
    {
        Console.WriteLine( $"\n--- ТЕКУЩИЙ БАЛАНС: {_balance} ---" );
        List<string> menuOptions = [ "1. Пополнить баланс", "2. Показать баланс", "3. Сделать ставку", "4. Выйти" ];
        foreach ( string menuOption in menuOptions )
        {
            Console.WriteLine( menuOption );
        }
    }

    public OptionHandleResult HandleOptions( string option )
    {
        switch ( option )
        {
            case "1":
                return MakeDeposit();
            case "2":
                return ShowBalance();
            case "3":
                return Play();
            case "4":
                return Exit();
            default:
                Console.WriteLine( "Неверный пункт меню." );
                return OptionHandleResult.InvalidOption;
        }
    }

    public OptionHandleResult MakeDeposit()
    {
        Console.WriteLine( "Введите сумму депозита:" );
        string? depositStr = Console.ReadLine();

        if ( !double.TryParse( depositStr, out double deposit ) || deposit <= 0 )
        {
            Console.WriteLine( "Ошибка: неверная сумма" );
            return OptionHandleResult.InvalidDepositNumber;
        }

        _balance += deposit;
        return OptionHandleResult.Success;
    }

    private OptionHandleResult ShowBalance()
    {
        Console.WriteLine( $"Текущий баланс = {_balance}" );
        return OptionHandleResult.Success;
    }

    private OptionHandleResult Play()
    {
        Console.WriteLine( "Введите ставку:" );
        string? betStr = Console.ReadLine();

        if ( !int.TryParse( betStr, out int bet ) || bet <= 0 )
        {
            Console.WriteLine( "Неверный формат ставки" );
            return OptionHandleResult.InvalidBet;
        }

        if ( bet > _balance )
        {
            Console.WriteLine( "Недостаточно средств!" );
            return OptionHandleResult.InvalidBet;
        }

        var outCome = Random.Shared.Next( 1, 21 );
        Console.WriteLine( $"Выпало число: {outCome}" );

        if ( outCome >= 18 && outCome <= 20 )
        {
            double winAmount = CalculateWinAmount( bet, outCome );
            _balance += winAmount;
            Console.WriteLine( $"Вы выиграли: {winAmount}!" );
        }
        else
        {
            _balance -= bet;
            Console.WriteLine( "Проигрыш." );
        }
        return OptionHandleResult.Success;
    }

    private static double CalculateWinAmount( int bet, int seed )
    {
        int multiplicator = 25;
        double winAmount = bet * ( 1 + ( double )( multiplicator * seed % 17 ) );
        return winAmount;
    }

    private OptionHandleResult Exit()
    {
        _isGameFinished = true;
        return OptionHandleResult.Success;
    }
}