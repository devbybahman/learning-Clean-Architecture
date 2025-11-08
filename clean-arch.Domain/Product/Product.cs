namespace clean_arch.Domain.Product;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int Price { get; private set; }

    
    public Product( string title, int price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException("title");

        }

        if (price <= 0)
        {
           throw new ArgumentNullException("price");
        }
       
        Title = title;
        Price = price;
    }

    public void Edit(string title,int price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException("title");

        }

        if (price <= 0)
        {
            throw new ArgumentNullException("price");
        }
        
        Title= title;
        Price = price;
        
    }

   
    
}