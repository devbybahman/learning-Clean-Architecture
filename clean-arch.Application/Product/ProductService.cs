using clean_arch.Application.Product.DTOs;
using clean_arch.Domain.Product.Repository;

namespace clean_arch.Application.Product;

public class ProductService :IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void AddProduct(AddProductDto command)
    {
        _repository.Add(new Domain.Product.Product(command.Title,command.Price));
        _repository.SaveChanges();
    }

    public void EditProduct(EditProductDto command)
    {
        var product= _repository.GetById(command.Id);
        product.Edit(command.Title,command.Price);
        _repository.Update(product);
        _repository.SaveChanges();
    }

    public ProdctDto GetProductById(Guid id)
    {
       var product=_repository.GetById(id);
       return new ProdctDto()
       {
           Id = product.Id,
           Price = product.Price.value,
           Title = product.Title
       };
    }

    public List<ProdctDto> GetAllProducts()
    {
        var orders = _repository.GetList();
        return orders.Select(x => new ProdctDto()
        {
            Title = x.Title,
            Id = x.Id,
            Price = x.Price.value
           
        }).ToList();
    }
}