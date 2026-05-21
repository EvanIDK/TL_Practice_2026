namespace Casino;

internal abstract record BetOutcome( int Roll )
{
    public sealed record Win( int Roll, decimal Amount ) : BetOutcome( Roll );
    public sealed record Loss( int Roll, decimal BetAmount ) : BetOutcome( Roll );
}