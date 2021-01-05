namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class OrderManager
    {
        public OrderManager(IOrderStore orderStore)
        {
            this.orderStore = orderStore;
        }

        private readonly IOrderStore orderStore;

        public void WriteOutSmallOrders()
        {
            var orders = orderStore.GetOrders();
            SmallOrderFilter filter = new SmallOrderFilter(new OrderWriter(), orders);
            filter.WriteOutFiltrdAndPriceSortedOrders(new OrderWriter());
        }

        public void WriteOutLargeOrders()
        {
            var orders = orderStore.GetOrders();
            LargeOrderFilter filter = new LargeOrderFilter(new OrderWriter(), orders);
            filter.WriteOutFiltrdAndPriceSortedOrders(new OrderWriter());
        }
    }
}
