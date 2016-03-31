using System;

namespace SharpKata.DiffEquations
{
	public class RungeKutta4
	{
		private IFirstDerivativeBase derivative;
		private double t0, y0, h, d0;

		public RungeKutta4(IFirstDerivativeBase derivative, double t0, double y0, double h)
		{
			this.t0 = t0;
			this.y0 = y0;
			this.h = h;
			this.d0 = derivative.GetValue(t0, y0);
			this.derivative = derivative;
		}

		public int Step(out double t1, out double y1, out double d1)
		{
			double k1 = d0;
			double k2 = derivative.GetValue(t0 + h / 2, y0 + h / 2 * k1);
			double k3 = derivative.GetValue(t0 + h / 2, y0 + h / 2 * k2);
			double k4 = derivative.GetValue(t0 + h, y0 + h * k3);

			y1 = y0 + h /6 * (k1 + 2 * k2 + 2 * k3 + k4);
			t1 = t0 + h;
			d1 = derivative.GetValue(t1, y1);

			t0 = t1;
			y0 = y1;
			d0 = d1;

			return 0;
		}
	}	
}
