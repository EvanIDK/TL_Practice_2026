using Spectre.Console;

var greeting = new FigletText( "Car Factory" )
{
    Justification = Justify.Center
};
AnsiConsole.Write( greeting );

var configurator = new CarConfigurator();
var config = configurator.GetConfiguration();

var car = new Car();
car.Configure( config.make, config.engine, config.transmission, config.kuzov, config.color );
car.PrintStats();