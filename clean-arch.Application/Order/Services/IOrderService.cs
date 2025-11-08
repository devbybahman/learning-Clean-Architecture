using clean_arch.Application.Order.DTOs;

namespace clean_arch.Application.Order.Services;

public interface IOrderService 
{
    void AddOrder(OrderDto command);
    void FinallyOrder(FinallyOrderDto command);
    OrderDto GetOrderById(long Id);
    List<OrderDto> GetOrders();
}