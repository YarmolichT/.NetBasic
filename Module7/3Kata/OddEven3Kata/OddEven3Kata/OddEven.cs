using System;
using System.Reflection;

namespace OddEven3Kata
{
    public class OddEven
    {
        static void Main(string[] args)
        {
            OddEven oddEven= new OddEven();
            int[] s = { 68, 9, 15, 92, 11 };
            var res = oddEven.GetNumberCharacteristics(s);
           
            Console.WriteLine("[{0}]", string.Join(", ", res));
        }

        public string[] GetNumberCharacteristics(int[] range) 
        {
            string[] result = new string[range.Length];

            for (int i = 0; i < range.Length; i++)
            {
                if (range[i] % 2 == 0)
                {
                    result[i] = "Odd";
                }
            }
             return result;
        
        }
    }
}