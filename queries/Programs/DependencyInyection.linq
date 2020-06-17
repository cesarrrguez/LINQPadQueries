<Query Kind="Program" />

// DI (Dependency Inyection)
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
    
    // Not dependency inyection
    var newsletterService = new NewsLetterService();
    newsletterService.SendNewsLetter(user, newsletter);
    
    // Dependency inyection
    var messageSender = Factory.CreateMessageSender();
        
    // Constructor inyection
    var newsletterServiceDI = new NewsLetterServiceDI(messageSender);
    newsletterServiceDI.SendNewsLetter(user, newsletter);
    
    // Setter inyection
    var newsletterServiceDI2 = new NewsLetterServiceDI2();
    newsletterServiceDI2.SetmessageSender(messageSender);
    newsletterServiceDI2.SendNewsLetter(user, newsletter);
    
    // Method inyection 
    var newsletterServiceDI3 = new NewsLetterServiceDI3();
    newsletterServiceDI3.SendNewsLetter(user, newsletter, messageSender);
    
    // Interface inyection
    var newsletterServiceDI4 = new NewsLetterServiceDI4();
    newsletterServiceDI4.Inject(messageSender);
    newsletterServiceDI4.SendNewsLetter(user, newsletter);
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

// Not dependency inyection
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

// Dependency inyection
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

// Constructor inyection
// ------------------------
public class NewsLetterServiceDI
{
    private readonly IMessageSender _messageSender;
    
    public NewsLetterServiceDI(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }
    
    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}

// Setter inyection
// ------------------------
public class NewsLetterServiceDI2
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

// Method inyection
// ------------------------
public class NewsLetterServiceDI3
{   
    public void SendNewsLetter(User user, Newsletter newsletter, IMessageSender messageSender)
    {
        messageSender.Send(user, newsletter.Description);
    }
}

// Interface inyection
// ------------------------
public interface ImessageSenderInjector
{
    void Inject(IMessageSender messageSender);
}

public class NewsLetterServiceDI4 : ImessageSenderInjector
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
