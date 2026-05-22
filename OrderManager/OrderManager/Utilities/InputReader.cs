namespace OrderManager.Utilities;

internal static class InputReader
{

    internal static string ReadLettersOnly( string prompt )
    {
        Console.Write( prompt );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        while ( ( input == "" ) || ( !input.All( char.IsLetter ) ) )
        {
            Console.WriteLine( "Можно использовать только буквы!" );
            Console.Write( prompt );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return input;
    }

    internal static string ReadNonEmpty( string prompt )
    {
        Console.Write( prompt );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        while ( input == "" )
        {
            Console.WriteLine( "Поле не может быть пустым!" );
            Console.Write( prompt );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return input;
    }

    internal static int ReadPositiveInt( string prompt )
    {
        Console.Write( prompt );
        string input = Console.ReadLine()?.Trim() ?? string.Empty;
        int value = 0;

        while ( ( !int.TryParse( input, out value ) ) || ( value <= 0 ) )
        {
            Console.WriteLine( "Введите целое положительное число!" );
            Console.Write( prompt );
            input = Console.ReadLine()?.Trim() ?? string.Empty;
        }

        return value;
    }
}