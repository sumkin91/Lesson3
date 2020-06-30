using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson33
{
    class Fraction
    {
        int numerator = 0;
        int denominator = 0;
        public Fraction(int _numerator, int _denominator)
        {
            numerator = _numerator;
            denominator = _denominator;
        }
        public Fraction()
        {

        }
        public Fraction Plus(Fraction a)
        {
            Fraction output = new Fraction();
            output.denominator = denominator * a.denominator;
            output.numerator = numerator * a.denominator + a.numerator * denominator;
            return output;
        }
        public Fraction Minus(Fraction a)
        {
            Fraction output = new Fraction();
            output.denominator = denominator * a.denominator;
            output.numerator = numerator * a.denominator - a.numerator * denominator;
            return output;
        }
        public Fraction Multi(Fraction a)
        {
            Fraction output = new Fraction();
            output.denominator = denominator * a.denominator;
            output.numerator = numerator * a.numerator;
            return output;
        }
        public Fraction Divide(Fraction a)
        {
            Fraction output = new Fraction();
            output.denominator = a.numerator * denominator;
            output.numerator = numerator * a.denominator;
            return output;
        }

        public Fraction Simple()
        {
            int decrement = 0;
            if (this.numerator <= this.denominator) decrement = this.numerator;
            else decrement = this.denominator;
            while (decrement > 0)
            {
                if (this.numerator % decrement == 0 && this.denominator % decrement == 0)
                {
                    this.numerator /= decrement;
                    this.denominator /= decrement;
                }
                decrement--;
            }
            return this;
        }

        public int Numerator => numerator;
        public int Denominator => denominator;
        public double DecFraction => (double)numerator / (double)denominator;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую дробь (числитель/знаменатель):");
            int numeratorFirst = Convert.ToInt32(Console.ReadLine());
            int denominatorFirst = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (denominatorFirst == 0) throw new ArgumentException(String.Format("Знаменатель не может быть равен {0}", denominatorFirst));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.GetType()} ({e.Message})");
                //Console.ReadKey();
                //return;
            }
            Fraction FractionFirst = new Fraction(numeratorFirst, denominatorFirst);
            Console.WriteLine("Введите вторую дробь (числитель/знаменатель):");
            int numeratorSecond = Convert.ToInt32(Console.ReadLine());
            int denominatorSecond = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (denominatorSecond == 0) throw new ArgumentException(String.Format("Знаменатель не может быть равен {0}", denominatorSecond));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.GetType()} ({e.Message})");
                //Console.ReadKey();
                //return;
            }
            Fraction FractionSecond = new Fraction(numeratorSecond, denominatorSecond);
            Fraction Buffer = new Fraction();
            Console.WriteLine("Введите тип операции (+, -, *, /), один символ");
            switch (Console.ReadLine())
            {
                case "+": Buffer = FractionFirst.Plus(FractionSecond); break;
                case "-": Buffer = FractionFirst.Minus(FractionSecond); break;
                case "*": Buffer = FractionFirst.Multi(FractionSecond); break;
                case "/": Buffer = FractionFirst.Divide(FractionSecond); break;
                default: return;
            }
            Buffer.Simple();
            if (Buffer.Numerator == 0 || Buffer.Numerator%Buffer.Denominator == 0) Console.WriteLine($"Результат операции: {Buffer.Numerator}");
            else Console.WriteLine($"Результат операции: {Buffer.Numerator}/{Buffer.Denominator}");

            Console.WriteLine("Результат операции в десятичном виде: {0:F2}",Buffer.DecFraction);
            Console.ReadKey();
        }
    }
}
