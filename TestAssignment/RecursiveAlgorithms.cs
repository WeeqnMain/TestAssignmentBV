namespace TestAssignment
{
    public static class RecursiveAlgorithms
    {
        public static int FindFibonacciByPosition(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;

            int n1 = 0;
            int n2 = 1;
            int temp;

            for (int i = 3; i <= n; i++)
            {
                temp = n1 + n2;
                n1 = n2;
                n2 = temp;
            }

            return n2;
        }

        public static double Power(double n, int power)
        {
            if (power == 0) return 1;
            if (power < 0) 
                return 1 / Power(n, -power);

            double result = 1;
            for (int i = 0; i < power; i++)
                result *= n;

            return result;
        }
    }
}
