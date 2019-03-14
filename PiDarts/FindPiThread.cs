//Author: Philippe Lumpkin
//Date: 3/12/2019
//File: FindPiThread.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiDarts
{
    public class FindPiThread
    {
        int dartsToThrow = 0;
        int dartsInside = 0;
        Random newRandom;
        //constructor for the darts to throw and the random generator
        public FindPiThread(int d)
        {
            dartsToThrow = d;
            newRandom = new Random();
        }
        //accessor for the darts inside variable
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
        //The following will simulate the throwing of the darts.
        //It will create an x and y to get coordinates for where it landed.
        //Then the x and y are sent into a calculation to compare that to the number one to determine its location
        //whether it would be inside or outside.
        //if it is inside then it is added to the darts inside tally
        public void throwDarts()
        {
            for (int i = 0; i <= dartsToThrow; i++)
            {
                double x = newRandom.NextDouble();
                double y = newRandom.NextDouble();

                double z = x * x + y * y;

                if (z <= 1)
                {
                    dartsInside = dartsInside + 1;
                }
            }
        }
    }
}
