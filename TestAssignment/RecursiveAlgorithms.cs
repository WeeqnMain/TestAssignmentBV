namespace TestAssignment
{
    public static class RecursiveAlgorithms
    {
        public static int FindFibonacciByPosition(int n)
        {
            if (n <= 1) return n;

            return FindFibonacciByPosition(n - 1) + FindFibonacciByPosition(n - 2);
        }

        public static double Power(double number, int power)
        {
            if (power == 0)
                return 1;
            if (power < 0)
                return 1 / Power(number, -power);
            return number * Power(number, power - 1);
        }
    }
}
