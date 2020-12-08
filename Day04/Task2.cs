using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day04
{
    class Task2 : IPassportVerifier, ITask
    {
        public bool PassportValid(Dictionary<string, string> passport)
        {
            var valid = BirthYearValid(passport)
                && IssueYearValid(passport)
                && ExpirationYearValid(passport)
                && HeightValid(passport)
                && HairColourValid(passport)
                && EyeColourValid(passport)
                && PassportIdValid(passport);

            if (valid)
            {
                return true;
            }

            return false;
        } 


        private bool EyeColourValid(Dictionary<string, string> passport)
        {
            const string Key = "ecl";
            if (!passport.ContainsKey(Key))
            {
                return false;
            }

            var validValues = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return validValues.Count(a => a == passport[Key]) == 1;
        }

        private bool PassportIdValid(Dictionary<string, string> passport)
        {
            const string Key = "pid";
            if (!passport.ContainsKey(Key))
            {
                return false;
            }

            var regex = new Regex("^[0-9]{9,9}$");

            var match = regex.Match(passport[Key]);

            return match.Success;
        }

        private bool HairColourValid(Dictionary<string, string> passport)
        {
            const string Key = "hcl";
            if (!passport.ContainsKey(Key))
            {
                return false;
            }

            var regex = new Regex("^\\#[0-9a-f]{6,6}$");

            var match = regex.Match(passport[Key]);

            return match.Success;
        }

        private bool BirthYearValid(Dictionary<string, string> passport)
        {
            return YearValid(passport, "byr", 1920, 2002);
        }

        private bool IssueYearValid(Dictionary<string, string> passport)
        {
            return YearValid(passport, "iyr", 2010, 2020);
        }

        private bool ExpirationYearValid(Dictionary<string, string> passport)
        {
            return YearValid(passport, "eyr", 2020, 2030);
        }

        private bool YearValid(Dictionary<string, string> passport, string Key, int minYear, int maxYear)
        {
            if (!passport.ContainsKey(Key))
            {
                return false;
            }


            if (!int.TryParse(passport[Key], out int year))
            {
                return false;
            }

            if (year < minYear || year > maxYear)
            {
                return false;
            }

            return true;
        }

        private bool HeightValid(Dictionary<string, string> passport)
        {
            const string Key = "hgt";
            if (!passport.ContainsKey(Key))
            {
                return false;
            }

            var regex = new Regex("(?<Number>\\d*)(?<Units>.*)");

            var match = regex.Match(passport[Key]);

            if (!match.Success)
            {
                return false;
            }

            if (!int.TryParse(match.Groups["Number"].Value, out int number))
            {
                return false;
            }
            var units = match.Groups["Units"].Value;

            if (units == "cm")
            {
                return number >= 150 && number <= 193;
            }

            if (units == "in")
            {
                return number >= 59 && number <= 76;
            }

            return false;
        }

        public long Solve(string[] input)
        {
            var passportListValidCounter = new PassportListValidCounter(this);

            return passportListValidCounter.CalculateValidCount(input);
        }
    }
}
