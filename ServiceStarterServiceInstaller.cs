using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ServiceStarter
{
  [RunInstaller(true)]
  public class ServiceStarterServiceInstaller : Installer
  {
    public ServiceStarterServiceInstaller()
    {
      var serviceProcessInstaller = new ServiceProcessInstaller();
      var serviceInstaller = new ServiceInstaller();

      //# Service Account Information
      serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
      serviceProcessInstaller.Username = null;
      serviceProcessInstaller.Password = null;

      //# Service Information
      serviceInstaller.DisplayName = "ServiceStarter";
      serviceInstaller.StartType = ServiceStartMode.Automatic;

      //# This must be identical to the WindowsService.ServiceBase name
      //# set in the constructor of WindowsService.cs
      serviceInstaller.ServiceName = "ServiceStarter";

      Installers.Add(serviceProcessInstaller);
      Installers.Add(serviceInstaller);
    }
  }
}