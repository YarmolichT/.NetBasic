namespace OddEven3Kata
{
    public class OddEven
    {
        static void Main(string[] args)
        {
            OddEven oddEven = new OddEven();
            int[] numbers = { 4, 3, 7, 9, 12, 15 };
            var result = oddEven.GetNumberCharacteristics(numbers);

            Console.WriteLine("[{0}]", string.Join(", ", result));
        }

        public string[] GetNumberCharacteristics(int[] range)
        {
            if (range == null)
            {
                throw new ArgumentNullException("Range was empty");
            }

            string[] result = new string[range.Length];
            bool isPrime;

            for (int i = 0; i < range.Length; i++)
            {
                isPrime = true;
                if (range[i] % 2 != 0)
                {
                    result[i] = "Even";
                }
                if (range[i] % 2 == 0)
                {
                    result[i] = "Odd";
                }

                for (int index = 2; index < range[i]; index++)
                {
                    if (range[i] % index == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result[i] = range[i].ToString();
                }
            }
            return result;
        }
    }
}