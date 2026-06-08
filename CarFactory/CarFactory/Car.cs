using Spectre.Console;
internal class Car
{
    private string _make = string.Empty;
    private string _engine = string.Empty;
    private string _transmission = string.Empty;
    private string _kuzov = string.Empty;
    private string _color = string.Empty;
    private int _numberOfGears;
    private int _maxSpeed = 180;

    public void Configure( string make, string engine,
                         string transmission, string kuzov, string color )
    {
        _make = make;
        _engine = engine;
        _transmission = transmission;
        _kuzov = kuzov;
        _color = color;
        CalculateStats();
    }

    private void CalculateStats()
    {
        if ( _kuzov == "Седан" )
        {
            _maxSpeed += 20;
        }
        else if ( _kuzov == "Джип" )
        {
            _maxSpeed -= 10;
        }

        if ( _transmission == "Механика" )
        {
            _maxSpeed += 15;
            _numberOfGears = 6;
        }
        else if ( _transmission == "Автомат" )
        {
            _numberOfGears = 9;
        }

        if ( _engine == "V8" )
        {
            _maxSpeed += 40;
        }
    }

    public void PrintStats()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine( $"[green]Готово![/] Твоя {_make} собрана!" );
        var table = new Table();
        table.Title( "Характеристики" );
        table.Border( TableBorder.Rounded );
        table.AddColumn( "Параметр" );
        table.AddColumn( "Значение" );
        table.AddRow( "Марка", _make );
        table.AddRow( "Кузов", _kuzov );
        table.AddRow( "Мотор", _engine );
        table.AddRow( "КПП", _transmission );
        table.AddRow( "Максимальная скорость", $"{_maxSpeed} км/ч" );
        table.AddRow( "Кол-во передач", _numberOfGears.ToString() );
        AnsiConsole.Write( table );
    }
}