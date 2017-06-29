using System;
namespace LyndaConsoleApp
{
    public class InvalidOperatorException: Exception
    {
        public InvalidOperatorException(string message): base(message)
        {
        }
    }
}
