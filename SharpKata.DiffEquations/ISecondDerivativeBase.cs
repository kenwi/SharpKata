using System;

namespace SharpKata.DiffEquations
{
	public interface ISecondDerivativeBase
	{
		double GetValue(double x, double y, double dy);
	}	
}
