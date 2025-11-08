namespace clean_arch.Contracts;

public interface ISmsService
{
    void SendSms(SmsBody smsBody);
}

public class SmsBody
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}