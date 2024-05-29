namespace Factory_Method;
/*
CREATIONAL DESIGN PATTERN
The Factory Method pattern is a creational design pattern that provides an interface for creating objects in a
superclass but allows subclasses to alter the type of objects that will be created. 
This pattern enables a class to delegate the responsibility of object instantiation to its subclasses,
promoting loose coupling and scalability."
*/

interface ILogger{
    void Log(string message);
}

class FileLogger: ILogger{
    public void Log(string message){
        Console.WriteLine($"Logging to file: {message}");
    }
}

class DBLogger: ILogger{
    public void Log(string message){
        Console.WriteLine($"Logging to DB: {message}");
    }
}


interface ILoggerFactory{
    ILogger CreateLogger();
}

class FileLoggerFactory: ILoggerFactory{
    public ILogger CreateLogger(){
        return new FileLogger();
    }
}

class DBLoggerFactory: ILoggerFactory{
    public ILogger CreateLogger(){
        return new DBLogger();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ILoggerFactory factory = new FileLoggerFactory();
        ILogger logger = factory.CreateLogger();
        logger.Log("Log will be printed to File!!");

        factory = new DBLoggerFactory();
        logger = factory.CreateLogger();
        logger.Log("Log will be printed to DB!!");
    }
}
