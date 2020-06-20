<Query Kind="Statements" />

string number = "3333,38748378438";

var result1 = float.Parse(number, System.Globalization.CultureInfo.InvariantCulture);
result1.Dump();    // BAD

var result2 = float.Parse(number.ToString(System.Globalization.CultureInfo.InvariantCulture));
result2.Dump();    // GOOD