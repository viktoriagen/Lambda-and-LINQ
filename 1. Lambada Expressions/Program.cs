using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Lambada_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, string>>();
            var input = Console.ReadLine().Split(new[] { " => ", "." }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "lambada")
            {
                if (input[0] != "dance")
                {
                    var selector = input[0];
                    var selectorObject = input[1];
                    var property = input[2];


                    if (!result.ContainsKey(input[0]))
                        result[input[0]] = new Dictionary<string, string>();
                    result[selector][selectorObject] = property;
                }
                else
                {
                    result = result
                        .ToDictionary(selector => selector.Key, x => x.Value.ToDictionary(
                            selectorObject => selectorObject.Key, selectorObject => selectorObject.Key + "." + selectorObject.Value));
                }
                
                input = Console.ReadLine().Split(new[] { " => ", "." }, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var selector in result)
            {
                foreach (var selectorObject in selector.Value)
                {
                    Console.WriteLine("{0} => {1}.{2}", selector.Key, selectorObject.Key, selectorObject.Value);
                }
            }
        }
    }
}
