using GlobalLogic.Test.Refactoring.Interfaces;
using Project.Kernel;
using Project.Kernel.Unity;
using Unity;

namespace GlobalLogic.Test.Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = UnityConfig.GetConfiguredContainer();
            BaseTypeFabric.RegisterTypes<TypeFabric>(container);
            var startup = container.Resolve<IStartup>();
            startup.Execute(args);
        }
    }
}
