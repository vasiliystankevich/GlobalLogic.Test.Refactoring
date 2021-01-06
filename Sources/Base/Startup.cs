using GlobalLogic.Test.Refactoring.Interfaces;
using System;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring
{
    public class Startup : IStartup
    {
        public Startup(Settings settings, IOrderFilter orderFilter, IOrderStore orderStore)
        {
            Settings = settings;
            OrderFilter = orderFilter;
            OrderStore = orderStore;
        }

        public void Execute(string[] args)
        {
            var orders = OrderStore.GetOrders();
            OrderFilter.WriteOutFilterdAndPriceSortedOrders(orders, Settings.SizesOrderLists.Large);
            OrderFilter.WriteOutFilterdAndPriceSortedOrders(orders, Settings.SizesOrderLists.Small);
            Console.WriteLine("Press any key for exit....");
            Console.ReadKey(true);
        }

        Settings Settings { get; }
        IOrderFilter OrderFilter { get; }
        IOrderStore OrderStore { get;  }
    }
}