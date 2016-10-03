using Luxoft.Combinations.Domain.Configurations;
using Luxoft.Combinations.Domain.DTO;
using Luxoft.Combinations.Domain.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace Luxoft.Combinations.Domain.Infrastructure
{
  public class InputFileReader : IInputReader
  {
    private string _file;
    
    private InputFileReader()
    {
    }

    public InputFileReader(string file)
    {
      _file = file;
    }

    public bool IsValid()
    {
      return File.Exists(_file);
    }

    public InputSet Read()
    {
      var input = new InputSet();

      if (!IsValid())
        return null;

      var lines = new string[AppSettings.MAX_LINES];

      try
      {
        using (var reader = File.OpenText(_file))
        {
          int x = 0;
          while (!reader.EndOfStream)
          {
            lines[x] = reader.ReadLine();
            x += 1;

            if (x >= AppSettings.MAX_LINES)
              break;
          }
        }
      }
      catch (Exception exp)
      {
        Log.Instance.Debug(exp, "Failed to read input file - {0}", _file);
        return null;
      }

      var isValidInputLines = lines.Length == 2 && !string.IsNullOrEmpty(lines[0]) && !string.IsNullOrEmpty(lines[1]);
      if (!isValidInputLines)
        return null;

      uint nSize = 0;
      uint.TryParse(lines[0], out nSize);

      var words = lines[1].Split(char.Parse(AppSettings.WORD_SEPERATOR)).ToList();
      if (words.Count > 0)
      {
        input = new InputSet(nSize, words);
      }

      return input;
    }

  }
}
