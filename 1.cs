using System;

namespace a
{
	class Solver
	{
		delegate double Function(double X);
		delegate double PointIn (Function function, double a, double b);
		static PointIn method;
		static Solver()
		{
			Random r = new Random();
			int q = r.Next(300)%3;
			switch (q)
			{
				case 0:
					method = GetX1;
					Console.WriteLine("Выбран метод деления отрезка пополам");
					break;
				case 1:
					method = GetX2;
					Console.WriteLine("Выбран метод хорд");
					break;
				case 2:
					method = GetX3;
					Console.WriteLine("Выбран метод касательных");
					break;
			}
		}
		static double GetX1(Function f, double a, double b)
		{
			return (a + b) / 2;
		}

		static double GetX2(Function f, double a, double b)
		{
			return a - f(a) * (b - a) / (f(b) - f(a)); 
		}
		static double GetX3(Function f, double a, double b)
		{
			double fa = (f(a + 0.001) - f(a)) / 0.001;
			if (fa != 0)
			{
				double c = a - f(a) / fa;
				if (a <= c && c <= b)
					return c;
			}
			double fb = (f(b + 0.001) - f(b)) / 0.001;
			if (fb != 0)
			{
				double c = b - f(b) / fb;
				if (a <= c && c <= b)
					return c;
			}
			throw new Exception("Возможно, на этом отрезке корней нет");
		}
	}
	class Program
	{
		static void main ()
		{

		}
	}
}