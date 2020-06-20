<Query Kind="Program" />

void Main()
{
    var listOfObjects = new List<MyObject>
    {
        new MyObject{Property="4CB8901"},
        new MyObject{Property="4CJ4601"},
        new MyObject{Property="4EN0001"},
        new MyObject{Property="4EZ7601"},
    };
    
    foreach (var item in listOfObjects)
    {
        listOfObjects.IndexOf(item).Dump();
    }
}

public class MyObject
{
    public string Property { get; set; }
}