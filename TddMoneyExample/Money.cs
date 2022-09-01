namespace TddMoneyExample
{
    abstract class Money
    {
        protected int Amount;

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }

        public abstract Money Times(int multiplier);

        public override bool Equals(object? obj)
        {
            Money money = (Money)obj!;
            return Amount == money.Amount
                && GetType().Equals(money.GetType());
        }
    }
}
