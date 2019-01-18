using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static int _increment;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string text_in = Console.ReadLine();
			
            Console.WriteLine("Введите инкремент:");
            if(int.TryParse(Console.ReadLine(), out _increment))
            {
                if (text_in != null)
                {
                    var result = Regex.Replace(text_in, @"\d+", Replacer, RegexOptions.Multiline);
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
            }
            Console.ReadKey();
        }

        private static string Replacer(Match match)
        {
            int number = Convert.ToInt32(match.Value);
            int count = number.ToString().Length;
            int sum = number + _increment;
            int startIndex = sum.ToString().Length - count;
            string result = sum.ToString().Substring(startIndex, count);
            return result;
        }
    }
}