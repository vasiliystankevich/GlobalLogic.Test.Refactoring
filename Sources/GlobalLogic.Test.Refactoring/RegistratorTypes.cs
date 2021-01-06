using GlobalLogic.Test.Refactoring.Interfaces;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;
using GlobalLogic.Test.Refactoring.OldCodeClasses;
using Project.Kernel;
using Project.Kernel.Interfaces.Unity;

namespace GlobalLogic.Test.Refactoring
{
    public class RegistratorTypes:BaseRegistratorTypes
    {
        public RegistratorTypes(IUnityContainerExecutor executor) : base(executor)
        {
        }

        public override void RegisterAll()
        {
            Executor.RegisterSingletonFactory<ISettingsLoader>(executor => new SettingsLoader())
                    .RegisterSingletonFactory<Settings>(executor =>
                    {
                        var loader = executor.Resolve<ISettingsLoader>();
                        return loader.Load("settings.json");
                    })
                    .RegisterSingletonFactory<IObservableCollectionFactory>(executor => new ObservableCollectionFactory())
                    .RegisterType<IOrderStore, OrderStore>()
                    .RegisterType<IOrderWriter, OrderWriter>()
                    .RegisterType<IOrderFilter, OrderFilter>()
                    .RegisterType<IStartup, Startup>();
        }
    }
}
