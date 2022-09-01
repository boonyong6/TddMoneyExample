﻿namespace TddMoneyExample
{
    class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency)
        {
        }

        public override Money Times(int multiplier)
        {
            return Franc(Amount * multiplier);
        }
    }
}