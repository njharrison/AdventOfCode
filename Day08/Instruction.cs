using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day08
{
    class Instruction
    {
        public string Command { get; internal set; }
        public int Offset { get; }

        public int TimesVisited { get; set; }

        public Instruction(string command, int offset)
        {
            Command = command;
            Offset = offset;
        }
    }
}
