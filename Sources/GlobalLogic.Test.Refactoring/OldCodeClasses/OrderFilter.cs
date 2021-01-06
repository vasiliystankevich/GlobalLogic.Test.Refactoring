using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{


    public class OrderFilter : IOrderFilter
    {
        public ObservableCollection<Order> WriteOutFilterdAndPriceSortedOrders(List<Order> orders, int size)
        {
            var result = new ObservableCollection<Order>();
            var queryFilteredOrders = orders.Where(order => order.Size > size).OrderBy(o => o.Price).AsQueryable();
            var filteredOrders = ToShowQuery(queryFilteredOrders);
            filteredOrders.ForEach(result.Add);
            return result;
        }

        List<Order> ToShowQuery(IQueryable<Order> query) => (query.Any() ? query : Enumerable.Empty<Order>()).ToList();
    }
}