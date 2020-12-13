using System;
using System.Collections.Generic;

namespace AdventOfCode.Day08
{
    internal class Day08TaskBase
    {
        protected Tuple<ulong, bool> ExecuteProgram(List<Instruction> instructionList)
        {
            var address = 0;
            ulong accumulator = 0;

            while (address < instructionList.Count && instructionList[address].TimesVisited == 0)
            {
                var instruction = instructionList[address];
                if (instruction.Command == "jmp")
                {
                    address += instruction.Offset;
                }
                else if (instruction.Command == "acc")
                {
                    accumulator += (ulong)instruction.Offset;
                    address++;
                }
                else if (instruction.Command == "nop")
                {
                    address++;
                }
                else
                {
                    throw new InvalidProgramException("Unknown command encountered: " + instructionList[address].Command);
                }

                instruction.TimesVisited++;
            }

            return new Tuple<ulong, bool>(accumulator, address == instructionList.Count);
        }

        protected List<Instruction> ParseInstructions(string[] input)
        {
            var instructionList = new List<Instruction>();

            foreach (var line in input)
            {
                var instructionText = line.Split(' ');

                instructionList.Add(new Instruction(instructionText[0], int.Parse(instructionText[1])));
            }

            return instructionList;
        }
    }
}