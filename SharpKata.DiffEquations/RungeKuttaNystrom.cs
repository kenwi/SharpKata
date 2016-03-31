using System;

namespace SharpKata.DiffEquations
{
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
}
