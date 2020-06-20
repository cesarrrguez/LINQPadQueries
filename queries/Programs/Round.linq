<Query Kind="Program" />

void Main()
{
    MyRound(535).Dump();
}

private static int MyRound(int n)
{
    // Smaller multiple 
    int a = (n / 10) * 10;

    // Larger multiple 
    int b = a + 10;

    // Return of closest of two 
    return (n - a > b - n) ? b : a;
}