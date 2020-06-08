<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var iterations = 10;
var stopwatch = new Stopwatch();
var beginSection = new string(Enumerable.Repeat('-', 40).ToArray());

"1) For Loop".Dump();
beginSection.Dump();
stopwatch.Start();
for (var i = 0; i < iterations; i++)
{
	Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
	Thread.Sleep(10);
}
stopwatch.Stop();
$"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds".Dump();

"\n2) Parallel For Loop".Dump();
beginSection.Dump();
stopwatch.Restart();
Parallel.For(0, iterations, i =>
{
	Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
    Thread.Sleep(10);
});
stopwatch.Stop();
$"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds".Dump();