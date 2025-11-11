namespace clean_arch.Domain.Shared;

public class Money
{
    /// <summary>
    /// Rial
    /// </summary>
    public int value { get;  }

    public Money(int rialValue)
    {
        if (rialValue<0)
            throw new InvalidDataException();
        
        this.value = rialValue;

    }

    public static Money FromRial(int value)
    {
        return new Money(value);
    }

    public static Money FromTooman(int value)
    {
        return new Money(value/10);
    }

    public static Money operator +(Money a, Money b)
    {
        return new Money(a.value + b.value);
    }
    public static Money operator -(Money a, Money b)
    {
        return new Money(a.value - b.value);
    }
    public static bool operator ==(Money a, Money b)
    {
       return a.value==b.value;
    }
    public static bool operator !=(Money a, Money b)
    {
        return a.value!=b.value;
    }
}