using System.Diagnostics;

namespace Luxoft.Combinations.Domain.Configurations
{
  public class StopWatcher
  {
    private Stopwatch watch;

    private static StopWatcher _instance;

    public static StopWatcher Instance
    {
      get
      {
        if (_instance == null)
          _instance = new StopWatcher();
        return _instance;
      }
    }

    private StopWatcher()
    {
      Start();
    }
    public void Start()
    {
      watch = Stopwatch.StartNew();
    }

    public long Stop()
    {
      if (watch.IsRunning)
        watch.Stop();
      return watch.ElapsedMilliseconds;
    }
  }
}
