using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    internal interface IPassportVerifier
    {
        bool PassportValid(Dictionary<string, string> passport);
    }
}