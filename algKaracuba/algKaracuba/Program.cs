using System;

namespace algKaracuba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = Convert.ToInt32(Console.ReadLine());
            long res = AlgoKaracuba(x, y);
            Console.WriteLine(res);
        }

        static int Len(int n)
        {
            int count = 0;
            while (n>0)
            {
                count++;
                n/=10;
            }
            return count;
        }

        static long AlgoKaracuba(int x, int y)
        {
            int len = Len(x);

            int x1 = (int)(x / Math.Pow(10, len / 2));
            int x2 = (int)(x - x1 * Math.Pow(10, len / 2));

            int y1 = (int)(y / Math.Pow(10, len / 2));
            int y2 = (int)(y - y1 * Math.Pow(10, len / 2));

            int a = x1 * y1;
            int c = x2 * y2;
            int b = (x1 + x2) * (y1 + y2) - a - c;

            return (int)(a * Math.Pow(10, len) + b * Math.Pow(10, len / 2) + c);
        }
    }
}