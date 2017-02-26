using Microsoft.Practices.Unity;
using SortApplication.BussinessLogic.Interfaces;

namespace SortApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Start();
            
            IAppLogic appLogic = Bootstrapper.Container.Resolve<IAppLogic>();
            appLogic.Run();

            Bootstrapper.Stop();
        }
    }
}