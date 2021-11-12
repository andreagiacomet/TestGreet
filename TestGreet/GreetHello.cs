using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestGreet
{
    public class GreetHello : IGreetHello
    {
        private static string[] SplitComma(string sign, string[] names)
        {
            var comma = names?.Where(x => x.Contains(sign)).ToArray();
            names = names?.Except(comma).ToArray();
            return names?.Concat(comma.SelectMany(x => x.Split(sign))).ToArray();
        }
        public string Greet(params string[] names)
        {
            if (names is null) return $"Hello, my friend.";
            if (names.Where(x=>x.Contains("\"")).Any())
            {
                var res = names.Where(x => x.Contains("\"")).Select(x => x.Replace("\"", string.Empty)).ToArray();
                res = SplitComma(", ", res).ToArray();
                return string.Concat("Hello, ", string.Join(", ", names.Where(x => x != names.Last())), " and ", string.Join(", ", res), ".");
            }

            names = SplitComma(", ", names);
            if (names.Length == 1) return names[0] == names[0].ToUpper() ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.";
            if (names.Length == 2) return $"Hello, {names[0]} and {names[1]}.";

            string final = string.Empty;
            var upper = names.Where(x => x.All(char.IsUpper)).ToList();

            if (upper.Count > 1)
                final = string.Concat(" AND HELLO ", string.Join(", ", upper.Where(x => x != upper.Last())), " AND ", upper.Last(), "!");
            else if (upper.Count == 1) final = string.Concat(" AND HELLO ", string.Join(", ", upper.Where(x => x != upper.Last())), upper.Last(), "!");

            return string.Concat("Hello, ", string.Join(", ", names.Except(upper).Where(x => x != names.Except(upper).Last())), " and ", names.Except(upper).Last(), ".", final);
        }
    }
}
