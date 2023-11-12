IManager director = new Director()
{
    LastName = "Ivanov",
    FirstName = "Ivan",
    BirthDay = new DateTime(1990, 10, 12),
    Position = "Director",
    Salary = 50000
};
Administrator admin = new Administrator()
{
    LastName = "Petrov",
    FirstName = "Petro",
    BirthDay = new DateTime(1994, 10, 12),
    Position = "Director",
    Salary = 35000
};
Console.WriteLine(admin);
Console.WriteLine(director);

IWorkable seller = new Seller()
{
    LastName = "Pavluyk",
    FirstName = "Pavlo",
    BirthDay = new DateTime(1993, 07, 20),
    Position = "Seller",
    Salary = 25000
};
Console.WriteLine(seller);
Console.WriteLine("******************************");
if(seller is Seller)
{
    Console.WriteLine((seller as Seller).Salary);
}


director.listOfWorkers = new List<IWorkable>
{ 
    seller, 
    admin,
    new Cashier
    {
        LastName = "Ivanchenko",
        FirstName = "Irina",
        BirthDay = new DateTime(1998, 7, 21),
        Position = "Cashier",
        Salary = 18000
    }
};
Console.WriteLine("---------------------------------");
foreach (IWorkable item in director.listOfWorkers)
{
    Console.WriteLine(item);
    if (item.IsWorking)
    {
        Console.WriteLine(item.Work());
    }
    Console.WriteLine();
    if(item is Cashier)
    {
        Console.WriteLine("I found a cashier");
    }
}

class MyClass
{
    public string Name { get; set; }
    string FullName { get; }
    //string Email { set; }
}
interface IPerson
{
    string Name { get; set; }
    string FullName { get; }
    string Email { set; }
}

abstract public class IWorker
{
    bool IsWorking { get; set; }
    public virtual void Work()
    {
    }
    event EventHandler workEnded;

}
class Human
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }

    public override string ToString()
    {
        return $"FirstName : {FirstName}\nLastName : {LastName}\nDate of Birth {BirthDay.ToShortDateString()}";
    }
}

class Employee:Human
{
    public int Salary { get; set; }
    public string Position { get; set; }
    public override string ToString()
    {
        return base.ToString() +$"\nPosition : {Position}\nSalary: {Salary}";
    }
}

interface IWorkable
{
    bool IsWorking { get; }
    string Work();
}

interface IManager
{
    List<IWorkable> listOfWorkers { get; set; }
    void Organize();
    void MakeBudget();
    void Control();
}

class Director : Employee, IManager
{
    public List<IWorkable> listOfWorkers { get; set; }

    public void Control()
    {
        Console.WriteLine("Controling work"); ;
    }

    public void MakeBudget()
    {
        Console.WriteLine("Making budget"); ;
    }

    public void Organize()
    {
        Console.WriteLine("Organazing work"); ;
    }
}
class Seller : Employee, IWorkable
{
    public bool isWorking =true;

    public bool IsWorking
    {
        get { return isWorking; }
    }

    public string Work()
    {
       return $"Selling Products";
    }
}

class Cashier : Employee, IWorkable
{
    public bool isWorking = true;

    public bool IsWorking
    {
        get { return isWorking; }
    }

    public string Work()
    {
        return $"Getting pay for product";
    }
}
class Security : Employee, IWorkable
{
    public bool isWorking = true;

    public bool IsWorking
    {
        get { return isWorking; }
    }

    public string Work()
    {
        return $"Secure shop";
    }
}
class Administrator : Employee, IWorkable, IManager
{
    private bool isWorking =true;
    public bool IsWorking { get
        {
            return isWorking;
        }
    }

    public List<IWorkable> listOfWorkers { get ; set ; }

    public void Control()
    {
        Console.WriteLine("I`m a boss. I controling workers"); ;
    }

    public void MakeBudget()
    {
        Console.WriteLine("Trying to make a budget") ;
    }

    public void Organize()
    {
        Console.WriteLine("Oragize all of work");
    }

    public string Work()
    {
        return $"I`m working hard";
    }
}