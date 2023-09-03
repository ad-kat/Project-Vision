using System;
using System.Text;

namespace tt2
{


    internal class Program
    {
        int n1, n2;
        public Program()
        {
            n1 = 0; n2 = 0;
        }
        int numb()
        {
            int pcr = Random.Next(1, 6);
            return pcr;
        }
        void check()
        {
            int sum = 1;
            while (sum < 100)
            {
                n1 = numb();
                n2 = numb();
                sum = sum + n1 + n2;
            }
            if (sum >= 100)
                Console.WriteLine("you win!!");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
                        program.check();
            Console.ReadLine();
        }
    }
}
