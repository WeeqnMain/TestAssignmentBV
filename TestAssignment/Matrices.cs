namespace TestAssignment
{
    public static class Matrices
    {
        public static int[,] CreateMatrixFromConsole()
        {
            int height = 0;
            int width = 0;

            while (true)
            {
                Console.WriteLine("Enter matrix dimensions (width and height space-separated):");
                var dimensionsInput = Console.ReadLine();

                var dimensions = dimensionsInput?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (dimensions?.Length != 2)
                {
                    Console.WriteLine("Enter exactly two numbers");
                    continue;
                }
                if (!int.TryParse(dimensions[0], out height) || !int.TryParse(dimensions[1], out width) || (height <= 0 || width <= 0))
                {
                    Console.WriteLine("Wrong width or height entered");
                    continue;
                }

                break;
            }

            int[,] matrix = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter {width} elements for row {i + 1} (space-separated):");
                    var rowInput = Console.ReadLine();

                    var rowElements = rowInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (rowElements.Length != width)
                    {
                        Console.WriteLine($"Enter exactly {width} number");
                        continue;
                    }

                    for (int j = 0; j < width; j++)
                    {
                        if (int.TryParse(rowElements[j], out int value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            Console.WriteLine($"'{rowElements[j]}' is not a valid integer");
                            continue;
                        }
                    }

                    break;
                }
            }

            return matrix;
        }

        public static int[,] CreateRandomMatrix(int height, int width)
        {
            int[,] matrix = new int[height, width];
            Random random = new();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            Console.WriteLine("\nMatrix:");

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.Write("\n");
            }
        }

        public static int FindTraceOfMatrix(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            int length = Math.Min(height, width);

            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        public static int SumOfNumbersDivisibleByThree(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            int sum = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] % 3 == 0)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
