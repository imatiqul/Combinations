using NLog;

namespace Luxoft.Combinations.Domain.Configurations
{
  public static class Log
  {
    public static Logger Instance { get; private set; }
    static Log()
    {
      LogManager.ReconfigExistingLoggers();
      Instance = LogManager.GetCurrentClassLogger();
    }
  }
}
