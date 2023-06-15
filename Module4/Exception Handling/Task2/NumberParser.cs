using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public const string EmptyValue = "Entered value can not be empty";
        public const string InncorrectFormatValue = "Inncorrect type of entered value";
        public const string ValueOverflowed = "Value exceeded";
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException(EmptyValue);

            if (string.IsNullOrWhiteSpace(stringValue))
                throw new FormatException(InncorrectFormatValue);

            long result = 0;
            int sighn = 1;

            for (int i = 0; i < stringValue.Length; i++)
            {
                char c = stringValue[i];
                stringValue = stringValue.Trim();
                
                if (c >= '0' && c <= '9')
                {
                    result = result * 10 + (c - '0');
                }
                else if (c == '-' && i == 0)
                {
                    sighn = -1;
                }
                else if (c == '+' && i == 0)
                {
                    sighn = +1;
                }
                else
                {
                    throw new FormatException(InncorrectFormatValue);
                }
            }
            
            result = result * sighn;

            if (result == int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (result == int.MinValue)
            {   
                return int.MinValue; 
            }

            if (result > int.MaxValue || result < int.MinValue)
            {
                throw new OverflowException(ValueOverflowed);
            }

            int lengthMaxValue = int.MaxValue.ToString().Length;

            if (stringValue.Length > lengthMaxValue)
            {
                throw new OverflowException(ValueOverflowed);
            }

            return (int)result ;

        }
    }
}
