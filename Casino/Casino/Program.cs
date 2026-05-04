Casino casino = new Casino();

Casino.PrintHeader();
casino.MakeDeposit();
do
{
    casino.PrintMenu();
    string option = Console.ReadLine() ?? string.Empty;
    casino.HandleOptions( option );
}
while ( !casino._isGameFinished );