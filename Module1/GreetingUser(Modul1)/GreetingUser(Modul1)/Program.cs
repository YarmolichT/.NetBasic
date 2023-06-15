using ClassLibrary2;

namespace GreetingUser_Modul1_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //First Task
            /*  Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Hello, {name}!");
            
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);*/

            //Second Task

            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            var greetingMessage = ($" Hello, {name}!");

            AddTime addTime = new AddTime(greetingMessage);
            string timeGreeting =  addTime.ConcatenateString();

            Console.WriteLine($"{timeGreeting}");


            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true); 

        }
    }
}