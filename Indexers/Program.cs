IndexerClass indexerClass = new IndexerClass();
Console.WriteLine("Using indexator with int params : ");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(indexerClass[i]);
}


Console.WriteLine("Using indexators with string params: ");
foreach (var item in Enum.GetNames(typeof(Numbers)))
{
    Console.WriteLine(indexerClass[item]);
}


interface IIndexer
{
    string this[int index]
    {
        get;
        set;
    }
    string this[string name]
    {
        get;
    }
}
enum Numbers { one, two, three, four, five }
class IndexerClass : IIndexer
{
    string[]names1 = new string[5];
    public IndexerClass()
    {
        this[0] = "Bob";
        this[1] = "Candy";
        this[2] = "John";
        this[3] = "Jack";
        this[4] = "Jimmi";
    }
    public string this[int index] 
    { 
        get
        {
            return names1[index];
        } 
        set
        {
            names1[index] = value;
        }
    }

    public string this[string name]
    {
        get
        {
            if (Enum.IsDefined(typeof(Numbers), name))
                return names1[(int)Enum.Parse(typeof(Numbers), name)];
            else
                return "";
        }
    }
}