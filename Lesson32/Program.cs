using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson32
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Number = new List<int>();
            Console.WriteLine("Введите массив (при окончании ввода наберите '0')");
            do
            {
                int InputItem = 0;
                if(Int32.TryParse(Console.ReadLine(), out InputItem)) Number.Add(InputItem);
                if (Number.Count != 0 && Number.ElementAt(Number.Count - 1) == 0) break;
            } while (true);
            int Sum = 0;
            foreach (int Item in Number)
            {
                int Value = (Item);
                if (Value % 2 != 0 && Value > 0)
                {
                    Sum += Value;
                }
            }
            string InputSum = Sum.ToString();
            Console.WriteLine($"Сумма положительных нечетных значений равна: {(Int32.TryParse(InputSum, out Sum) ? Sum : 0)}");//вывод через tryParse
            Console.ReadKey();
        }
    }
}
