using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day08
{
    class Task2 : Day08TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var instructionList = this.ParseInstructions(input);

            for (var i = 0; i < instructionList.Count; i++)
            {
                for (var j = 0; j < instructionList.Count; j++)
                {
                    instructionList[j].TimesVisited = 0;
                }

                this.ReverseInstruction(instructionList[i]);

                var result = this.ExecuteProgram(instructionList);

                if (result.Item2)
                {
                    return result.Item1;
                }

                this.ReverseInstruction(instructionList[i]);
            }

            return ulong.MinValue;
        }

        private void ReverseInstruction(Instruction instruction)
        {
            if (instruction.Command == "nop")
            {
                instruction.Command = "jmp";
            }
            else if (instruction.Command == "jmp")
            {
                instruction.Command = "nop";
            }
        }
    }
}
