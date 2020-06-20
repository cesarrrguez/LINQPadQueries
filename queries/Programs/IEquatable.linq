<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

void Main()
{
    var listOfObjects = new List<MyObject>();
    
    listOfObjects.Add(new MyObject{Property1 = 1, Property2 = 1, Property3 = 1});
    listOfObjects.Add(new MyObject{Property1 = 1, Property2 = 2, Property3 = 3});
    listOfObjects.Add(new MyObject{Property1 = 1, Property2 = 1, Property3 = 1});
    
    foreach (var item in listOfObjects.Distinct())
	{
        item.Dump();
    }
}

public class MyObject : IEquatable<MyObject>
{
    public int Property1 { get; set; }
    public int Property2 { get; set; }
    public int Property3 { get; set; }
    
    public bool Equals(MyObject other)
    {
        return Property1 == other?.Property1 && Property2 == other?.Property2 && Property3 == other?.Property3;
    }

    public override int GetHashCode()
    {
        return Property1.GetHashCode() ^ Property2.GetHashCode() ^ Property3.GetHashCode();
    }
}