namespace TestAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--MATRICES--");
            int[,] a = Matrices.CreateRandomMatrix(5, 7);
            Matrices.PrintMatrix(a);
            Console.WriteLine(Matrices.FindTraceOfMatrix(a));
            Console.WriteLine(Matrices.SumOfNumbersDivisibleByThree(a));

            Console.WriteLine("\n--RECURSIVE--");
            Console.WriteLine(RecursiveAlgorithms.FindFibonacciByPosition(10));
            Console.WriteLine(RecursiveAlgorithms.Power(9.51, 10));

            Console.WriteLine("\n--HASH--");
            var telephoneDirectory = new TelephoneDirectory(100);
            telephoneDirectory.AddContact("Ivanov Ivan Ivanich", "+79061371521");
            telephoneDirectory.AddContact("Semenov Semen Semenich", "+78715219261");
            telephoneDirectory.AddContact("Egorov Egor Egorich", "+797150415263");
            telephoneDirectory.PrintContacts();
            Console.WriteLine();
            telephoneDirectory.DeletePhoneNumber("Ivanov Ivan Ivanich");
            telephoneDirectory.EditPhoneNumber("Semenov Semen Semenich", "+00000000000");
            telephoneDirectory.PrintContacts();
            Console.WriteLine();
            Console.WriteLine(telephoneDirectory.FindPhoneNumber("Egorov Egor Egorich"));

            Console.WriteLine("\n--OOP--");
            var circle = new Circle(2);
            var rect = new Rectangle(4, 6);
            var square = new Square(8);
            var rhombus = new Rhombus(10, 30);
            var rhombusInvalid = new Rhombus(-1, 30);
            Console.WriteLine(rhombusInvalid.IsValid());
        }
    }
}
