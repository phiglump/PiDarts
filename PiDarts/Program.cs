//Author: Philippe Lumpkin
//Date: 3/12/2019
//File: Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiDarts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the number of throws each thread should make?");
            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many threads would you like to perform?");
            int answer2 = Convert.ToInt32(Console.ReadLine());

            List<Thread> threadList = new List<Thread>(answer2);
            List<FindPiThread> findPiList = new List<FindPiThread>(answer2);

            for (int i = 0; i <= answer2; i++)
            {
                FindPiThread findPiThread = new FindPiThread(answer);
                findPiList.Add(findPiThread);
                Thread myThread;
                myThread = new Thread(new ThreadStart(findPiThread.throwDarts));
                threadList.Add(myThread);
                myThread.Start();
                Thread.Sleep(16);
            }

            foreach (Thread item in threadList)
            {
                item.Join();
            }
            foreach (FindPiThread item in findPiList)
            {
                FindPiThread findPiThread = new FindPiThread(answer);
                int darts = findPiThread.DartsInside;
            }

            double estimation = darts / answer * 4;
            Console.WriteLine("The pi estimation is: ");
            Console.WriteLine(estimation);

            Console.ReadKey();
        }
    }
}
