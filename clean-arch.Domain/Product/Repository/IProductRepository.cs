namespace clean_arch.Domain.Product.Repository;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    List<Product> GetList();
    Product GetById(Guid id);
    void SaveChanges();
}
