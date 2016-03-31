using System;

namespace SharpKata.DiffEquations
{
	public interface IFirstDerivativeBase
	{
		double GetValue(double t, double q);
	}	
}
