namespace CalcStatsKata
{
    public class CalcStats
    {
        static void Main(string[] args)
        {
            int[] s = { 68, 9, 15, 92, 11 };

            CalcStats calc = new CalcStats();

            var actual = calc.GetAverage(s);

            Console.WriteLine(actual);
        }

        public int GetMinValue(int[] sequenceNum)
        {
            var minNumber = sequenceNum[0];

            foreach (var number in sequenceNum)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            return minNumber;
        }

        public int GetMaxValue(int[] sequenceNum)
        {
            var maxNumber = sequenceNum[0];

            foreach (var number in sequenceNum)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
            return maxNumber;
        }

        public int GetCount(int[] sequenceNum)
        {
            return sequenceNum.Length;
        }

        public int GetAverage(int[] sequenceNum)
        {
            var sum = 0;
            int averageValue;
            foreach (var number in sequenceNum)
            {
                sum += number;
            }
            averageValue = sum / sequenceNum.Length;
            return averageValue;
        }
    }
}