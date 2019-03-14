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
            //The next four lines prompt the user to tell the program how many darts each thread should throw
            //and how many threads should be ran.
            Console.WriteLine("What is the number of throws each thread should make?");
            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many threads would you like to perform?");
            int answer2 = Convert.ToInt32(Console.ReadLine());
            //The two list are created here
            List<Thread> threadList = new List<Thread>(answer2);
            List<FindPiThread> findPiList = new List<FindPiThread>(answer2);
            //This will create the threads based on how many the client asked for
            for (int i = 1; i <= answer2; i++)
            {
                //creates and stores the threads 
                //also starts them and sleeping them when finished.
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
            double Temp = 0;
            foreach (FindPiThread item in findPiList)
            {
                //uses and accessor to get the number of darts that were thrown
                double inside = item.DartsInside;
                Console.WriteLine(item.DartsInside);
                //Calculates each threads pi estimation and adds it to a temp holder 
                double estimation = (inside / answer) * 4;
                Temp = estimation + Temp;
                if (item == findPiList.Last())
                {
                    //performs the calculation to estimate the value of pi based of the average pi estimation.
                    estimation = Temp / answer2;
                    Console.WriteLine("The pi estimation is: ");
                    Console.WriteLine(estimation);
                }
            }
            //In doing some small experiments i have noticed that the higher the dart amount
            //The much closer the estimation is to pi
            //It also tends to be a lot slower when the thread count is high.
            //High thread count but low darts tends to have a poor accuracy
            Console.ReadKey();
        }
    }
}
