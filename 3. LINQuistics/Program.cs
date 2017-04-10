using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LINQuistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var linqCollection = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine().Split(new[] { "()", "." }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "exit")
            {
                if (input.Length > 1)
                {
                    var collectionName = input[0];
                    if (!linqCollection.ContainsKey(collectionName))
                    {
                        linqCollection[collectionName] = new HashSet<string>();
                    }
                    for (int i = 1; i < input.Length; i++)
                    {
                        linqCollection[collectionName].Add(input[i]);
                    }

                }
                else
                {
                    var collectionName = input[0];
                    if (linqCollection.ContainsKey(collectionName))
                    {
                        linqCollection[collectionName]
                             .OrderByDescending(method => method.Length)
                             .ThenByDescending(method => method.Distinct().Count())
                             .ToList()
                             .ForEach(method => Console.WriteLine($"* {method}"));
                    }
                       

                }

                input = Console.ReadLine().Split(new[] { "()", "." }, StringSplitOptions.RemoveEmptyEntries);

            }
            var selectionMethod = Console.ReadLine().Split(' ');
            var methodToCheck = selectionMethod[0];
            var selection = selectionMethod[1];
            switch (selection)
            {
                case "all":
                    linqCollection
                         .ToDictionary(x => x.Key, y => y.Value)
                         .Where(y => y.Value.Contains(methodToCheck))
                         .OrderByDescending(x => x.Value.Count)
                         .ThenByDescending(x => x.Value.OrderBy(z => z.Length).FirstOrDefault().Length)
                         .ToList()
                         .ForEach(x => Console.WriteLine($"{x.Key}"));

                    break;
                case "collection":
                                        linqCollection
                        .Where(collection => collection.Value.Contains(methodToCheck))
                        .ToList()
                        .ForEach(collection => collection.Value
                        .OrderByDescending(method => collection.Value.Count)
                        .ThenByDescending(method => collection.Value.OrderBy(z => z.Length).FirstOrDefault().Length)
                        .ToList()
                        .ForEach(method => Console.WriteLine($"{collection}/r/n* {collection.Value}")
                        ));


                    break;
            }
        }
    }
}
