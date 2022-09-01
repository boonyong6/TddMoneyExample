namespace TddMoneyExample
{
    class Money
    {
        protected int Amount;

        public override bool Equals(object? obj)
        {
            Money money = (Money)obj!;
            return Amount == money.Amount
                && GetType().Equals(money.GetType());
        }
    }
}
