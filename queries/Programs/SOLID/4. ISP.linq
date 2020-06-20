<Query Kind="Program" />

// ISP (Interface Segregation Principle)
// ------------------------------------------------------------------------------
// Many client-specific interfaces are better than one general-purpose interface.
// ------------------------------------------------------------------------------

void Main()
{
    // Not ISP
    var allInOnePrinter = new AllInOnePrinter();
    allInOnePrinter.Print();
    
    var economicPrinter = new EconomicPrinter();
    economicPrinter.Print();
    
    // ISP
    var allInOnePrinter_ISP = new AllInOnePrinter_ISP();
    allInOnePrinter_ISP.Print();
    
    var economicPrinter_ISP = new EconomicPrinter_ISP();
    economicPrinter_ISP.Print();
}

// Not ISP
// ------------------------------------
public interface ISmartDevice
{
    void Print();
    void Fax();
    void Scan();
}


public class AllInOnePrinter : ISmartDevice
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        Console.WriteLine("Fax ...");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning ...");
    }
}


public class EconomicPrinter : ISmartDevice
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        throw new NotSupportedException();
    }
    public void Scan()
    {
        throw new NotSupportedException();
    }
}

// ISP
// ------------------------------------
public interface IPrinter
{
    void Print();
}

public interface IFax
{
    void Fax();
}
public interface IScanner
{
    void Scan();
}

public class AllInOnePrinter_ISP : IPrinter, IFax, IScanner
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        Console.WriteLine("Faxing ...");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning ...");
    }
}

public class EconomicPrinter_ISP : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
}