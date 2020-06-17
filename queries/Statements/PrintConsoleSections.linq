<Query Kind="Statements" />

var count = 0;
var separator = new string(Enumerable.Repeat('-', 40).ToArray());
Action<string> beginSection = title => Console.WriteLine($"\n{separator}\n{++count}) {title}:\n");

beginSection("Section A");

beginSection("Section B");

beginSection("Section C");
