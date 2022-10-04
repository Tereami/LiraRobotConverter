using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraRobotConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = "1*1.35+2*1.35+5*1.5";
            Console.WriteLine("Введите исходную строку");
            string input = Console.ReadLine();

            SortedDictionary<int, decimal> values =  new SortedDictionary<int, decimal>();
            for(int i = 1; i <= 10; i++)
            {
                values.Add(i, 0);
            }

            string[] arr = input.Split('+');
            for(int i = 0; i < arr.Length; i++)
            {
                string s = arr[i];
                if (!s.Contains("*"))
                    continue;
                string[] pair = s.Split('*');
                int coeff = int.Parse(pair[0]);

                string valstring = pair[1];
                valstring = valstring.Replace(".", ",");
                decimal val = decimal.Parse(valstring);

                if (!values.ContainsKey(coeff))
                    throw new Exception($"В строке {input} неверный коэффициент {coeff}");
                values[coeff] = val;
            }

            List<string> pairs = new List<string>();

            foreach(KeyValuePair<int, decimal> pair in values)
            {
                string key = pair.Key.ToString();
                string val = pair.Value.ToString().Replace(",", ".");
                pairs.Add($"{key}*{val}");
            }
            string output = string.Join("+", pairs);

            Console.WriteLine("Результат обработки:");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
