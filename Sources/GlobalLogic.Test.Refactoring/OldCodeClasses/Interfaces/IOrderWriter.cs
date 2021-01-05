using System.Collections.Generic;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses.Interfaces
{
    // These are stub interfaces that already exist in the system
    // They're out of scope of the code review
    public interface IOrderWriter
    {
        void WriteOrders(IEnumerable<Order> orders);
    }
}
