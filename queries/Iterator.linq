<Query Kind="Statements" />

IEnumerable<int> Fibonacci()
{
    int a = 0;
    int b = 1;
    int c;

    while(true)
    {
        yield return a;
        c = a + b;
        a = b;
        b = c;
    }
}
		
IEnumerable<int> fibo = Fibonacci().Take(5);

foreach (int i in fibo)
	i.Dump();
