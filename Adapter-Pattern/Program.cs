namespace Adapter_Pattern;

public interface IPaymentProcessor{
    void ProcessPayment(decimal amount);
}

public class LegacyPaymentProcessor{
    public void ProcessPayment(double amount){
        Console.WriteLine($"Payment of {amount} made through legacy system.");
    }
}

public class PaymentAdapter: IPaymentProcessor{
    private readonly LegacyPaymentProcessor _legacyPaymentProcessor;
    public PaymentAdapter(LegacyPaymentProcessor legacyPaymentProcessor){
        _legacyPaymentProcessor = legacyPaymentProcessor;
    }

    public void ProcessPayment(decimal amount){
        _legacyPaymentProcessor.ProcessPayment((double)amount);
    }
}

public class PaymentService{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor){
        _paymentProcessor = paymentProcessor;
    }

    public void MakePayment(decimal amount){
        _paymentProcessor.ProcessPayment(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        LegacyPaymentProcessor legacyPaymentProcessor = new LegacyPaymentProcessor();
        IPaymentProcessor paymentProcessor = new PaymentAdapter(legacyPaymentProcessor);
        PaymentService paymentService = new PaymentService(paymentProcessor);
        paymentService.MakePayment(12.12M);
    }
}
