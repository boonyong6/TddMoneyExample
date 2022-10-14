namespace TddMoneyExample
{
    class Bank
    {
        private readonly Dictionary<(string, string), int> _rates = new Dictionary<(string, string), int>();

        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string currencyFrom, string currencyTo, int rate)
        {
            _rates.Add((currencyFrom, currencyTo), rate);
        }

        public int GetRate(string from, string to)
        {
            if (from.Equals(to))
            {
                return 1;
            }

            _rates.TryGetValue((from, to), out int rate);
            return rate;
        }
    }
}