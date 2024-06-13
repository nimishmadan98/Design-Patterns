/*

The Adapter Design Pattern is a structural pattern that allows objects with incompatible interfaces to work together.
It acts as a bridge between two incompatible interfaces by wrapping one of the objects with a new interface that the
other object can work with.

Key Concepts
Target: Defines the domain-specific interface that the Client uses.
Client: Collaborates with objects that implement the Target interface.
Adaptee: An existing interface that needs adapting.
Adapter: Implements the Target interface and wraps the Adaptee object to translate the request from the Client to the Adaptee.

Real-Life Industry Example
Consider a scenario where a legacy system is used to process payments but a new system has been introduced with a different
interface. The new system needs to integrate with the old payment processing system.

*/

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
