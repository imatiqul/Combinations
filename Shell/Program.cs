using Luxoft.Combinations.Domain.Infrastructure;
using Luxoft.Combinations.Domain.Interfaces;
using Luxoft.Combinations.Shell;
using System;

namespace Shell
{
  class Program
  {
    static void Main(string[] args)
    {
      var options = new Options();
      if (CommandLine.Parser.Default.ParseArguments(args, options))
      {
        if (options.Verbose)
        {
          Console.WriteLine("Input File: {0}", options.InputFile);
          Console.WriteLine("Output File: {0}", options.OutputFile);
        }

        IInputReader reader = new InputFileReader(options.InputFile);
        IOutputWriter writer = new OutputFileWriter(options.OutputFile);

        using (ICombinationGenerator generator = new CombinationGenerator(reader, writer))
        {
          generator.Generate();
        }
      }
    }
  }
}
