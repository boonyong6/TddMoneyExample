namespace TddMoneyExample.Tests
{
    public class MoneyTest
    {
        [Fact]
        /*
         * This test depends on / couples to the Dollar.Equals function.
         * If the Dollar.Equals function fails, this test will fail as well.
         * And this is the risk we are taking to decouple the tests and the code.
        */
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Assert.Equal(new Dollar(10), five.Times(2));
            Assert.Equal(new Dollar(15), five.Times(3));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            Franc five = new Franc(5);
            Assert.Equal(new Franc(10), five.Times(2));
            Assert.Equal(new Franc(15), five.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));
            Assert.False(new Dollar(5).Equals(new Dollar(6)));
        }
    }
}