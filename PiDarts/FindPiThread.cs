//Author: Philippe Lumpkin
//Date: 3/12/2019
//File: FindPiThread.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDarts
{
    public class FindPiThread
    {
        int dartsToThrow = 0;
        int dartsInside = 0;
        Random newRandom;

        public FindPiThread(int d)
        {
            dartsToThrow = d;
            newRandom = new Random();
        }

        public int DartsInside
        {
            get
            {
                return dartsInside;
            }
            set
            {
                dartsInside = value;
            }
        }

        public void throwDarts()
        {
            for (int i = 0; i <= dartsToThrow; i++)
            {
                double x = newRandom.NextDouble();
                double y = newRandom.NextDouble();

                double z = x * x + y * y;

                if (z <= 1)
                {
                    dartsInside++;
                }
            }
        }
    }
}
