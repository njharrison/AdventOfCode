﻿using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] _)
        {
            var day1Task1 = new Day1.Task1();
            Console.WriteLine("Day 1 Task 1 result: " + day1Task1.Solve(File.ReadAllLines("Day1\\Input.txt")));
            var day1Task2 = new Day1.Task2();
            Console.WriteLine("Day 1 Task 2 result: " + day1Task2.Solve(File.ReadAllLines("Day1\\Input.txt")));

            var day2Task1 = new Day2.Task1();
            Console.WriteLine("Day 2 Task 1 result: " + day2Task1.Solve(File.ReadAllLines("Day2\\Input.txt")));
            var day2Task2 = new Day2.Task2();
            Console.WriteLine("Day 2 Task 2 result: " + day2Task2.Solve(File.ReadAllLines("Day2\\Input.txt")));

            var day3Task1 = new Day3.Task1();
            Console.WriteLine("Day 3 Task 1 result: " + day3Task1.Solve(File.ReadAllLines("Day3\\Input.txt")));
            var day3Task2 = new Day3.Task2();
            Console.WriteLine("Day 3 Task 2 result: " + day3Task2.Solve(File.ReadAllLines("Day3\\Input.txt")));

            var day4Task1 = new Day4.Task1();
            Console.WriteLine("Day 4 Task 1 result: " + day4Task1.Solve(File.ReadAllLines("Day4\\Input.txt")));
            var day4Task2 = new Day4.Task2();
            Console.WriteLine("Day 4 Task 2 result: " + day4Task2.Solve(File.ReadAllLines("Day4\\Input.txt")));

            var day5Task1 = new Day5.Task1();
            Console.WriteLine("Day 5 Task 1 result: " + day5Task1.Solve(File.ReadAllLines("Day5\\Input.txt")));
            var day5Task2 = new Day5.Task2();
            Console.WriteLine("Day 5 Task 2 result: " + day5Task2.Solve(File.ReadAllLines("Day5\\Input.txt")));

            var day6Task1 = new Day6.Task1();
            Console.WriteLine("Day 6 Task 1 result: " + day6Task1.Solve(File.ReadAllLines("Day6\\Input.txt")));
            var day6Task2 = new Day6.Task2();
            Console.WriteLine("Day 6 Task 2 result: " + day6Task2.Solve(File.ReadAllLines("Day6\\Input.txt")));

            var day7Task1 = new Day7.Task1();
            Console.WriteLine("Day 7 Task 1 result: " + day7Task1.Solve(File.ReadAllLines("Day7\\Input.txt")));
            var day7Task2 = new Day7.Task2();
            Console.WriteLine("Day 7 Task 2 result: " + day7Task2.Solve(File.ReadAllLines("Day7\\Input.txt")));
        }
    }
}
