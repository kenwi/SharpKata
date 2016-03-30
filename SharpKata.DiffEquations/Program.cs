using System;

namespace SharpKata.DiffEquations
{
	public interface IFirstDerivativeBase
	{
		double GetValue(double t, double q);
	}

	public interface ISecondDerivativeBase
	{
		double GetValue(double x, double y, double dy);
	}

	public class CircuitV : IFirstDerivativeBase
	{
		double _c, _r;

		public CircuitV(double c, double r)
		{
			_c = c > 0 ? c : 1;
			_r = r > 0 ? r : 1;
		}

		public double GetValue(double t, double q)
		{
			double u = q / _c;
			return -u / _r;
		}
	}

	public class FlyingBall : ISecondDerivativeBase
	{
		double dB = 0.1;	// Diameter
		double roB = 600;	// Density kg/m^3
		double cD = 0.1;	// Drag coefficient
		double g = 9.81;	// Gravitational acceleration m/s^2
		double roA = 1.29;	// Air density
		double mB;			// Ball mass, kg
		double aB;			// Ball cross-section area, m^2

		public FlyingBall()
		{
			double v = Math.PI * Math.Pow(dB, 3) / 6;
			mB = roB * v;
			aB = 0.25 * Math.PI * dB * dB;
		}

		public double GetValue(double t, double y, double v)
		{
			double f = -mB * g -Math.Sign(v) * 0.5 * cD * roA * v * v * aB;
			return f / mB;
		}
	}

	public class RungeKutta4
	{
		private IFirstDerivativeBase _derivative;
		private double _t0, _y0, _h, _d0;

		public RungeKutta4(IFirstDerivativeBase derivative, double t0, double y0, double h)
		{
			_derivative = derivative;
			_t0 = t0;
			_y0 = y0;
			_h = h;
			_d0 = derivative.GetValue(t0, y0);
		}

		public int Step(out double t1, out double y1, out double d1)
		{
			double k1 = _d0;
			double k2 = _derivative.GetValue(_t0 + _h / 2, _y0 + _h / 2 * k1);
			double k3 = _derivative.GetValue(_t0 + _h / 2, _y0 + _h / 2 * k2);
			double k4 = _derivative.GetValue(_t0 + _h, _y0 + _h * k3);

			y1 = _y0 + _h /6 * (k1 + 2 * k2 + 2 * k3 + k4);
			t1 = _t0 + _h;
			d1 = _derivative.GetValue(t1, y1);

			_t0 = t1;
			_y0 = y1;
			_d0 = d1;

			return 0;
		}
	}

	public class RungeKuttaNystrom 
	{
		private ISecondDerivativeBase derivative;
		private double t0, y0, dy0, h, d2y0;

		public RungeKuttaNystrom(ISecondDerivativeBase derivative, double t0, double y0, double dy0, double h, double d2y0)
		{
			this.derivative = derivative;
			this.t0 = t0;
			this.y0 = y0;
			this.dy0 = dy0;
			this.h = h;
			this.d2y0 = d2y0;
		}

		public int Step(out double t1, out double y1, out double dy1, out double d2y1)
		{
			double h2 = h * h;

			double k1 = d2y0;
			double k2 = derivative.GetValue(t0 + h / 2, y0 + h / 2 * dy0 + h2 / 8 * k1, dy0 + h / 2 * k1);
			double k3 = derivative.GetValue(t0 + h / 2, y0 + h / 2 * dy0 + h2 / 8 * k2, dy0 + h / 2 * k2);
			double k4 = derivative.GetValue(t0 + h, y0 + h * dy0 * h2 / 2 * k3, dy0 + h * k3);

			t1 = t0 + h;
			y1 = y0 + h * dy0 + h2 / 6 * (k1 + k2 + k3);
			dy1 = dy0 + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
			d2y1 = derivative.GetValue(t1, y1, dy1);

			t0 = t1;
			y0 = y1;
			dy0 = dy1;
			d2y0 = d2y1;

			return 0;
		}
	}

	class MainClass
	{
		public static void FirstDerivative()
		{
			var circuit = new CircuitV(0.1, 500);
			double t0 = 0, tmax = 90, q0 = 25, h = 10, i0 = circuit.GetValue(t0, q0);
			var integrator = new RungeKutta4(circuit, t0, q0, h);

			Console.WriteLine("Test 1, Ohm's and Kirchhoff's laws");
			Console.WriteLine("t,s     Q,C     I,A");
			Console.WriteLine("-------------------");
			Console.WriteLine("{0,3:F0}{1,8:F1}{2,8:F2}",t0,q0,-i0);

			double t, q, i;
			do 
			{
				integrator.Step(out t, out q, out i);
				Console.WriteLine("{0,3:F0}{1,8:F1}{2,8:F2}", t, q, -i);
			} while(t < tmax);
		}

		public static void SecondDerivative()
		{
			var ball = new FlyingBall();
			var acceleration = ball as ISecondDerivativeBase;
			double t0 = 0, tmax = 10, y0 = 0, h = 0.5, v0 = 50, a0 = acceleration.GetValue(t0, y0, v0);
			var integrator = new RungeKuttaNystrom(acceleration, t0, y0, v0, h, a0);

			Console.WriteLine("Test 2, equation of motion");
			Console.WriteLine(" t,s     y,m   v,m/s  a,m/s2");
			Console.WriteLine("----------------------------");
			Console.WriteLine("{0,4:F1}{1,8:F2}{2,8:F2}{3,8:F2}", t0, y0, v0, a0);

			double t, y, v, a;
			do {
				integrator.Step( out t, out y, out v, out a);
				Console.WriteLine("{0,4:F1}{1,8:F2}{2,8:F2}{3,8:F2}", t, y, v, a);
			} while(t < tmax);
		}

		public static void Main (string[] args)
		{
			FirstDerivative();

			SecondDerivative();


			Console.ReadKey();
		}
	}
}
