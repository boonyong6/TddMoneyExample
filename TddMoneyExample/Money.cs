namespace TddMoneyExample
{
    class Money
    {
        protected int Amount;
        protected string Currency;

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public virtual Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public virtual string GetCurrency()
        {
            return Currency;
        }

        public override bool Equals(object? obj)
        {
            Money money = (Money)obj!;
            return Amount == money.Amount
                && Currency.Equals(money.Currency);
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}
