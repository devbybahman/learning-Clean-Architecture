namespace clean_arch.Domain.Order;

public class Order
{
   

    public long Id { get; private set; }
    public Guid ProductId { get;private set; }
    public int Count { get;private set; }
    public int  Price { get;private set; }
    public int  TotalPrice => Count * Price;
    public bool IsFinally { get;private set; }
    public DateTime FinallyData { get;private set; }
    public Order( Guid productId, int count, int price)
    {
        if (price <= 0)
        {
            throw new ArgumentNullException("price");
        }
        if (count<1)
        {
            throw new ArgumentException("count must be greater than 0");
        }
        ProductId = productId;
        Count = count;
        Price = price;
    }

    public void IncreaseProductCount(int count)
    {
        if (count<1)
        {
            throw new ArgumentException("count must be greater than 0");
        }
        Count = +count;

    }
    public void Finally()
    {
        IsFinally = true;
        FinallyData = DateTime.Now;
        
    }
}