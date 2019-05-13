using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LineCounter
{
    static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage program.exe file_extension");
                Console.ReadKey();
                return;
            }

            var filesNames = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), args[0]);
            var count = filesNames
                .Select(File.ReadLines)
                .Select(lines => lines.Count(line => !string.IsNullOrWhiteSpace(RemoveComment(line)))).Sum();
            Console.WriteLine("Line count:{0}", count);
            Console.ReadKey();
        }

        private static string RemoveComment(string line)
        {
            return line.Trim().Split("//")[0];
        }
    }
}