using System;

namespace Luxoft.Combinations.Domain.Interfaces
{
  public interface ICombinationGenerator : IDisposable
  {
    void Generate();
  }
}
