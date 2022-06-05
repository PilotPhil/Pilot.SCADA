using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Base
{
	class ConvBase
	{
		protected float[] Conv(float[] input1, float[] input2)
		{
			var mm = input1.Length;
			var nn = input2.Length;

			float[] xx = new float[mm + nn - 1];
			float[] tempinput2 = new float[mm + nn - 1];

			for (int i = 0; i < nn; i++)
			{
				tempinput2[i] = input2[i];
			}
			for (int i = nn; i < mm + nn - 1; i++)
			{
				tempinput2[i] = 0;
			}

			// do convolution 
			for (int i = 0; i < mm + nn - 1; i++)
			{
				xx[i] = 0;
				int tem = (Math.Min(i, mm)) == mm ? mm - 1 : Math.Min(i, mm);
				for (int j = 0; j <= tem; j++)
				{
					xx[i] += (input1[j] * tempinput2[i - j]);
				}
			}

			// set value to the output array 
			return xx;
		}
	}
}
