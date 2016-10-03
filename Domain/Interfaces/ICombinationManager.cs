using Luxoft.Combinations.Domain.DTO;
using System;

namespace Luxoft.Combinations.Domain.Interfaces
{
  public interface ICombinationManager : IValidator, IDisposable
  {
    OutputSet Execute();
  }
}
