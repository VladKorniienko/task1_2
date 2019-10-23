using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korniienko_Task2
{
    class Polynomial : ICloneable, IComparer<Polynomial>
    {
        private int _degree;
        private double[] _coefficients;

        public Polynomial() { }

        public Polynomial(int degree)
        {
            _degree = degree;
            _coefficients = new double[degree + 1];
        }

        public Polynomial(int degree, double[] coefficients)
        {
            _degree = degree;
            _coefficients = new double[degree + 1];
            _coefficients = coefficients;

        }

        public int Degree { get => _degree; set => _degree = value; }
        public double[] Coefficients { get => _coefficients; set => _coefficients = value; }

        public double this[int i]   //Index
        {
            //валидация
            get
            {
                return this._coefficients[i];
            }
            set
            {
                this._coefficients[i] = value;
            }
        }


        public void InputFromConsole()
        {
            for (int i = 0; i <= _degree; i++)
            {
                Console.WriteLine($"Input [{i}] coefficient: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                    this._coefficients[i] = number;
                else
                    Console.WriteLine("Incorrect input!");
            }
        }
        public void Print()
        {
            for (int i = 0; i <= Degree; i++)
            {
                if (i == Degree)
                    Console.Write("(" + this._coefficients[i] + ")x^" + (_degree - i));
                else
                    Console.Write("(" + this._coefficients[i] + ")x^" + (_degree - i) + " + ");
            }
            Console.WriteLine();
        }


        public static Polynomial operator *(Polynomial p1, Polynomial p2)               //Multiply
        {

            Polynomial result = new Polynomial(p1._degree + p2._degree);
            for (int i = 0; i <= p1._degree; i++)
                for (int j = 0; j <= p2._degree; j++)
                    result[i + j] += p1[i] * p2[j];
            return result;
        }


        public static Polynomial operator -(Polynomial p1, Polynomial p2)        //subtraction
        {

            int max_degree = Math.Max(p1._degree, p2._degree);
            int k = 0;
            bool isFirstBigger = p1._degree >= p2._degree ? true : false;
            bool isSecondBigger = !isFirstBigger;


            Polynomial result = new Polynomial(max_degree);

            if (isFirstBigger)
            {
                for (k = 0; k < p1._degree - p2._degree; k++)
                    result[k] = p1[k];
                int j = k;
                for (int i = 0; i <= p2._degree; i++)
                {
                    result[k] = p1[i + j] - p2[i];
                    k++;
                }

            }
            if (isSecondBigger)
            {
                for (k = 0; k < p2._degree - p1._degree; k++)
                    result[k] = p2[k] - 2 * p2[k];
                int j = k;
                for (int i = 0; i <= p1._degree; i++)
                {
                    result[k] = p1[i] - p2[i + j];
                    k++;
                }
            }
            return result;
        }
        public static Polynomial operator +(Polynomial p1, Polynomial p2)       //Sum
        {

            int max_degree = Math.Max(p1._degree, p2._degree);
            int k = 0;
            bool isFirstBigger = p1._degree >= p2._degree ? true : false;
            bool isSecondBigger = !isFirstBigger;

            Polynomial result = new Polynomial(max_degree);

            if (isFirstBigger)
            {
                for (k = 0; k < p1._degree - p2._degree; k++)
                    result[k] = p1[k];
                int j = k;
                for (int i = 0; i <= p2._degree; i++)
                {
                    result[k] = p1[i + j] + p2[i];
                    k++;
                }

            }
            if (isSecondBigger)
            {
                for (k = 0; k < p2._degree - p1._degree; k++)
                    result[k] = p2[k];
                int j = k;
                for (int i = 0; i <= p1._degree; i++)
                {
                    result[k] = p1[i] + p2[i + j];
                    k++;
                }
            }

            return result;
        }



        public object Clone()       //IClonable
        {
            return this.MemberwiseClone();
        }

        public int Compare(Polynomial p1, Polynomial p2)     //IComparer
        {
            if (p1._degree > p2._degree)
                return 1;
            else if (p1._degree < p2._degree)
                return -1;
            else
                return 0;
        }
    }
}
