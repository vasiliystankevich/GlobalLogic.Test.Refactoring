using System.Collections.Generic;
using System.Collections.ObjectModel;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses
{
    public interface IOrderFilter
    {
        ObservableCollection<Order> WriteOutFilterdAndPriceSortedOrders(List<Order> orders, int size);
    }
}
