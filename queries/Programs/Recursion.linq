<Query Kind="Program" />

void Main()
{
    Factorial(5).Dump();
    Fibonacci(20).Dump();
}


public static double Factorial(int number)
{
    if (number == 0)
        return 1;
    else
        return number * Factorial(number - 1);
}


public static double Fibonacci(int number)
{
    if (number <= 1)
        return number;
    else
        return Fibonacci(number - 1) + Fibonacci(number - 2);
}
 