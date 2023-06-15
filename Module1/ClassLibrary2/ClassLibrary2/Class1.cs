using System;

namespace ClassLibrary2
{
    public class AddTime
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
       
        public string ConcatenateString(string greetingMessage)
        {
            string concatTimeMessage = String.Concat(time, greetingMessage);
            return concatTimeMessage;

        }

    }
}
