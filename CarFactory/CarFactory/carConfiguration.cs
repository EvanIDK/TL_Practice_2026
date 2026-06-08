using Spectre.Console;

internal class CarConfigurator
{
    private string[] _makes = { "BMW", "Toyota", "Skoda" };
    private string[] _engines = { "V6", "V8" };
    private string[] _transmissions = { "Автомат", "Механика" };
    private string[] _kuzov = { "Джип", "Седан" };
    private string[] _colors = { "Серый", "Белый", "Фиолетовый" };

    public (string make, string engine, string transmission, string kuzov, string color) GetConfiguration()
    {
        var carMake = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title( "Выберите [green]марку[/] машины:" )
               .AddChoices( _makes ) );

        var carEngine = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title( "Выберите мотор:" )
                   .AddChoices( _engines ) );

        var carTransmission = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title( "Выберите [yellow]коробку передач[/]:" )
                   .AddChoices( _transmissions ) );

        var carKuzov = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title( "Выберите кузов:" )
                   .AddChoices( _kuzov ) );

        var carColor = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title( "Выберите [purple]цвет[/]:" )
                   .AddChoices( _colors ) );

        return (carMake, carEngine, carTransmission, carKuzov, carColor);
    }
}