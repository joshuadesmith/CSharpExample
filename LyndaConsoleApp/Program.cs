using System;

namespace LyndaConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Boolean run = true;
            while (run)
            {
                Console.Write("Please select functionality:\n" +
                                  "(0) Exit\n" +
                                  "(1) Calculator\n");
                string resp = Console.ReadLine();

                switch (resp)
                {
                    case "0":
                        run = false;
                        break;
                        
                    case "1":
                        Calculator calc = new Calculator();
                        calc.Run();
                        calc.ListHistory();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}
