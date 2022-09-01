namespace TddMoneyExample
{
    abstract class Money
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

        public abstract Money Times(int multiplier);

        public virtual string GetCurrency()
        {
            return Currency;
        }

        public override bool Equals(object? obj)
        {
            Money money = (Money)obj!;
            return Amount == money.Amount
                && GetType().Equals(money.GetType());
        }
    }
}
