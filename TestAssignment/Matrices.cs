namespace TestAssignment
{
    public static class Matrices
    {
        public static int[,] CreateRandomMatrix(int width, int height)
        {
            int[,] matrix = new int[width, height];
            Random random = new();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[j, i] = random.Next(1, 10);
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

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
