using GlobalLogic.Test.Refactoring.Interfaces;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring
{
    public class Startup : IStartup
    {
        public Startup(Settings settings, IOrderStore orderStore, IOrderFilter orderFilter, IOrderWriter orderWriter)
        {
            Settings = settings;
            OrderStore = orderStore;
            OrderFilter = orderFilter;
            OrderWriter = orderWriter;
        }

        public void Execute(string[] args)
        {
            var orders = OrderStore.GetOrders();
            var largeResult =  OrderFilter.WriteOutFilterdAndPriceSortedOrders(orders, Settings.SizesOrderLists.Large);
            var smallResult = OrderFilter.WriteOutFilterdAndPriceSortedOrders(orders, Settings.SizesOrderLists.Small);
            OrderWriter.WriteOrders(largeResult);
            OrderWriter.WriteOrders(smallResult);
        }

        Settings Settings { get; }
        IOrderStore OrderStore { get; }
        IOrderFilter OrderFilter { get; }
        IOrderWriter OrderWriter { get; }
    }
}