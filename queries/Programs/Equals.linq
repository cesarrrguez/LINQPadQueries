<Query Kind="Program" />

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

public class MyObject
{
    public int Property1 { get; set; }
    public int Property2 { get; set; }
    public int Property3 { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (!(obj is MyObject)) return false;

        var mo = (MyObject)obj;
            
        return Property1 == mo.Property1 && Property2 == mo.Property2 && Property3 == mo.Property3;
    }

    public override int GetHashCode()
    {
        return Property1.GetHashCode() ^ Property2.GetHashCode() ^ Property3.GetHashCode();
    }
}