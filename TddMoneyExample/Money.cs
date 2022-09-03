namespace TddMoneyExample
{
    class Money : IExpression
    {
        private int _amount;
        public string Currency { get; }

        public Money(int amount, string currency)
        {
            _amount = amount;
            Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, Currency);
        }

        public override bool Equals(object? obj)
        {
            Money money = (Money)obj!;
            return _amount == money._amount
                && Currency.Equals(money.Currency);
        }

        public override string ToString()
        {
            return _amount + " " + Currency;
        }

        public IExpression Plus(Money addend)
        {
            return new Money(_amount + addend._amount, Currency);
        }
    }
}
