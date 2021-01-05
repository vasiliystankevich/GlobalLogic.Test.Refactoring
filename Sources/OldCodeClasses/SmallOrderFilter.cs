using System.Collections.Generic;

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
