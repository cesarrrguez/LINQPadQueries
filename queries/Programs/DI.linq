<Query Kind="Program" />

// DI (Dependency Injection)
// --------------------------------------------------------
// It is a form of IoC, where implementations are passed to
// an object on which they "depend" to behave correctly.
// --------------------------------------------------------

void Main()
{
    var user = new User
    {
       Name = "César",
       Email = "cesar.rrguez@gmail.com",
       Phone = "123456789"
    };
    
    var newsletter = new Newsletter
    {
        Description = "These are the weekly progress"
    };
    
    // Not dependency injection
    var newsletterService = new NewsLetterService();
    newsletterService.SendNewsLetter(user, newsletter);
    
    // Dependency injection
    var messageSender = Factory.CreateMessageSender();
        
    // Constructor injection
    var newsletterService_DI = new NewsLetterService_DI(messageSender);
    newsletterService_DI.SendNewsLetter(user, newsletter);
    
    // Setter injection
    var newsletterService_DI2 = new NewsLetterService_DI2();
    newsletterService_DI2.SetmessageSender(messageSender);
    newsletterService_DI2.SendNewsLetter(user, newsletter);
    
    // Method injection 
    var newsletterService_DI3 = new NewsLetterService_DI3();
    newsletterService_DI3.SendNewsLetter(user, newsletter, messageSender);
    
    // Interface injection
    var newsletterService_DI4 = new NewsLetterService_DI4();
    newsletterService_DI4.Inject(messageSender);
    newsletterService_DI4.SendNewsLetter(user, newsletter);
}

public class User
{
    public string Name {get; set;}
    public string Email {get; set;}
    public string Phone {get; set;}
}

public class Newsletter
{
    public string Description {get; set;}
}

public class EmailClient
{
    public void Send(string email, string message)
    {
        Console.WriteLine($"Email sent\n------------\nTo: {email}\nMessage: {message}\n");
    }
}

// Not dependency injection
// Not IoC here. The service is who create the messageSender instance and maintane it
// --------------------------------------------------------------------------------
public class NewsLetterService
{
    private EmailClient _emailClient = new EmailClient();
    
    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _emailClient.Send(user.Email, newsletter.Description);
    }
}

// Dependency injection
// ------------------------
public interface IMessageSender
{
    void Send(User user, string message);
}

public class EmailSender : IMessageSender
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Email sent\n------------\nTo: {user.Email}\nMessage: {message}\n");
    }
}

public class SmsSender : IMessageSender
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Sms sent\n------------\nTo: {user.Phone}\nMessage: {message}\n");
    }
}

public static class Factory
{
    public static IMessageSender CreateMessageSender()
    {
        //return new EmailSender();
        return new SmsSender();
    }
}

// Constructor injection
// ------------------------
public class NewsLetterService_DI
{
    private readonly IMessageSender _messageSender;
    
    public NewsLetterService_DI(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }
    
    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}

// Setter injection
// ------------------------
public class NewsLetterService_DI2
{
    private IMessageSender _messageSender;
        
    public void SetmessageSender(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }
    
    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}

// Method injection
// ------------------------
public class NewsLetterService_DI3
{   
    public void SendNewsLetter(User user, Newsletter newsletter, IMessageSender messageSender)
    {
        messageSender.Send(user, newsletter.Description);
    }
}

// Interface injection
// ------------------------
public interface ImessageSenderInjector
{
    void Inject(IMessageSender messageSender);
}

public class NewsLetterService_DI4 : ImessageSenderInjector
{
    private IMessageSender _messageSender;
    
    public void Inject(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }
    
    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}