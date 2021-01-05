using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.OldCodeClasses;

namespace GlobalLogic.Test.Refactoring.Interfaces
{
    public interface IOrderStore
    {
        List<Order> GetOrders();
    }
}
