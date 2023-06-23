namespace StringSum
{
    public class StringSumKata
    {
        public const string NullArgumentMSG = "Argument Null Exception";
        public const string OverflowExceptionMSG = "Overflow Exception";
        public const string FormatExceptionMSG = "Null Or White Space";

        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter num1");
            string num1 = Console.ReadLine();

            Console.WriteLine("Please, enter num2");
            string num2 = Console.ReadLine();

            Console.WriteLine(Sum(num1, num2));
        }

        public static string Sum(string num1, string num2)
        {
            try
            {
                if (num1 == null || num2 == null)
                {
                    throw new ArgumentNullException(NullArgumentMSG);
                }

                if (num1.Length > 9 || num2.Length > 9)
                {
                    throw new OverflowException(OverflowExceptionMSG);
                }

                if (String.IsNullOrWhiteSpace(num1) || String.IsNullOrWhiteSpace(num2))
                {
                    throw new FormatException(FormatExceptionMSG);
                }
                if (num1.Any(Char.IsLetter) || num2.Any(Char.IsLetter))
                {
                    throw new FormatException(FormatExceptionMSG);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            int firstNum = int.Parse(num1);
            int secondNum = int.Parse(num2);

            for (int i = 2; i < firstNum; i++)
            {
                if (firstNum % i == 0)
                {
                    firstNum = 0;
                }
            }

            for (int i = 2; i < secondNum; i++)
            {
                if (secondNum % i == 0)
                {
                    secondNum = 0;
                }
            }
            return (firstNum + secondNum).ToString();
        }
    }
}