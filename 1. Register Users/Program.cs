using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace _1.Register_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var registeredUsernames = new Dictionary<string, DateTime>();

            var inputLines = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            while (inputLines[0] != "end")
            {
                var userName = inputLines[0];
                var registerDate = DateTime.ParseExact(inputLines[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                registeredUsernames[userName] = registerDate;
                
                inputLines = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            }

            var sortedUserNames = registeredUsernames
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in sortedUserNames)
            {
                Console.WriteLine($"{user.Key}");
            }
        }
    }
}
