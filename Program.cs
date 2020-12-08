using AdventOfCode.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] _)
        {
            var taskTypes = Assembly.GetExecutingAssembly().GetTypes().Where(a => typeof(ITask).IsAssignableFrom(a) && a.IsClass).OrderBy(a => a.FullName);

            foreach (var taskType in taskTypes)
            {
                var task = (ITask)Activator.CreateInstance(taskType);
                Console.WriteLine(taskType.FullName + " result: " + task.Solve(File.ReadAllLines(taskType.Namespace.Split('.').Last() + "\\Input.txt")));
            }
        }
    }
}
