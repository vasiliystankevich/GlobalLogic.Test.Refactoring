using Project.Kernel;
using Project.Kernel.Interfaces;
using Project.Kernel.Interfaces.Unity;
using Project.Kernel.Unity;
using Unity;
using Unity.Interception.Utilities;

namespace GlobalLogic.Test.Refactoring
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnityContainerExecutor, UnityContainerExecutor>();
            container.RegisterType<IUnityContainerFunctors, UnityContainerFunctors>();

            container.RegisterType<IRegistratorTypes, RegistratorTypes>("GlobalLogic.Test.Refactoring");

            var registrators = container.ResolveAll<IRegistratorTypes>();
            registrators.ForEach(registrator => registrator.RegisterAll());
        }
    }
}