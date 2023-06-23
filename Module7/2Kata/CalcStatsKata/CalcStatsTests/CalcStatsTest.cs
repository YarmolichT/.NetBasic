using CalcStatsKata;

namespace CalcStatsTests
{
    [TestClass]
    public class CalcStatsTest
    {
        private CalcStats _calc = new CalcStats();

        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Min_Value(params int[] sequenceNum)
        {
            int expected = -10;
            var minValue = _calc.GetMinValue(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }
        
        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Max_Value(params int[] sequenceNum)
        {
            int expected = 92;
            var minValue = _calc.GetMaxValue(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }

        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Number_Of_Elements(params int[] sequenceNum)
        {
            int expected = 6;
            var minValue = _calc.GetCount(sequenceNum);

            Assert.AreEqual(minValue, expected);
        }

        [TestMethod]
        [DataRow(68, 9, 15, 92, 11, -10)]
        public void Should_Return_Average_Of_Elemetns(params int[] sequenceNum)
        {
            var expected = 30;
            var minValue = _calc.GetAverage(sequenceNum);

            Assert.AreEqual(  minValue, expected);
        }
    }
}