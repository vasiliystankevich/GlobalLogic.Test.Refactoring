using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;
using Unity.Interception.Utilities;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{


    public class OrderFilter : IOrderFilter
    {
        public OrderFilter(IOrderWriter orderWriter)
        {
            OrderWriter = orderWriter;
        }

        public void WriteOutFilterdAndPriceSortedOrders(List<Order> orders, int size)
        {
            var observableCollection = new ObservableCollection<Order>();
            var queryFilteredOrders = orders.Where(order => order.Size > size).ToList();
            var filteredOrders = queryFilteredOrders.Any() ? queryFilteredOrders : Enumerable.Empty<Order>().ToList();
            filteredOrders.OrderBy(o => o.Price).ForEach(observableCollection.Add);
            OrderWriter.WriteOrders(observableCollection);
        }

        IOrderWriter OrderWriter { get; }
    }
}