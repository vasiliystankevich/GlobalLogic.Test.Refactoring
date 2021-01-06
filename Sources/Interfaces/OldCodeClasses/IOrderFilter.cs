using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses
{
    public interface IOrderFilter
    {
        List<Order> WriteOutFilterdAndPriceSortedOrders(List<Order> orders, int size);
    }
}
