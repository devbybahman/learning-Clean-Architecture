namespace clean_arch.Application.Product.DTOs;

public class EditProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
}