using clean_arch.Application.Order.DTOs;
using clean_arch.Domain.Order.Repository;

namespace clean_arch.Application.Order.Services;

public class OrderService :IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void AddOrder(OrderDto command)
    {
        var order = new Domain.Order.Order(command.ProductId, command.Count, command.Price);
        _repository.Add(order);
        _repository.SaveChanges();
    }

    public void FinallyOrder(FinallyOrderDto command)
    {
        var order = _repository.GetById(command.OrderId);
        order.Finally();
        _repository.Update(order);
        _repository.SaveChanges();
    }

    public OrderDto GetOrderById(long Id)
    {
        var order=  _repository.GetById(Id);
        return new OrderDto
        {
            Count = order.Count,
            Id = order.Id,
            Price = order.Price,
            ProductId = order.ProductId
        };
      
      
    }

    public List<OrderDto> GetOrders()
    {
        var orders = _repository.GetList();
        return orders.Select(x => new OrderDto
        {
            Count = x.Count,
            Id = x.Id,
            Price = x.Price,
            ProductId = x.ProductId
        }).ToList();
    }
}