namespace TddMoneyExample
{
    // Expression can be Money type (atomic form) or Sum type.
    // Use reduce to convert multi-currency to a single currency. 
    interface IExpression
    {
        IExpression Plus(IExpression addend);
        IExpression Times(int multiplier);
        Money Reduce(Bank bank, string to);
    }
}
