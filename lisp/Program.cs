using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lisp_in_cool
{
    public class LispParser 
    {
        private static Dictionary<string, int?> variableStore = new Dictionary<string, int?>();

        static void Main(string[] args)
        {
            Console.Write(">>> ");
            var input = Console.ReadLine();
            while (true) {
                Console.WriteLine(doMagic(input));
                Console.Write(">>> ");
                input = Console.ReadLine();
            }

        }
        public static List<Object> parse(string input) {
            var tokens = new List<Object>();
            var token = string.Empty;
            var expressionFlag = false;

            if (!input.StartsWith('(')) { throw new ArgumentException("Expressions need an opening parenthesis"); }
            if (!input.EndsWith(')')) { throw new ArgumentException("Expressions need a closing parenthesis"); }

            // skip first and last parenthesis
            foreach (var character in input.Substring(1, input.Length - 2))
            {
                // if (new List<Char>(new Char[] { '(', ')' }).Contains(character)) { continue; }
                if (character == '(') {
                    expressionFlag = true;
                } else if (character == ')') {
                    expressionFlag = false;
                    token += character;
                    tokens.Add(parse(token));
                    token = string.Empty;
                    continue;
                }

                if (char.IsWhiteSpace(character) && token != string.Empty && !expressionFlag) {
                    tokens.Add(token);
                    token = string.Empty;
                    continue;
                } else if (char.IsWhiteSpace(character) && token == string.Empty) {
                    continue;
                }
                token += character;
            }

            if (token != string.Empty) { tokens.Add(token); }

            return tokens;
        }

        public static int doMagic(string input) {
            var tokenized = parse(input);
            return execute(tokenized);;
        }

        public static int execute(object input) {
            if (input.GetType() == typeof(string)) {
                var varibleValue = getVariable((string)input);

                if(varibleValue == null) {
                    return int.Parse((string)input);
                 } else {
                     return (int)varibleValue;
                 } 
                
            }

            var tokenized = (List<object>)input;
            
            if (tokenized.Count != 3) { throw new ArgumentException(string.Format("Invalid syntax. You have written {0} characters!", tokenized.Count)); }
            
            var op = (string)tokenized[0];
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
            } else if (op == "set!") {
                return setVariable((string)arg1, execute(arg2));
            }

            throw new ArgumentException(string.Format("{0} is an invalid operator."), op);
        }

        public static int setVariable(string identifier, int value) {
            variableStore.Add(identifier, value);
            return value;
        }
        public static int? getVariable(string identifier) {
            return variableStore.GetValueOrDefault(identifier, null);
        }
    }
}
