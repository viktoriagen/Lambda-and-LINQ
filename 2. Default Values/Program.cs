using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Default_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictonary = new Dictionary<string, string>();
            var input = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "end")
            {
                var key = input[0];
                var value = input[1];

                dictonary[key] = value;

                input = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            }
            var defaultValue = Console.ReadLine();

            var unchanged = dictonary
                .Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);
            var changed = dictonary
                .Where(x => x.Value == "null")
                .ToDictionary(x => x.Key, x => defaultValue);

            foreach (var entry in unchanged)
            {
                Console.WriteLine($"{entry.Key} <-> {entry.Value}");
            }
            foreach (var entry in changed)
            {
                Console.WriteLine($"{entry.Key} <-> {entry.Value}");
            }
        }
    }
}
