using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "abc1 2 3  &^%$";

            foreach(char c in testString)
            {
                Console.WriteLine("The value of {0} is {1}",c,(int)c);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
