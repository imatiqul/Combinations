using Luxoft.Combinations.Domain.DTO;

namespace Luxoft.Combinations.Domain.Interfaces
{
  public interface IInputReader : IValidator
  {
    InputSet Read();
  }
}
