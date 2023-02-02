using System;
using System.Threading;

namespace ThreadSys
{

    /// Threadclass
    class ThreadClass
    {
        int loopCnt, loopDelay;
        Thread cThread;
        public static Semaphore semaphoreResource = new Semaphore(1, 1);

        public ThreadClass(string name, int delay)
        {
            loopCnt = 0;
           
            loopDelay = delay;
            cThread = new Thread(new ThreadStart(this.run));
            cThread.Name = name;
            cThread.Start();

        }
        // The main function in the ThreadClass
        void run()
        {
            Console.WriteLine(" Starting " + cThread.Name);
            do
            {
                
                Thread.Sleep(loopDelay);
                semaphoreResource.WaitOne();
                loopCnt++;
               
                Console.Write(" ");
                Console.Write(cThread.Name);
                Console.Write(" ");
                Console.Write("Loop=" + loopCnt);
                Console.Write(" ");
                Console.Write("Aleksander Holthe, 136624,");
                Console.Write(" ");
                Console.WriteLine(DateTime.Now.ToString("U"));

                semaphoreResource.Release();
            } while (loopCnt < 5);
            // Ending of the thread
            Console.WriteLine(" Ending " + cThread.Name);
        }
      
    }
    // The Main application
    class ThreadSys
    {
        /// Start of the main program


        static void Main(string[] args)
        {
            Console.WriteLine(" Start of main program ");

            // Making 5 threads ..
            ThreadClass ct1 = new ThreadClass("Thread#1", 95);
            ThreadClass ct2 = new ThreadClass("Thread#2", 158);
            ThreadClass ct3 = new ThreadClass("Thread#3", 221);
            ThreadClass ct4 = new ThreadClass("Thread#4", 284);
            ThreadClass ct5 = new ThreadClass("Thread#5", 347);

            while (true) { }
        }
    }
}