Casino casino = new Casino();

Casino.PrintHeader();

while ( casino.MakeDeposit() != OptionHandleResult.Success )
{
    Console.WriteLine( "Введите натуральное число > 0" );
}
do
{
    casino.PrintMenu();
    string option = Console.ReadLine() ?? string.Empty;
    casino.HandleOptions( option );
}
while ( !casino.isGameFinished );
