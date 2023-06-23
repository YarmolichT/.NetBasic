using StringSum;

namespace StringSumTest
{
    [TestClass]
    public class StringSumTest
    {
        [TestMethod]
        [DataRow("1", null)]
        public void Should_Throw_ArgumentNullException(string num1, string num2)
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringSumKata.Sum(num1, num2));
        }

        [TestMethod]
        [DataRow("1", "792281625142")]
        public void Should_Throw_OverflowException(string num1, string num2)
        {
            Assert.ThrowsException<OverflowException>(() => StringSumKata.Sum(num1, num2));
        }

        [TestMethod]
        [DataRow("1", "  ")]
        [DataRow("1", "A")]
        public void Should_Throw_FormatException(string num1, string num2)
        {
            Assert.ThrowsException<FormatException>(() => StringSumKata.Sum(num1, num2));
        }

        [TestMethod]
        public void Should_Return_Sum_Of_Natural_Numbers()
        {
            string num1 = "1";
            string num2 = "7";
            string expected = "8";

            string SumOfString = StringSumKata.Sum(num1, num2);

            Assert.AreEqual(expected, SumOfString);
        }

        [TestMethod]
        [DataRow("1", "4", "1")]
        [DataRow("8", "4", "0")]
        public void Should_Return_Sum_If_One_Of_Arg_Is_Not_Natural(string num1, string num2, string expected)
        {
            string SumOfString = StringSumKata.Sum(num1, num2);

            Assert.AreEqual(expected, SumOfString);
        }
    }
}