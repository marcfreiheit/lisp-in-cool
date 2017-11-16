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
            var tokens = new List<string>();
            var token = string.Empty;

            if (!input.StartsWith('(')) { throw new ArgumentException("Expressions need an opening parenthesis"); }
            if (!input.EndsWith(')')) { throw new ArgumentException("Expressions need a closing parenthesis"); }

            foreach (var character in input)
            {
                if (new List<Char>(new Char[] { '(', ')' }).Contains(character)) { continue; }
                if (char.IsWhiteSpace(character)) {
                    if (token != string.Empty) {
                        tokens.Add(token);
                        token = string.Empty;
                    }
                    continue;
                }
                token += character;
            }

            tokens.Add(token);

            return tokens;
        }

        public static int doMagic(string input) {
            var tokenized = parse(input);
            if (tokenized.Count == 3)
            {
                var op = tokenized[0];
                var arg1 = tokenized[1];
                var arg2 = tokenized[2];

                if (op == "+") {
                    return execute(arg1) + execute(arg2);
                } else if (op == "-") {
                    return execute(arg1) - execute(arg2);
                } else if (op == "*") {
                    return execute(arg1) * execute(arg2);
                } else if (op == "/") {
                    return execute(arg1) / execute(arg2);
                }

            } else {
                throw new ArgumentException(string.Format("Invalid syntax. You have written {0} characters!", tokenized.Count));
            }

            return 0;
        }

        public static int execute(string argument) {
            return int.Parse(argument);
        }
    }
}
