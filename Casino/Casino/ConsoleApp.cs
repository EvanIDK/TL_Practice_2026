using static Casino.BetOutcome;

namespace Casino;


class ConsoleApp
{
    private readonly Game _game;
    public ConsoleApp( Game game ) => _game = game;
    public void Run()
    {
        PrintHeader();
        MakeDeposit();

        do
        {
            PrintMenu();
            string option = Console.ReadLine() ?? string.Empty;
            HandleOptions( option );
        }
        while ( !_game.IsFinished );

    }
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
        Console.WriteLine( $"\n--- ТЕКУЩИЙ БАЛАНС: {_game.Balance} ---" );
        List<string> menuOptions = [ "1. Пополнить баланс", "2. Показать баланс", "3. Сделать ставку", "4. Выйти" ];
        foreach ( string menuOption in menuOptions )
        {
            Console.WriteLine( menuOption );
        }
    }
    public void HandleOptions( string option )
    {
        switch ( option )
        {
            case "1":
                MakeDeposit();
                break;
            case "2":
                ShowBalance();
                break;
            case "3":
                Play();
                break;
            case "4":
                Exit();
                break;
            default:
                Console.WriteLine( "Неверный пункт меню." );
                break;
        }
    }

    void MakeDeposit()
    {
        var deposit = ReadPositive( "Введите сумму депозита: " );
        _game.Deposit( deposit );

        Console.WriteLine( "Депозит успешно зачислен!" );
    }

    private void ShowBalance()
    {
        Console.WriteLine( $"Текущий баланс = {_game.Balance}" );
    }

    private void Play()
    {
        var bet = ReadPositive( "Введите ставку: " );

        if ( bet > _game.Balance )
        {
            Console.WriteLine( "Недостаточно средств!" );
            return;
        }

        var outcome = _game.Play( bet );
        switch ( outcome )
        {
            case BetOutcome.Win win:
                Console.WriteLine( $"Выпало число {win.Roll}" );
                Console.WriteLine( $"Ты выиграл {win.Amount}" );
                break;
            case BetOutcome.Loss loss:
                Console.WriteLine( $"Выпало число: {loss.Roll}" );
                Console.WriteLine( $"Ты проиграл -:( Потеряно: {loss.BetAmount}" );
                break;
        }
    }

    private void Exit()
    {
        _game.Finish();
        Console.WriteLine( "Спасибо за игру!" );
    }

    private static decimal ReadPositive( string promt )
    {
        Console.Write( promt );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;
        decimal value = 0;

        while ( ( !decimal.TryParse( input, out value ) ) || ( value <= 0 ) )
        {
            Console.WriteLine( "Введите положительное число: " );
            Console.Write( promt );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }
        return value;
    }
}