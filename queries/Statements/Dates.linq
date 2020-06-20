<Query Kind="Statements" />

var separator = new string(Enumerable.Repeat('-', 40).ToArray());

// Default date
new DateTime().Dump();
separator.Dump();

// Now date
DateTime.Now.Dump();
separator.Dump();

// Specific date
new DateTime(2042, 12, 24).Dump();
separator.Dump();

// Date with time
new DateTime(2042, 12, 24, 18, 42, 0).Dump();
separator.Dump();

// Date without time
new DateTime(2042, 12, 24, 18, 42, 0).Date.Dump();
separator.Dump();

// Short Date String
DateTime.Now.ToShortDateString().Dump();
separator.Dump();

// Long Date String
DateTime.Now.ToLongDateString().Dump();
separator.Dump();

// Specific region
var usCulture = new System.Globalization.CultureInfo("en-US");
DateTime.Now.ToString(usCulture.DateTimeFormat).Dump();
separator.Dump();

// Standard formats
DateTime dt = new DateTime(2042, 12, 24, 18, 42, 0);  
$"Short date pattern (d): { dt.ToString("d") }".Dump();
$"Long date pattern (D): { dt.ToString("D") }".Dump();
$"Full date/time pattern (F): { dt.ToString("F") }".Dump();
$"Year/month pattern (y): { dt.ToString("y") }".Dump();
separator.Dump();

// Personal formats
dt.ToString("MM'/'dd yyyy").Dump();
dt.ToString("dd.MM.yyyy").Dump();
dt.ToString("MM.dd.yyyy HH:mm").Dump();
dt.ToString("dddd, MMMM (yyyy): HH:mm:ss").Dump();
dt.ToString("dddd @ hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).Dump();
separator.Dump();

// Building Dates
var dateString = "7/6/2020";
DateTime userDate;
if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDate))
    Console.WriteLine("Valid date entered (long date format): " + userDate.ToLongDateString());
else
    Console.WriteLine("Invalid date specified!");