using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    internal class ExpressionEvaluator
    {
        private readonly Regex regex;

        public ExpressionEvaluator()
        {
            this.regex = new Regex(@"\([a-z\d\ \+\*]*\)");
        }

        internal long Evaluate(string line, bool withPrecedence)
        {
            var matches = this.regex.Matches(line);
            while (matches.Any())
            {
                foreach (Match match in matches)
                {
                    line = line.Replace(match.Value, this.Evaluate(match.Value[1..^1], withPrecedence).ToString());
                }

                matches = this.regex.Matches(line);
            }

            if (withPrecedence)
            {
                return this.CalculateWithPrecedence(line);
            }
            else
            { 
                return this.Calculate(line);
            }
        }

        public long Calculate(string expression)
        {
            var components = expression.Split(' ');

            var operation = string.Empty;

            long total = -1;

            foreach (var subString in components)
            {
                long.TryParse(subString, out long currentValue);

                if (subString == "*" || subString == "+")
                {
                    operation = subString;
                }
                else
                {
                    switch (operation)
                    {
                        case "":
                            total = currentValue;
                            break;
                        case "*":
                            total *= currentValue;
                            break;
                        case "+":
                            total += currentValue;
                            break;
                    }
                }
            }

            return total;
        }

        public long CalculateWithPrecedence(string expression)
        {
            var regexPlus = new Regex(@"(?<LeftOperand>\d+)\ \+\ (?<RightOperand>\d+)");
            var regexMultiply = new Regex(@"(?<LeftOperand>\d+)\ \*\ (?<RightOperand>\d+)");

            var match = regexPlus.Match(expression);

            while (match.Success)
            {
                expression = regexPlus.Replace(expression, (long.Parse(match.Groups["LeftOperand"].Value) + long.Parse(match.Groups["RightOperand"].Value)).ToString(), 1);
                match = regexPlus.Match(expression);
            }

            match = regexMultiply.Match(expression);

            while (match.Success)
            {
                expression = regexMultiply.Replace(expression, (long.Parse(match.Groups["LeftOperand"].Value) * long.Parse(match.Groups["RightOperand"].Value)).ToString(), 1);
                match = regexMultiply.Match(expression);
            }

            return long.Parse(expression);
        }
    }
}