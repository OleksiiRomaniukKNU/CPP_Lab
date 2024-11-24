using System;
using System.IO;
using LabLibrary;
using CommandLine;

namespace MyApp.Console
{
    class Program
    {
        public class Options
        {
            [Option('v', "version", HelpText = "Displays version information.")]
            public bool Version { get; set; }

            [Option("run", HelpText = "Run a specific lab task.")]
            public string Lab { get; set; }

            [Option('i', "input", HelpText = "Input file.")]
            public string InputFile { get; set; }

            [Option('o', "output", HelpText = "Output file.")]
            public string OutputFile { get; set; }

            [Option("set-path", HelpText = "Set the path for input/output files.")]
            public string SetPath { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    // Вивести інформацію про версію
                    if (options.Version)
                    {
                        Console.WriteLine("MyApp Version 1.0.0");
                        Console.WriteLine("Author: Firstname Lastname");
                    }

                    // Обробка команди 'run'
                    else if (!string.IsNullOrEmpty(options.Lab))
                    {
                        string inputFile = options.InputFile ?? GetInputFilePath(options.SetPath);
                        string outputFile = options.OutputFile ?? "output.txt";

                        if (string.IsNullOrEmpty(inputFile))
                        {
                            Console.WriteLine("Error: Input file is required.");
                            return;
                        }

                        switch (options.Lab.ToLower())
                        {
                            case "lab1":
                                LabTasks.RunLab1(inputFile, outputFile);
                                break;
                            case "lab2":
                                LabTasks.RunLab2(inputFile, outputFile);
                                break;
                            case "lab3":
                                LabTasks.RunLab3(inputFile, outputFile);
                                break;
                            default:
                                Console.WriteLine("Invalid lab number. Use 'lab1', 'lab2', or 'lab3'.");
                                break;
                        }
                    }
                    // Обробка команди set-path
                    else if (!string.IsNullOrEmpty(options.SetPath))
                    {
                        Environment.SetEnvironmentVariable("LAB_PATH", options.SetPath);
                        Console.WriteLine($"LAB_PATH set to: {options.SetPath}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Use 'version', 'run <lab>', or 'set-path <path>'.");
                    }
                });
        }

        private static string GetInputFilePath(string customPath)
        {
            string filePath = customPath ?? Environment.GetEnvironmentVariable("LAB_PATH");

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "input.txt");
            }

            return filePath;
        }
    }
}
