using clean_arch.Domain.Order.Repository;

namespace clean_arch.Infrastructure.Persistent.EF.Order;

public class OrderRepository :IOrderRepository
{
  
    public void Add(Domain.Order.Order order)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Order.Order order)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Order.Order> GetList()
    {
        throw new NotImplementedException();
    }

    public Domain.Order.Order GetById(long id)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }
}