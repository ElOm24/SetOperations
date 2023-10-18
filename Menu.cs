using as1;
using System;

namespace ConsoleApp1
{
    internal class Menu
    {
        private Set set;
        public Menu() {
            set = new Set();
        }
           
        public int IntegerInput()
        {
            int number = 0;
            bool validNumber = false;
            while (!validNumber)
            {
                try
                {
                    number = int.Parse(Console.ReadLine()!);
                    validNumber = true;
                }
                catch
                {
                    Console.WriteLine("Only integer number is accepted.");
                    Console.Write("Try again: ");
                }
            }
            return number;
        }

        public void Run()
        {
            int option = -1;
            do
            {
                Console.WriteLine("1. Insert element");
                Console.WriteLine("2. Remove element");
                Console.WriteLine("3. Set is empty?");
                Console.WriteLine("4. Set contains element?");
                Console.WriteLine("5. Get Random element");
                Console.WriteLine("6. Get Largest element");
                Console.WriteLine("7. Print the Set");
                Console.WriteLine("0. Exit from menu");

                Console.Write("Select: ");
                option = IntegerInput();

                int number;
                string answer;
                switch (option)
                {
                    case 1:
                        Console.Write("Enter the number: ");
                        number = IntegerInput();
                        try
                        {
                            set.Insert(number);
                        }
                        catch (ElementExistsException e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        break;
                    case 2:
                        Console.Write("Enter the number: ");
                        number = IntegerInput();
                        try
                        {
                            set.Remove(number);
                        }
                        catch (ElementDoesNotExistsException e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        break;
                    case 3:
                        answer = (set.IsEmpty() ? "Yes" : "No");
                        Console.WriteLine(answer);
                        break;
                    case 4:
                        Console.Write("Enter the number: ");
                        number = IntegerInput();
                        answer = (set.Contains(number) ? "Yes" : "No");
                        Console.WriteLine(answer);
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Random element: " + set.Random());
                        }
                        catch (EmptySetException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("Largest element: " + set.Largest());
                        }
                        catch (EmptySetException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 7:
                        set.Print();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Selected option is not available. Use one of the above!");
                        break;
                }

            } while (option != 0);
        }

    }
}
