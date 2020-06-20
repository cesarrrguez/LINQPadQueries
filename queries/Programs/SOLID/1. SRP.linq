<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// SRP (Single Responsibility Principle)
// -------------------------------------------------
// A class should only have a single responsibility.
// -------------------------------------------------

void Main()
{
    string email = "cesar.rrguez@gmail.com";
    string password = "MyPassword";
    
    // Not SRP
    var userService = new UserService(new UserRepository());
    userService.RegisterNewUser(email, password);
    
    // SRP
    var userService_SRP = new UserService_SRP(new UserRepository());
    userService_SRP.RegisterNewUser(email, password);
}

public class User
{
    public string Email {get; set;}
    public string Password {get; set;}
}

public interface IUserRepository
{
    void Add(User user);
}

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
        Console.WriteLine($"User registered\n-----------------\nEmail: {user.Email}\nPassword: {user.Password})\n");
    }
}

// Not SRP
// -----------------------------------
public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void RegisterNewUser(string email, string password)
    {
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        var encriptedPassword = Convert.ToBase64String(inArray);
    
        var user = new User
        {
            Email = email, 
            Password = encriptedPassword
        };
        
        _userRepository.Add(user);
    }
}

// SRP
// -----------------------------------
public class PasswordEncrypter
{
    public static string Encrypt(string password)
    {
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        
        return Convert.ToBase64String(inArray);
    }
}

public class UserService_SRP
{
    private readonly IUserRepository _userRepository;
    
    public UserService_SRP(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void RegisterNewUser(string email, string password)
    {
        var encriptedPassword = PasswordEncrypter.Encrypt(password);
    
        var user = new User
        {
            Email = email, 
            Password = encriptedPassword
        };
        
        _userRepository.Add(user);
    }
}