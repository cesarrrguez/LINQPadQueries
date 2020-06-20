<Query Kind="Program" />

// LSP (Liskov Substitution Principle)
// -------------------------------------------------------------
// Derived classes must be substitutable for their base classes.
// -------------------------------------------------------------

void Main()
{
    // Not LSP
    var duck = new Duck();
    var rubberDuck = new RubberDuck();

    duck.Fly();
    rubberDuck.Fly();
    
    // LSP
    var duck_LSP = new Duck_LSP();
    var rubberDuck_LSP = new RubberDuck_LSP();
    
    duck_LSP.Fly();
}

// Not LSP
// ----------------------------------
public class Duck
{
    public virtual void Fly() => Console.WriteLine("Fly");
    public virtual void Swim() => Console.WriteLine("Swim");
    public virtual void Cuack() => Console.WriteLine("Cuack");
}

public class RubberDuck : Duck
{
    public override void Fly() => throw new Exception();
}

// LSP
// ----------------------------------
public interface IFly
{
    void Fly();
}

public interface ISwim
{
    void Swim();
}

public interface ICuack
{
    void Cuack();
}

public class Duck_LSP : IFly, ISwim, ICuack
{
    public void Fly() => Console.WriteLine("Fly");
    public void Swim() => Console.WriteLine("Swim");
    public void Cuack() => Console.WriteLine("Cuack");
}

public class RubberDuck_LSP : ISwim, ICuack
{
    public void Swim() => Console.WriteLine("Swim");
    public void Cuack() => Console.WriteLine("Cuack");
}