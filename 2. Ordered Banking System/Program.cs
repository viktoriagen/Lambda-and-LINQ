using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Ordered_Banking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankInfo = new Dictionary<string, Dictionary<string, decimal>>();
            var inputInfo = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            while (inputInfo[0] != "end")
            {
                var bankName = inputInfo[0];
                var bankAccName = inputInfo[1];
                var bankBalance = decimal.Parse (inputInfo[2]);

                if (!bankInfo.ContainsKey(bankName))
                {
                    bankInfo[bankName] = new Dictionary<string, decimal>();
                }
                    
                if (!bankInfo[bankName].ContainsKey(bankAccName))
                {
                    bankInfo[bankName].Add(bankAccName, 0);
                }
                bankInfo[bankName][bankAccName] += bankBalance;
                            
                inputInfo = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            }

            bankInfo
               .OrderByDescending(bank => bank.Value.Sum(account => account.Value))
               .ThenByDescending(bank => bank.Value.Max(account => account.Value))
               .ToList()
               .ForEach(bank => bank.Value
                 .OrderByDescending(account => account.Value)
                 .ToList()
                 .ForEach(account => Console.WriteLine("{0} -> {1} ({2})",
                 account.Key,
                 account.Value,
                 bank.Key)
                 ));

        }
    }
}
