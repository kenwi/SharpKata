using System;

namespace SharpKata.DiffEquations
{
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
}
