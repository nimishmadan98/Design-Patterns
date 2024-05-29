namespace Abstract_Factory_Method;
/*
The Abstract Factory pattern is a creational design pattern that provides an interface for creating families of related 
or dependent objects without specifying their concrete classes. This pattern is useful when a system needs to be 
independent of how its objects are created, composed, and represented, and it helps ensure that a family of related 
objects is used together.
*/

interface IButton{
    void Render();
}

interface ITextField{
    void Render();
}

class WindowsButton: IButton{
    public void Render(){
        Console.WriteLine("Windows Button Rendered!!");
    }
}

class WindowsTextField: ITextField{
    public void Render(){
        Console.WriteLine("Windows TextField Rendered!!");
    }
}

class MacButton: IButton{
    public void Render(){
        Console.WriteLine("Mac Button Rendered!!");
    }
}

class MacTextField: ITextField{
    public void Render(){
        Console.WriteLine("Mac TextField Rendered!!");
    }
}

interface IUIFactory{
    IButton CreateButton();
    ITextField CreateTextField();
}

class MacUIFactory: IUIFactory{
    public IButton CreateButton(){
        return new MacButton();
    }
    public ITextField CreateTextField(){
        return new MacTextField();
    }
}

class WindowsUIFactory: IUIFactory{
    public IButton CreateButton(){
        return new WindowsButton();
    }
    public ITextField CreateTextField(){
        return new WindowsTextField();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IUIFactory factory = new WindowsUIFactory();
        IButton button = factory.CreateButton();
        ITextField textField = factory.CreateTextField();
        button.Render();
        textField.Render();

        factory = new MacUIFactory();
        button = factory.CreateButton();
        textField = factory.CreateTextField();
        button.Render();
        textField.Render();

    }
}
