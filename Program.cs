using AdventOfCode.Tasks;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] _)
        {
            var taskTypes = Assembly.GetExecutingAssembly().GetTypes().Where(a => typeof(ITask).IsAssignableFrom(a) && a.IsClass).OrderBy(a => a.FullName).Reverse();

            var stopwatch = new Stopwatch();

            foreach (var taskType in taskTypes)
            {
                var task = (ITask)Activator.CreateInstance(taskType);
                var input = File.ReadAllLines(taskType.Namespace.Split('.').Last() + "\\Input.txt");
                stopwatch.Restart(); 
                Console.WriteLine(taskType.FullName + " result: " + task.Solve(input) + " in " + stopwatch.ElapsedMilliseconds + "ms");
            }
        }
    }
}
