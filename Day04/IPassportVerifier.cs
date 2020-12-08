using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    internal interface IPassportVerifier
    {
        bool PassportValid(Dictionary<string, string> passport);
    }
}