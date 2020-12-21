using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Questions._2020
{
    public class Day18Question
    {
        public int Day => 18;
        public int Year => 2020;
        public string Name => "Operation Order";

        public string SolvePart1(string[] input)
            => input
                .Select(s => EvaluateExpression(s, new Dictionary<string, int>
                {
                    ["*"] = 1,
                    ["/"] = 1,
                    ["+"] = 1,
                    ["-"] = 1,
                }))
                .Sum()
                .ToString();

        public IEnumerable<long> SolvePart2(string[] input)
            => input
                .Select(s => EvaluateExpression(s, new Dictionary<string, int>
                {
                    ["*"] = 1,
                    ["/"] = 1,
                    ["+"] = 2,
                    ["-"] = 2,
                }));

        public static long EvaluateExpression(string prefix, Dictionary<string, int> operatorPrecedenceDict)
        {
            var postfix = ToPostfix(prefix, operatorPrecedenceDict);
            var argStack = new Stack<long>();
            foreach (var token in postfix)
            {
                switch (token)
                {
                    case "*":
                        argStack.Push(argStack.Pop() * argStack.Pop());
                        break;
                    case "/":
                        argStack.Push(argStack.Pop() / argStack.Pop());
                        break;
                    case "+":
                        argStack.Push(argStack.Pop() + argStack.Pop());
                        break;
                    case "-":
                        argStack.Push(argStack.Pop() - argStack.Pop());
                        break;
                    default:
                        argStack.Push(long.Parse(token));
                        break;
                }
            }

            return argStack.Pop();
        }

        public static List<string> ToPostfix(string infix, Dictionary<string, int> operatorPrecedenceDict)
        {
            var tokens = infix
            .Replace("(", " ( ")
            .Replace(")", " ) ")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();
            var output = new List<string>();
            foreach (var token in tokens)
            {
                if (operatorPrecedenceDict.TryGetValue(token, out var op1))
                {
                    while (stack.Count > 0 && operatorPrecedenceDict.TryGetValue(stack.Peek(), out var op2))
                    {
                        if (op1.CompareTo(op2) < 0)
                        {
                            output.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    string top;
                    while (stack.Count > 0 && (top = stack.Pop()) != "(")
                    {
                        output.Add(top);
                    }
                }
                else
                {
                    output.Add(token);
                }
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return output;
        }
    }
}