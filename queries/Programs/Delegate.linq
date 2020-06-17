<Query Kind="Program" />

public delegate bool FilterDelegate(Person person);

void Main()
{
    // Create 4 Person objects
    Person person1 = new Person() { Name = "John", Age = 41 };
    Person person2 = new Person() { Name = "Jane", Age = 69 };
    Person person3 = new Person() { Name = "Jake", Age = 12 };
    Person person4 = new Person() { Name = "Jessie", Age = 25 };
    
    // Create a list of Person objects and fill it
    List<Person> people = new List<Person>() { person1, person2, person3, person4 };
    
    // Invoke DisplayPeople using appropriate delegate
    PersonUtil.DisplayPeople("Children:", people, PersonUtil.IsChild);
    PersonUtil.DisplayPeople("Adults:", people, PersonUtil.IsAdult);
    PersonUtil.DisplayPeople("Seniors:", people, PersonUtil.IsSenior);
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class PersonUtil
{
    public static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
    {
        title.Dump();

        foreach (Person person in people)
        {
            if (filter(person))
			{
                person.Dump();
            }
        }
    }

    public static bool IsChild(Person person)
    {
        return person.Age < 18;
    }

    public static bool IsAdult(Person person)
    {
        return person.Age >= 18;
    }

    public static bool IsSenior(Person person)
    {
        return person.Age >= 65;
    }
}
