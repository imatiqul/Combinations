using CommandLine;
using CommandLine.Text;
using System.Text;

namespace Luxoft.Combinations.Shell
{
  public class Options
  {
    [Option('i', "input", Required = true, HelpText = "Input file to read input set.")]
    public string InputFile { get; set; }

    [Option('o', "output", Required = true, HelpText = "Output file to write result.")]
    public string OutputFile { get; set; }

    [Option('v', null, HelpText = "Print details during execution.")]
    public bool Verbose { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this,
    (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
    }
  }
}
