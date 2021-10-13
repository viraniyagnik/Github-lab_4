﻿using System;

using Psim.Particles;
using Psim.ModelComponents;
using Psim.Materials;

namespace Psim
{
	class Program
	{
		static void Main(string[] args)
		{
			DispersionData dData;
			dData.LaData = new double[] { -2.22e-7, 9260.0, 0.0};
			dData.TaData = new double[] { -2.28e-7, 5240.0, 0.0};
			dData.WMaxLa = 7.63916048e13;
			dData.WMaxTa = 3.0100793072e13;

			RelaxationData rData;
			rData.Bl = 1.3e-24;
			rData.Btn = 9e-13;
			rData.Btu = 1.9e-18;
			rData.BI = 1.2e-45;
			rData.W = 2.42e13;

			
			Material silicon = new Material(in dData, in rData);
			
			Sensor s = new Sensor(1, silicon, 300);
			Cell c = new Cell(10, 10, s);

			Console.WriteLine(c);

			for (int i = 0; i < 1000; ++i)
            {
				c.AddPhonon(new Phonon(1));
            }
			c.TakeMeasurements(1e6, 300);
			Console.WriteLine(c);
		}
	}
}
