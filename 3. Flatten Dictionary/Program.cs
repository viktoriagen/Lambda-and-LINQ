using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Flatten_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, string>>();

            var input = Console.ReadLine().Split(' ');
            while (input[0] != "end")
            {
                if (input[0] != "flatten")
                {
                    var key = input[0];
                    var innerKey = input[1];
                    var innerValue = input[2];

                    if (!result.ContainsKey(key))
                    {
                        result[key] = new Dictionary<string, string>();
                    }
                    result[key][innerKey] = innerValue;
                 
                }
                else
                {
                    var key = input[1];
                    result[key] = result[key]
                        .ToDictionary(x => x.Key + x.Value, x => "flatten");

                }
                input = Console.ReadLine().Split(' ');
            }

            var orderedDictionary = result
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var entry in orderedDictionary)
            {
                Console.WriteLine($"{entry.Key}");

                var orderedInnerDictionary = entry.Value
                    .Where(x => x.Value != "flatten")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);
                var flattenDictinary = entry.Value
                    .Where(x => x.Value == "flatten")
                    .ToDictionary(x => x.Key, x => x.Value);

                var count = 1;
                foreach (var innerEntry in orderedInnerDictionary)
                {
                    
                    Console.WriteLine($"{count++}. {innerEntry.Key} - {innerEntry.Value}");
                }
                foreach (var flattenEntry in flattenDictinary)
                {
                    Console.WriteLine($"{count++}. {flattenEntry.Key}");
                }
            }
        }
    }
}
