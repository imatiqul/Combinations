using BusinessLogic.Managers;
using Luxoft.Combinations.Domain.Configurations;
using Luxoft.Combinations.Domain.Interfaces;

namespace Luxoft.Combinations.Shell
{
  public class CombinationGenerator : ICombinationGenerator
  {
    private IInputReader _reader;
    private IOutputWriter _writer;

    private CombinationGenerator()
    {
    }

    public CombinationGenerator(IInputReader reader, IOutputWriter writer)
    {
      _reader = reader;
      _writer = writer;
    }

    public void Generate()
    {
      if (!_reader.IsValid())
      {
        Log.Instance.Debug(string.Format("Input file not exists! Please check the file path."));
        return;
      }

      if (!_writer.IsValid())
      {
        Log.Instance.Debug(string.Format("Output file not exists! Please check the file path."));
        return;
      }

      var input = _reader.Read();
      if (input == null)
      {
        Log.Instance.Debug("Invalid input lines in input file! Please check the input file.");
        return;
      }

      using (ICombinationManager manager = new CombinationManager(input))
      {
        if (!manager.IsValid())
        {
          Log.Instance.Debug("Invalid input! Please check the input file format.");
          return;
        }

        StopWatcher.Instance.Start();

        var output = manager.Execute();

        var executionTime = StopWatcher.Instance.Stop();
        Log.Instance.Info(string.Format("Total Execution Time: {0} ms", executionTime));

        if (output == null)
        {
          Log.Instance.Debug("Invalid input! Please check the input file format.");
          return;
        }

        var successed = _writer.Write(output);
        if (!successed)
        {
          Log.Instance.Debug("Invalid result.");
          return;
        }
      }

    }

    public void Dispose()
    {
      _reader = null;
      _writer = null;
    }
  }
}
