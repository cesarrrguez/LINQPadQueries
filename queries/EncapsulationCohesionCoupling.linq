<Query Kind="Program" />

// Encapsulation: Prevents access to implementation details
// Cohesion: Elements of a module belong together
// Coupling: Dependency and interaction between components
void Main()
{
    var sqlContext = new SqlContext();
    //var xmlContext = new XmlContext();
    
    var userRepository = new UserRepository(sqlContext);
    var user = new User();
    userRepository.Add(user);
    userRepository.Delete(user.GetId());
}

public class User {
    private Guid _id;
    
    public User() {
        _id = new Guid();
    }

    public Guid GetId() {
        return _id;
    }
    
    public override string ToString() {
        return $"Id: {_id}";
    }
}

public interface IDataContext {
    void AddRow(string table, object value);
    void DeleteRow(string table, Guid value);
}

public class SqlContext: IDataContext {
    public void AddRow(string table, object value) {
        Console.WriteLine($"{table} [{value}] added to sql database");
    }
    
    public void DeleteRow(string table, Guid value) {
        Console.WriteLine($"{table} [{value}] deleted from sql database");
    }
}

public class XmlContext: IDataContext {
    public void AddRow(string table, object value) {
        Console.WriteLine($"{table} [{value}] added to XML document");
    }
    
    public void DeleteRow(string table, Guid value) {
        Console.WriteLine($"{table} [{value}] deleted from XML document");
    }
}

public interface IRepository<T> {
    void Add(T entity);
    void Delete(Guid id);
}

public class UserRepository : IRepository<User> {
    private readonly IDataContext _dataContext;
    
    public UserRepository(IDataContext dataContext) {
        _dataContext = dataContext;
    }
    
    public void Add(User user) {
        _dataContext.AddRow(nameof(User), user);
    }
    
    public void Delete(Guid userId) {
        _dataContext.DeleteRow(nameof(User), userId);
    }
}
