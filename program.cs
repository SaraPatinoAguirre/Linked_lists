using System;

class Program
{
    static void Main(string[] args)
    {
        // Puedes cambiar <string> por <int> si prefieres probar con números
        DoubleList<string> myList = new DoubleList<string>();
        int option = -1;

        while (option != 0)
        {
            Console.WriteLine("\n--- DOUBLE LINKED LIST MENU ---");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. Show forward");
            Console.WriteLine("3. Show backward");
            Console.WriteLine("4. Order descendent");
            Console.WriteLine("5. Show mode(s)");
            Console.WriteLine("6. Show graph");
            Console.WriteLine("7. Check if exists");
            Console.WriteLine("8. Delete one occurrence");
            Console.WriteLine("9. Delete all occurrences");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            int.TryParse(Console.ReadLine(), out option);
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    Console.Write("Enter value to add: ");
                    string valToAdd = Console.ReadLine();
                    myList.Add(valToAdd);
                    Console.WriteLine("Added!");
                    break;

                case 2:
                    Console.Write("Forward list: ");
                    myList.ShowForward();
                    break;

                case 3:
                    Console.Write("Backward list: ");
                    myList.ShowBackward();
                    break;

                case 4:
                    myList.ToDescendentOrder();
                    Console.WriteLine("List reordered to descendent!");
                    break;

                case 5:
                    myList.ShowModes();
                    break;

                case 6:
                    myList.ShowGraph();
                    break;

                case 7:
                    Console.Write("Enter value to search: ");
                    string valToSearch = Console.ReadLine();
                    if (myList.Exists(valToSearch))
                        Console.WriteLine("Yes, it exists!");
                    else
                        Console.WriteLine("No, it does not exist.");
                    break;

                case 8:
                    Console.Write("Enter value to delete once: ");
                    string valToDelOne = Console.ReadLine();
                    if (myList.DeleteOne(valToDelOne))
                        Console.WriteLine("One occurrence deleted.");
                    else
                        Console.WriteLine("Value not found.");
                    break;

                case 9:
                    Console.Write("Enter value to delete all: ");
                    string valToDelAll = Console.ReadLine();
                    myList.DeleteAll(valToDelAll);
                    Console.WriteLine("All occurrences deleted (if any).");
                    break;

                case 0:
                    Console.WriteLine("Bye bye");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}