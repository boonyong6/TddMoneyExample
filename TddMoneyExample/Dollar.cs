namespace TddMoneyExample
{
    class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency)
        {
        }

        public override Money Times(int multiplier)
        {
            return Dollar(Amount * multiplier);
        }
    }
}