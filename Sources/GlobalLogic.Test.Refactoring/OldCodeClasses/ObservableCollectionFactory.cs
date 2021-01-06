using System.Collections.ObjectModel;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class ObservableCollectionFactory : IObservableCollectionFactory
    {
        public ObservableCollection<T> GetCollection<T>() => new ObservableCollection<T>();
    }
}
