internal static class InputReader
{

    internal static string ReadLettersOnly( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        while ( ( input == "" ) || ( !input.All( char.IsLetter ) ) )
        {
            Console.WriteLine( "Можно использовать только буквы!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return input;
    }

    internal static string ReadNonEmpty( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        while ( input == "" )
        {
            Console.WriteLine( "Поле не может быть пустым!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return input;
    }

    internal static string ReadQuantityInt( string orderInfo )
    {
        Console.Write( orderInfo );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        while ( ( !int.TryParse( input, out int value ) ) || ( value <= 0 ) )
        {
            Console.WriteLine( "Введите целое положительное число!" );
            Console.Write( orderInfo );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return input;
    }
}