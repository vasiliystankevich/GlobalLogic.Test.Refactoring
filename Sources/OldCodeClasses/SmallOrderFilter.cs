using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class SmallOrderFilter : LargeOrderFilter
    {
        public SmallOrderFilter(IOrderWriter orderWriter, List<Order> orders)
            : base(orderWriter, orders)
        {
            filterSize = "10";
        }
    }
}
