namespace Casino;


internal class Game
{
    public decimal Balance { get; private set; }
    public void Deposit( decimal amount )
    {
        Balance += amount;
    }

    public BetOutcome Play( decimal bet )
    {
        var roll = Random.Shared.Next( 1, 21 );

        if ( roll >= 18 && roll <= 20 )
        {
            decimal winAmount = CalculateWinAmount( bet, roll );
            Balance += winAmount;
            return new BetOutcome.Win( roll, winAmount );
        }
        else
        {
            Balance -= bet;
            return new BetOutcome.Loss( roll, bet );
        }
    }

    private static decimal CalculateWinAmount( decimal bet, int seed )
    {
        int multiplicator = 25;
        decimal winAmount = bet * ( 1 + ( decimal )( multiplicator * seed % 17 ) );
        return winAmount;
    }

    public bool IsFinished { get; private set; }
    public void Finish()
    {
        IsFinished = true;
    }
}