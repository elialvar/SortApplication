using System.Collections.Generic;
using Microsoft.Practices.Unity;
using SortApplication.BussinessLogic;
using SortApplication.BussinessLogic.Interfaces;
using SortApplication.DataAccess;
using SortApplication.DataAccess.Interfaces;

namespace SortApplication
{
    internal class Bootstrapper
    {
        public static UnityContainer Container;

        public static void Start()
        {
            Container = new UnityContainer();
            RegisterTypes();
        }

        public static void RegisterTypes()
        {
            Container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFileHandling, FileHandling>();
            Container.RegisterType<IPersonRepository, PersonRepository>(new InjectionConstructor(new List<Person>()));
            Container.RegisterType<IConsole, ConsoleWrapper>();
            Container.RegisterType<IAppLogic, AppLogic>();
        }

        public static void Stop()
        {
            Container.Dispose();
        }
    }
}