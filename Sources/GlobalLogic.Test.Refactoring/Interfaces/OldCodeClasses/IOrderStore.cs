using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses
{
    public interface IOrderStore
    {
        List<Order> GetOrders();
    }
}
