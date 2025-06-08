namespace TestAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatricesTest();
            RecursiveAlgorithmsTest();
            HashTest();
            OOPTest();
        }

        private static void MatricesTest()
        {
            Console.WriteLine("--MATRICES--");

            //int[,] a = Matrices.CreateRandomMatrix(5, 7);
            int[,] a = Matrices.CreateMatrixFromConsole();
            Matrices.PrintMatrix(a);
            Console.WriteLine($"Trace: {Matrices.FindTraceOfMatrix(a)}");
            Console.WriteLine($"Sum of number divisible by 3: {Matrices.SumOfNumbersDivisibleByThree(a)}");
        }

        private static void RecursiveAlgorithmsTest()
        {
            Console.WriteLine("\n--RECURSIVE--");

            int fibonacciPosition;
            while (true)
            {
                Console.Write("Enter position of Fibonacci number: ");
                if (int.TryParse(Console.ReadLine(), out fibonacciPosition))
                {
                    break;
                }
            }
            Console.WriteLine(RecursiveAlgorithms.FindFibonacciByPosition(fibonacciPosition));

            double numberToPower;
            int power;
            while (true)
            {
                Console.Write("Enter number and power: ");
                var input = Console.ReadLine();
                var inputValues = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputValues?.Length != 2)
                {
                    Console.WriteLine("Enter exactly two values");
                    continue;
                }
                if (!double.TryParse(inputValues[0], out numberToPower) || !int.TryParse(inputValues[1], out power))
                {
                    Console.WriteLine("Wrong number or power entered");
                    continue;
                }

                break;
            }
            Console.WriteLine(RecursiveAlgorithms.Power(numberToPower, power));
        }

        private static void HashTest() 
        {
            Console.WriteLine("\n--HASH--");
            var telephoneDirectory = new TelephoneDirectory(100);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add contact");
                Console.WriteLine("2. Delete contact");
                Console.WriteLine("3. Edit phone number");
                Console.WriteLine("4. Find phone number");
                Console.WriteLine("5. Print contacts");
                Console.WriteLine("6. Exit");

                Console.Write("Select an option: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter full name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phone = Console.ReadLine();
                        telephoneDirectory.AddContact(name, phone);
                        Console.WriteLine("Contact added.");
                        break;

                    case 2:
                        Console.Write("Enter full name to delete: ");
                        string nameToDelete = Console.ReadLine();
                        telephoneDirectory.DeleteContact(nameToDelete);
                        Console.WriteLine("Contact deleted (if it existed).");
                        break;

                    case 3:
                        Console.Write("Enter full name to edit: ");
                        string nameToEdit = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        string newPhone = Console.ReadLine();
                        telephoneDirectory.EditPhoneNumber(nameToEdit, newPhone);
                        Console.WriteLine("Phone number updated (if contact existed).");
                        break;

                    case 4:
                        Console.Write("Enter full name to search: ");
                        string nameToFind = Console.ReadLine();
                        string foundPhone = telephoneDirectory.FindPhoneNumber(nameToFind);
                        if (string.IsNullOrEmpty(foundPhone))
                            Console.WriteLine("Contact not found.");
                        else
                            Console.WriteLine($"Found phone number: {foundPhone}");
                        break;

                    case 5:
                        telephoneDirectory.PrintContacts();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
        
        private static void OOPTest() 
        {
            Console.WriteLine("\n--OOP--");

            int choice;
            Figure figure;
            while (true)
            {
                Console.WriteLine("\nSelect a figure:");
                Console.WriteLine("1. Square");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Circle");
                Console.WriteLine("4. Rhombus");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the side length of the square: ");
                            double side = double.Parse(Console.ReadLine());
                            figure = new Square(side);
                            break;
                        case 2:
                            Console.Write("Enter the first side length of the rectangle: ");
                            double side1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter the second side length of the rectangle: ");
                            double side2 = double.Parse(Console.ReadLine());
                            figure = new Rectangle(side1, side2);
                            break;
                        case 3:
                            Console.Write("Enter the radius of the circle: ");
                            double radius = double.Parse(Console.ReadLine());
                            figure = new Circle(radius);
                            break;
                        case 4:
                            Console.Write("Enter the side length of the rhombus: ");
                            double rhombusSide = double.Parse(Console.ReadLine());
                            Console.Write("Enter the angle of the rhombus in degrees: ");
                            double angle = double.Parse(Console.ReadLine());
                            figure = new Rhombus(rhombusSide, angle);
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Try again");
                            continue;
                    }

                    Console.WriteLine($"Perimeter: {figure.GetPerimeter()}");
                    Console.WriteLine($"Area: {figure.GetArea()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
