using System.Collections.Generic;

namespace Luxoft.Combinations.Domain.DTO
{
  public class OutputSet
  {
    public List<string> Result { get; private set; }

    public OutputSet()
    {
      Result = null;
    }

    public OutputSet(List<string> result)
    {
      Result = result;
    }
  }
}
