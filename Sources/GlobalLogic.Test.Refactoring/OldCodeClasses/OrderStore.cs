using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class OrderStore : IOrderStore
    {
        public List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Price = 10,
                    Size = 1,
                    Symbol = "TShirt"
                },
                new Order
                {
                    Price = 15,
                    Size = 2,
                    Symbol = "Sport Goods"
                }
            };
        }
    }
}
