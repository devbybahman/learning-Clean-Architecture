using clean_arch.Domain.Shared;

namespace clean_arch.Domain.Product;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Money Price { get; private set; }

    
    public Product( string title, int price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException("title");

        }
        Title = title;
        Price = Money.FromRial(price);
    }

    public void Edit(string title,int price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException("title");

        }
        Title= title;
        Price = Money.FromRial(price);
        
    }

    
   
    
}