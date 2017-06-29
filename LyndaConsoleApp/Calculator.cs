using System;
using System.Collections.Generic;
namespace LyndaConsoleApp
{
    public class Calculator
    {
        List<KeyValuePair<string, int>> History;

        public Calculator()
        {
            History = new List<KeyValuePair<string, int>>();
        }

        public void Run() 
        {
            Console.Clear();
            Console.WriteLine("Welcome to the calculator (it's basic as shit):");

			Boolean run = true;
			while (run)
			{
				String command = Console.ReadLine();
				String[] tokens = command.Split(' ');

				if (tokens.Length != 3)
				{
                    if (command.ToLower().Equals("quit") ||
                        command.ToLower().Equals("q")) run = false;

                    else if (command.ToLower().Equals("history") ||
                             command.ToLower().Equals("hist") ||
                             command.ToLower().Equals("h")) ListHistory();

                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Invalid Command: {command}");
                    }
				}
				else
				{
                    int x, y;

                    if (!Int32.TryParse(tokens[0], out x))
                    {
                        if (tokens[0].Equals("result"))
                        {
                            if (History.Count > 0)
                            {
                                x = History[History.Count - 1].Value;
                                tokens[0] = x.ToString();
                            }
                            else
                            {
                                Console.WriteLine("Invalid use of \"result\"");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Operand");
                        }
                    }

                    if (!Int32.TryParse(tokens[2], out y))
                    {
                        if (tokens[2].Equals("result"))
                        {
                            if (History.Count > 0)
                            {
                                y = History[History.Count - 1].Value;
                                tokens[2] = y.ToString();
                            }
                            else
                            {
                                Console.WriteLine("Invalid use of \"result\"");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Operand");
                        }
                    }
                    
					int result = 0;

					try
					{
                        result = Calculate(x, y, tokens[1]);
					}
					catch (InvalidOperatorException e)
					{
						Console.WriteLine($"InvalidOperandException: {e.Message}");
						continue;
					}

                    Console.Clear();
					Console.WriteLine($"{String.Join(" ", tokens)} = {result}\n");
                    History.Add(new KeyValuePair<string, int>(command, result));
				}
			}
        }

		int Calculate(int x, int y, String op)
		{
			int result = 0;
			switch (op)
			{
				case "+":
					result = x + y;
					break;

				case "-":
					result = x - y;
					break;

				case "*":
					result = x * y;
					break;

				case "/":
					result = x / y;
					break;

				default:
					throw new InvalidOperatorException($"\"{op}\" is not a valid operator.");
			}

			return result;
		}

        // Lists the calculator's history
        public void ListHistory() 
        {
            Console.Clear();
            Console.WriteLine("Calculation History:");
            foreach(KeyValuePair<string, int> kvp in History)
            {
                Console.WriteLine($"[{History.IndexOf(kvp)}]: {kvp.Key} = {kvp.Value}");
            }
        }
    }
}
