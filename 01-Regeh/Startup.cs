using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Startup
    {
        static void Main()
        {
            string pattern = @"\[[^\s\[]+<([0-9]+)REGEH([0-9]+)>[^\s\]]+\]";
            Regex regex = new Regex(pattern);
            StringBuilder result = new StringBuilder();
            int index = 0;
            int currentIndex = 0;

            string input = Console.ReadLine();
            var matches = regex.Matches(input);


            foreach (Match match in matches)
            {
                index += int.Parse(match.Groups[1].ToString());

                currentIndex = index < input.Length ? index : (index - input.Length) % (input.Length - 1) + 1;

                result.Append(input[currentIndex]);

                index += int.Parse(match.Groups[2].ToString());
                currentIndex = index < input.Length ? index : (index - input.Length) % (input.Length - 1) + 1;
                result.Append(input[currentIndex]);
            }

            Console.WriteLine(result);
        }
    }
}