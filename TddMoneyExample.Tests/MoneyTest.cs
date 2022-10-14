namespace TddMoneyExample.Tests
{
    public class MoneyTest
    {
        /*
         * This test depends on / coupled with the Dollar.Equals function.
         * If the Dollar.Equals function fails, this test will fail as well.
         * And this is the risk we are taking to decouple the tests and the code.
        */
        [Fact]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void TestSimpleAddition()
        {
            Money five = Money.Dollar(5);
            IExpression sum = five.Plus(five);
            Bank bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(10), reduced);
        }

        // Short-lived test (Test shouldn't be concerned with the implementation)
        [Fact]
        public void TestPlusReturnsSum()
        {
            Money five = Money.Dollar(5);
            IExpression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void TestReduceSum()
        {
            IExpression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7), result);
        }

        [Fact]
        public void TestReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(Money.Franc(2), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestIdenticalRate()
        {
            Assert.Equal(1, new Bank().GetRate("USD", "USD"));
        }

        [Fact]
        public void TestMixedAddition()
        {
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);

            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");

            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);

            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            IExpression sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            Money result = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(15), result);
        }

        [Fact]
        public void TestSumTimes()
        {
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);

            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            IExpression sum = new Sum(fiveBucks, tenFrancs).Times(2);
            Money result = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(20), result);
        }
    }
}