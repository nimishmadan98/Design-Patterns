namespace Builder_Pattern;

/*
The Builder design pattern is a creational design pattern that separates the construction of a complex object from its 
representation. This allows the same construction process to create different representations. It is especially useful 
when the creation process involves multiple steps and can vary greatly depending on the context.

Key Components of the Builder Pattern:
======================================
    Builder Interface: Declares the steps required to build the product.
    Concrete Builder: Implements the Builder interface and constructs the product's parts.
    Product: Represents the complex object being built.
    Director: Constructs an object using the Builder interface.

Step by Step Object Creation

*/

class Student{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public string PhoneNumber { get; set; }

    public override string ToString(){
        return $"Name is :{Name} Age is: {Age} Grade is: {Grade} PhoneNumber is: {PhoneNumber}";
    }
}

interface IStudentBuilder{
    void BuildName();
    void BuildAge();
    void BuildGrade();
    void BuildPhoneNumber();
    Student GetStudent();
}

class GraduateStudentBuilder: IStudentBuilder{

    private Student _student = new Student();
    public void BuildName(){
        _student.Name = "Jane";
    }

    public void BuildAge(){
        _student.Age = 12;
    }

    public void BuildGrade(){
        _student.Grade = "Third";
    }

    public void BuildPhoneNumber(){
        _student.PhoneNumber = "9988776644";
    }

    public Student GetStudent(){
        return _student;
    }
}


class UnderGraduateStudentBuilder: IStudentBuilder{

    private Student _student = new Student();
    public void BuildName(){
        _student.Name = "Lousiana";
    }

    public void BuildAge(){
        _student.Age = 34;
    }

    public void BuildGrade(){
        _student.Grade = "Second";
    }

    public void BuildPhoneNumber(){
        _student.PhoneNumber = "9988776644";
    }

    public Student GetStudent(){
        return _student;
    }
}

class StudentDirector{
    private readonly IStudentBuilder _builder;
    public StudentDirector(IStudentBuilder builder)
    {
        _builder = builder;
    }
    public void ConstructStudent(){
        _builder.BuildAge();
        _builder.BuildGrade();
        _builder.BuildName();
        _builder.BuildPhoneNumber();
    }
}


class Program
{
    static void Main(string[] args)
    {
        IStudentBuilder builder = new UnderGraduateStudentBuilder();
        StudentDirector director = new StudentDirector(builder);
        director.ConstructStudent();
        Console.WriteLine($"Undergraduate Student Details : {builder.GetStudent()}");
    }
}
