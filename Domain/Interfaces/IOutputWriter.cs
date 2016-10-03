using Luxoft.Combinations.Domain.DTO;

namespace Luxoft.Combinations.Domain.Interfaces
{
  public interface IOutputWriter : IValidator
  {
    bool Write(OutputSet output);
  }
}
