using System;

namespace SharpKata.DiffEquations
{
	public class CircuitV : IFirstDerivativeBase
	{
		double c, r;

		public CircuitV(double c, double r)
		{
			this.c = c > 0 ? c : 1;
			this.r = r > 0 ? r : 1;

		}

		public double GetValue(double t, double q)
		{
			double u = q / c;
			return -u / r;
		}
	}	
}
