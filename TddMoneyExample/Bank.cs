namespace TddMoneyExample
{
    class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            Sum sum = (Sum)source;
            int amount = sum.Augend.Amount + sum.Addend.Amount;
            return new Money(amount, to);
        }
    }
}