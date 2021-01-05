using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

public class LargeOrderFilter
{
    private IOrderWriter orderWriter;
    private List<Order> orders;

    public LargeOrderFilter(IOrderWriter orderWriter, List<Order> orders)
    {
        filterSize = "100";
        this.orderWriter = orderWriter;
        this.orders = orders;
    }

    protected string filterSize;

    public void WriteOutFiltrdAndPriceSortedOrders(IOrderWriter writer)
    {
        List<Order> filteredOrders = this.FilterOrdersSmallerThan(orders, filterSize);
        Enumerable.OrderBy(filteredOrders, o => o.Price);
        ObservableCollection<Order> observableCollection =
            new ObservableCollection<Order>();
        foreach (Order o in filteredOrders)
        {
            observableCollection.Add(o);
        }
        writer.WriteOrders(observableCollection);
    }

    protected List<Order> FilterOrdersSmallerThan(List<Order> allOrders, string size)
    {
        List<Order> filtered = new List<Order>();
        for (int i = 0; i <= allOrders.Count; i++)
        {
            int number = orders[i].toNumber(size);
            if (allOrders[i].Size <= number)
            {
                continue;
            }
            else
            {
                filtered.Add(orders[i]);
            }
        }
        return filtered;
    }
}

public class SmallOrderFilter : LargeOrderFilter
{
    public SmallOrderFilter(IOrderWriter orderWriter, List<Order> orders)
        : base(orderWriter, orders)
    {
        filterSize = "10";
    }
}

public class Order
{
    public double Price
    {
        get { return this.dPrice; }
        set { this.dPrice = value; }
    }

    public int Size
    {
        get { return this.iSize; }
        set { this.iSize = value; }
    }

    public string Symbol
    {
        get { return this.sSymbol; }
        set { this.sSymbol = value; }
    }

    private double dPrice;
    private int iSize;
    private string sSymbol;

    public int toNumber(String Input)
    {
        bool canBeConverted = false;
        int n = 0;
        try
        {
            n = Convert.ToInt32(Input);
            if (n != 0) canBeConverted = true;
        }
        catch (Exception ex)
        {
        }
        if (canBeConverted == true)
        {
            return n;
        }
        else
        {
            return 0;
        }
    }
}

// These are stub interfaces that already exist in the system
// They're out of scope of the code review
public interface IOrderWriter
{
    void WriteOrders(IEnumerable<Order> orders);
}

public class OrderWriter : IOrderWriter
{
    public void WriteOrders(IEnumerable<Order> orders)
    {
    }
}

public interface IOrderStore
{
    List<Order> GetOrders();
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