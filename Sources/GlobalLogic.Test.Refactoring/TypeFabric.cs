using GlobalLogic.Test.Refactoring.Interfaces;
using Project.Kernel;
using Unity;
using Unity.Lifetime;

namespace GlobalLogic.Test.Refactoring
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterFactory<Settings>(unityContainer => Settings.Load("settings.json"),
                new SingletonLifetimeManager());
            container.RegisterType<ILogic, Logic>();
            container.RegisterType<IStartup, Startup>();
        }
    }
}