using System.Collections.ObjectModel;

namespace GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses
{
    public interface IObservableCollectionFactory
    {
        ObservableCollection<T> GetCollection<T>();
    }
}
