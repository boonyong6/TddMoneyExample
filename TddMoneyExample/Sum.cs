namespace TddMoneyExample
{
    class Sum : IExpression
    {
        public IExpression Augend { get; }
        public IExpression Addend { get; }

        public Sum(IExpression augend, IExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public IExpression Plus(IExpression addend)
        {
            return null;
        }
    }
}
