namespace TddMoneyExample
{
    // Expression can be Money type (atomic form) or Sum type.
    // Use reduce to convert multi-currency to a single currency. 
    interface IExpression
    {
        Money Reduce(Bank bank, string to);
    }
}
