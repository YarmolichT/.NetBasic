using CalcStatsKata;

namespace CalcStatsTests
{
    [TestClass]
    public class CalcStatsTest
    {
        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Min_Value(params int[] sequenceNum)
        {
            CalcStats calc = new CalcStats();
            int expected = -10;

            var minValue = calc.GetMinValue(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }
        
        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Max_Value(params int[] sequenceNum)
        {
            CalcStats calc = new CalcStats();
            int expected = 92;

            var minValue = calc.GetMaxValue(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }

        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Number_Of_Elements(params int[] sequenceNum)
        {
            CalcStats calc = new CalcStats();
            int expected = 6;

            var minValue = calc.GetCount(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }

        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Average_Of_Elemetns(params int[] sequenceNum)
        {
            CalcStats calc = new CalcStats();
            var expected = 30;

            var minValue = calc.GetAverage(sequenceNum);

            Assert.AreEqual(  minValue, expected);
        }
    }
}