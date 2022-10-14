﻿namespace TddMoneyExample
{
    class Sum : IExpression
    {
        public Money Augend { get; }
        public Money Addend { get; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
    }
}