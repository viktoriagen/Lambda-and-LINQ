using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var k = numbers.Length / 4;

            var firstPartUpperRow = numbers
                .Take(k)
                .Reverse()
                .ToArray();

            var secondPartUpper = numbers
                .Reverse()
                .Take(k);

            var upper = firstPartUpperRow
                .Concat(secondPartUpper)
                .ToArray();

            var lowerRow = numbers
                .Skip(k)
                .Take(2 * k)
                .ToArray();

            var result = new int[upper.Length];

            for (int i = 0; i < upper.Length; i++)
            {
                result[i] = upper[i] + lowerRow[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
