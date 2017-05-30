using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RunTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string compiler = @"..\..\..\GPLexTutorial\bin\Debug\GPLexTutorial.exe";
            string testFolder = @"..\..\..\GPLexTutorial\Tests";
            string sourceFilePattern = "*.j";

            foreach (var srcFile in Directory.EnumerateFiles(testFolder, sourceFilePattern, SearchOption.AllDirectories))
            {
                var info = new ProcessStartInfo(compiler, srcFile);
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                var process = Process.Start(info);
                process.Start();
                process.WaitForExit();

                var errors = new StringBuilder();

                using (var expected = new StreamReader(srcFile + ".expected"))
                {

                    int i = 1;
                    while (!process.StandardOutput.EndOfStream && !expected.EndOfStream)
                    {
                        var found = process.StandardOutput.ReadLine();
                        var expect = expected.ReadLine();
                        if (found != expect)
                        { 
                            errors.AppendFormat("\tError, line {0}, expected {1}, found {2}", i, expect, found);
                            errors.AppendLine();
                        }
                        i++;
                    }

                    while (process.StandardOutput.EndOfStream && !expected.EndOfStream)
                    {
                        var expect = expected.ReadLine();
                        errors.AppendFormat("\tError, line {0}, expected {1}, found {2}", i, expect, "nothing");
                        errors.AppendLine();
                        i++;
                    }

                    while (!process.StandardOutput.EndOfStream && expected.EndOfStream)
                    {
                        var found = process.StandardOutput.ReadLine();
                        errors.AppendFormat("\tError, line {0}, expected {1}, found {2}", i, "nothing", found);
                        errors.AppendLine();
                        i++;
                    }
                }

                if (errors.Length > 0)
                    Console.Write("Fail\t");
                else
                    Console.Write("Pass\t");
                Console.WriteLine(srcFile);
                if (errors.Length > 0)
                    Console.Write(errors.ToString());

                process.StandardOutput.Close();
                process.Close();

            }
        }
    }
}
