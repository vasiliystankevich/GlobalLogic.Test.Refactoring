using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class OrderWriter : IOrderWriter
    {
        public void WriteOrders(IEnumerable<Order> orders)
        {
        }
    }
}
