using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string enteredWord;
            do
            {
                OperationWithString operationWithString = new OperationWithString();

                Console.WriteLine("Please, enter word");
                enteredWord = Console.ReadLine();

                try
                {
                    if (String.IsNullOrWhiteSpace(enteredWord))
                    {
                        throw new InvalidEnterException("Invalid entered value");
                    }
                    else
                    {

                        operationWithString.GetCharacter(enteredWord);
                    }
                }
                catch (InvalidEnterException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (enteredWord != "close");
        }

        public class OperationWithString
        {
            public void GetCharacter(string word)
            {
                string firstCharacter = word.Substring(0, 1);
                Console.WriteLine(firstCharacter);
            }
        }

        class InvalidEnterException : Exception
        {
            public InvalidEnterException(string message)
                : base(message) { }
        }
    }
}