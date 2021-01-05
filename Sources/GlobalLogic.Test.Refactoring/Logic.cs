using System;
using System.Collections.Generic;
using GlobalLogic.Test.Refactoring.Interfaces;
using GlobalLogic.Test.Refactoring.OldCodeClasses;
using GlobalLogic.Test.Refactoring.OldCodeClasses.Interfaces;

namespace GlobalLogic.Test.Refactoring
{
    public class Logic : ILogic
    {
        public Logic(Settings settings)
        {
        }
    }







    





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
