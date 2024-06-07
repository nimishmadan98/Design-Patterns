namespace Singelton_Pattern;

/*
The Singleton pattern is a design pattern that restricts the instantiation of a class to one single instance. 
This is useful when exactly one object is needed to coordinate actions across the system. The Singleton pattern 
ensures that a class has only one instance and provides a global point of access to that instance.
*/

public class Logger{

    private static Logger _instance;

    private static readonly object _lock = new object();

    private Logger(){

    }

    public static Logger Instance
    {
        get 
        { 
            if(_instance == null){
                lock(_lock){
                    if(_instance == null){
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
        
    }
    
    public void Log(string message){
        Console.WriteLine($"Log: {message}");
    }

}
class Program
{
    static void Main(string[] args)
    {
        Logger logger = Logger.Instance;
        logger.Log("First Log");
    }
}
