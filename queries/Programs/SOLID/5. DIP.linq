<Query Kind="Program" />

// DIP (Dependency Inversion Principle)
// -------------------------------------------
// Depend on abstractions, not on concretions.
// -------------------------------------------

void Main()
{
    string data = "Some data";
    
    // Not DIP
    var logic = new Logic();
    logic.RegisterData(data);
    
    // DIP
    //var db = new MySqlDatabase();
    var db = new OracleDatabase();
    var logic_DIP = new Logic_DIP(db);
    
    logic_DIP.RegisterData(data);
}

// Not DIP
// -----------------------------------
public class MongoDB
{
    public void Add(string data)
    {
        Console.WriteLine($"Data \"{data}\" added to MongoDB database");
    }
}

public class Logic
{
	private readonly MongoDB _database;
	
	public Logic()
    {
        _database = new MongoDB();
	}
    public void RegisterData(string data) {
		_database.Add(data);
    }
}

// DIP
// -----------------------------------
public interface IDatabase
{
    void Add(string data);
}

public class MySqlDatabase : IDatabase 
{
    public void Add(string data)
    {
        Console.WriteLine($"Data \"{data}\" added to MySQL database");
    }
}

public class OracleDatabase : IDatabase 
{
    public void Add(string data)
    {
        Console.WriteLine($"Data \"{data}\" added to Oracle database");
    }
}

public class Logic_DIP
{
	private readonly IDatabase _database;
	
	public Logic_DIP(IDatabase database)
    {
        _database = database;
	}
	
    public void RegisterData(string data) {
		_database.Add(data);
    }
}