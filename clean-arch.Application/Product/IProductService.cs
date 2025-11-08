using clean_arch.Application.Product.DTOs;

namespace clean_arch.Application.Product;

public interface IProductService
{
    void AddProduct(AddProductDto command);
    void EditProduct(EditProductDto command);
    ProdctDto GetProductById(Guid id);
    List<ProdctDto> GetAllProducts();
}