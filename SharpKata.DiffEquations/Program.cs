using System;

namespace SharpKata.DiffEquations
{
	class MainClass
	{
		public static void FirstDerivative()
		{
			var circuit = new CircuitV(0.1, 500);
			double t0 = 0, tmax = 90, q0 = 25, h = 5, i0 = circuit.GetValue(t0, q0);
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

		public static void FirstDerivative_NewtonsLawOfCooling()
		{
			/**
			 * 	Newton's law of cooling:
			 * 
			 * 	dT/dt = -K(T-Ta)
			 * 
			 *  for T >= Ta => T(t) = Ce^-kt + Ta
			 * 
			 * 	We know that
			 * 	Ta = 20, T(0) = 80, T(2) = 60
			 * 
			 * 	How many minutes to cool to 40 degrees celcius?
			 **/
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
