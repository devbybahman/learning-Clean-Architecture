namespace clean_arch.Domain.Order.Repository;

public interface IOrderRepository
{
    void Add(Order order);
    void Update(Order order);
    List<Order> GetList();
    Order GetById(long id);
    void SaveChanges();
}