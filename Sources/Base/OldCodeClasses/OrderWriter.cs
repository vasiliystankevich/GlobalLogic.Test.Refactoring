using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.OldCodeClasses.Interfaces;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class OrderWriter : IOrderWriter
    {
        public void WriteOrders(IEnumerable<Order> orders)
        {
        }
    }
}
