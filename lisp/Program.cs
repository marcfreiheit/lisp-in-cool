using System;
using System.Collections.Generic;

namespace lisp_in_cool
{
    public class LispParser 
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
        public static List<string> parse(string input) {
           return new List<string>(); 
        }
    }
}
