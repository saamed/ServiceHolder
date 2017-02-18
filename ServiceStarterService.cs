using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;

namespace ServiceStarter
{
  public class ServiceStarterService : ServiceBase
  {
    private static List<Process> _processes;

    public ServiceStarterService()
    {
      _processes = new List<Process>();

      ServiceName = "ServiceStarter";
      CanStop = true;
      CanPauseAndContinue = false;
    }

    static void Main(string[] args)
    {
      Run(new ServiceStarterService());
    }

    protected override void OnStart(string[] args)
    {
      var config = ServicesToRunSection.GetConfig();

      var data = config.ServiceEntryCollection;

      foreach (ServiceEntry entry in data)
      {
        var process = Process.Start(entry.Path, entry.Params);
        _processes.Add(process);
      }
    }

    protected override void OnStop()
    {
      foreach (var process in _processes)
      {
        if (!process.HasExited)
          process.Close();
      }

      _processes.Clear();
    }
  }
}