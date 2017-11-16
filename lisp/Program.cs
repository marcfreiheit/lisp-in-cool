using System;
using System.Collections.Generic;

namespace lisp_in_cool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>> ");
            var input = Console.ReadLine();
            while (true) {
                parse(input);
                Console.WriteLine(">>> ");
                input = Console.ReadLine();
            }

        }
        private static List<string> parse(string input) {
           return new List<string>(); 
        }
    }
}
