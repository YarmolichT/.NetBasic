using OddEven3Kata;


namespace OddEvenTest
{
    [TestClass]
    public class UnitTest1
    {
        private OddEven _oddEven = new OddEven();

        [TestMethod]
        [DataRow(4, 3, 7, 9, 12, 15)]
        public void Should_Return_Array_With_Number_Characteristics(params int[] numbers)
        {
            string[] expected = { "Odd", "3", "7", "Even", "Odd", "Even" };

            var result = _oddEven.GetNumberCharacteristics(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Should_Throw_ArgumentNullException()
        {
            int[] numbers = null;

            Assert.ThrowsException<ArgumentNullException>(() => _oddEven.GetNumberCharacteristics(numbers));
        }
    }
}