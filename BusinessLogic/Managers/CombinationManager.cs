using Luxoft.Combinations.Domain.Configurations;
using Luxoft.Combinations.Domain.DTO;
using Luxoft.Combinations.Domain.Interfaces;
using System.Collections.Generic;

namespace BusinessLogic.Managers
{
  public class CombinationManager : ICombinationManager
  {
    private InputSet _input;

    public CombinationManager(InputSet input)
    {
      _input = input;
    }

    public bool IsValid()
    {
      if (_input == null)
        return false;
      if (_input.Words == null)
        return false;
      return true;
    }

    public OutputSet Execute()
    {
      var output = new OutputSet();

      if (!IsValid())
        return null;

      var words = _input.Words;
      var n = _input.NSize;
      var result = new List<string>();

      for (int counter = 0; counter < (1 << words.Count); ++counter)
      {
        List<string> combination = new List<string>();
        for (int i = 0; i < words.Count; ++i)
        {
          if ((counter & (1 << i)) == 0)
          {
            combination.Add(words[i]);
          }

          if (combination.Count == n)
            break;
        }

        var word = string.Join(AppSettings.WORD_SEPERATOR, combination);
        combination.Reverse();
        var reverseWord = string.Join(AppSettings.WORD_SEPERATOR, combination);
        if (!string.IsNullOrEmpty(word) && !result.Contains(word) && !result.Contains(reverseWord) && !(combination.Count > 1 && reverseWord == word))
        {
          result.Add(word);
        }
      }

      output = new OutputSet(result);
      return output;
    }

    public void Dispose()
    {
      _input = null;
    }
  }
}
