<Query Kind="Statements">
  <Namespace>System.Collections.Generic</Namespace>
</Query>

var list = new List<int>();

for(var i = 0; i < 10000000; i++)
    list.Add(i);

// Count() > 0
var s1 = Stopwatch.StartNew();
var r1 = list.Count() > 0;
s1.Stop();

// Count > 0
var s2 = Stopwatch.StartNew();
var r2 = list.Count > 0;
s2.Stop();

// Any()
var s3 = Stopwatch.StartNew();
var r3 = list.Any();
s3.Stop();

$"Count() = {s1.Elapsed.TotalMilliseconds}".Dump();
$"Count = {s2.Elapsed.TotalMilliseconds}".Dump();
$"Any() = {s3.Elapsed.TotalMilliseconds}".Dump();
