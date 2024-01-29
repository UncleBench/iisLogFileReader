using IisLogFileParser;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Api
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();
      container.RegisterType<ILogFileParser, LogFileParser>(new ContainerControlledLifetimeManager());

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
  }
}
