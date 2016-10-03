using System.Collections.Generic;

namespace Luxoft.Combinations.Domain.DTO
{
  public class InputSet
  {
    public uint NSize { get; private set; }
    public List<string> Words { get; private set; }

    public InputSet()
    {
      NSize = 0;
      Words = null;
    }

    public InputSet(uint nSize, List<string> words)
    {
      NSize = nSize;
      Words = words;
    }
  }
}
