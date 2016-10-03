using Luxoft.Combinations.Domain.Interfaces;
using System;
using Luxoft.Combinations.Domain.DTO;
using System.IO;
using Luxoft.Combinations.Domain.Configurations;

namespace Luxoft.Combinations.Domain.Infrastructure
{
  public class OutputFileWriter : IOutputWriter
  {
    private string _file;

    private OutputFileWriter()
    {
    }

    public OutputFileWriter(string file)
    {
      _file = file;
    }

    public bool IsValid()
    {
      var directoryName = string.Empty; ///Current Executable Directory

      try
      {
        directoryName = Path.GetDirectoryName(_file);
      }
      catch (ArgumentException exp)
      {
        Log.Instance.Debug(exp, "Invalid Argument Path! - {0}", _file);
        return false;
      }
      catch (PathTooLongException exp)
      {
        Log.Instance.Debug(exp, "Too Long Path! - {0}", _file);
        return false;
      }

      if (string.IsNullOrEmpty(directoryName))
        return true;

      return Directory.Exists(directoryName);
    }

    public bool Write(OutputSet output)
    {
      if (!IsValid())
        return false;

      if (!IsValidOutput(output))
        return false;

      try
      {
        File.WriteAllLines(_file, output.Result);
      }
      catch (Exception exp)
      {
        Log.Instance.Debug(exp, "Failed to write output into file - {0}", _file);
        return false;
      }

      return true;
    }

    private bool IsValidOutput(OutputSet output)
    {
      if (output == null)
        return false;
      if (output.Result == null)
        return false;

      return true;
    }
  }
}
