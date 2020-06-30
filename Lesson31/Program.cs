using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса.
*/
namespace Lesson31
{
    struct ComplexStructure
    {
        public double im;
        public double re;
        //  в C# в структурах могут храниться также действия над данными
        public ComplexStructure Plus(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public ComplexStructure Minus(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public ComplexStructure Multi(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public override string ToString()
        {
            return re + (im < 0 ? "-" : "+") + Math.Abs(im) + "i";
        }
    }


    class ComplexClass
    {
        // Поля приватные.
        private double im;
        // По умолчанию элементы приватные, поэтому private можно не писать.
        double re;

        // Конструктор без параметров.
        public ComplexClass()
        {
            im = 0;
            re = 0;
        }

        // Конструктор, в котором задаем поля.    
        // Специально создадим параметр re, совпадающий с именем поля в классе.
        public ComplexClass(double _im, double re)
        {
            // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
            im = _im;
            // Чтобы показать, что к полю нашего класса присваивается параметр,
            // используется ключевое слово this

            // Поле параметр
            this.re = re;
        }
        public ComplexClass Plus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }
        public ComplexClass Minus(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public ComplexClass Multi(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        // Свойства - это механизм доступа к данным класса.
        public double Im
        {
            get { return im; }
            set
            {
                // Для примера ограничимся только положительными числами.
                if (value >= 0) im = value;
            }
        }
        // Специальный метод, который возвращает строковое представление данных.
        public override string ToString()
        {
            return re + (im < 0 ? "-" : "+") + Math.Abs(im) + "i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация вычитания комплексных чисел, представленные в виде структуры:");
            ComplexStructure CompStructX;
            ComplexStructure CompStructY;
            Console.WriteLine("Введите первое комплексное число:");
            Console.Write("Re = "); CompStructX.re = Convert.ToDouble(Console.ReadLine());
            Console.Write("Im = "); CompStructX.im = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе комплексное число:");
            Console.Write("Re = "); CompStructY.re = Convert.ToDouble(Console.ReadLine());
            Console.Write("Im = "); CompStructY.im = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Операция вычитания (первое значение - второе значение): {CompStructX.Minus(CompStructY).ToString()}\n");

            Console.WriteLine("Демонстрация вычитания комплексных чисел, представленные в виде класса:");
            Console.WriteLine("Введите первое комплексное число:");
            Console.Write("Re = "); double reX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Im = "); double imX = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе комплексное число:");
            Console.Write("Re = "); double reY = Convert.ToDouble(Console.ReadLine());
            Console.Write("Im = "); double imY = Convert.ToDouble(Console.ReadLine());
            ComplexClass CompClassX = new ComplexClass(imX, reX);
            ComplexClass CompClassY = new ComplexClass(imY, reY);
            ComplexClass Buffer = new ComplexClass();
            Console.WriteLine("Выберите тип операции (+, -, *), только один символ:");
            switch (Console.ReadLine())
            {
                case "+": Buffer = CompClassX.Plus(CompClassY); break;
                case "-": Buffer = CompClassX.Minus(CompClassY); break;
                case "*": Buffer = CompClassX.Multi(CompClassY); break;
                default: Console.WriteLine("Выбранная операция отсутствует, вычисления невозможны!"); Console.ReadKey(); return;
            }
            Console.WriteLine($"Выполнение операции: {Buffer.ToString()}\n");
            Console.ReadKey();
        }
    }
}
