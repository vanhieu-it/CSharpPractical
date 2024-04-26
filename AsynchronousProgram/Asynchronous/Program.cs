using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the from number first");
            int firstNumberFirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the to number first");
            int toNumberFirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the from number second");
            int firstNumberSecond = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the to number second");
            int toNumberSecond = Convert.ToInt32(Console.ReadLine());

            PrintPrimeNumber(firstNumberFirst, toNumberFirst);
            PrintPrimeNumber(firstNumberSecond, toNumberSecond);
            Console.WriteLine("Main method is completed");
            Console.ReadLine();
        }
        public static async void PrintPrimeNumber(int firstNumber, int lastNumber)
        {
            await Task.Run(() =>
            {
                for (int i = firstNumber; i <= lastNumber; i++)
                {
                    bool isPrime = true;
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        Console.WriteLine(i);
                        Task.Delay(200).Wait();
                    }
                }
            });
        }

    }
}
