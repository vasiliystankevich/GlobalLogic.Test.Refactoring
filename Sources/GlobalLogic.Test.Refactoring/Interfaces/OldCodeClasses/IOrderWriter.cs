using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses
{
    // These are stub interfaces that already exist in the system
    // They're out of scope of the code review
    public interface IOrderWriter
    {
        void WriteOrders(IEnumerable<Order> orders);
    }
}
