<Query Kind="Program" />

void Main()
{
    var generator = new RandomGenerator();
    var randomNumber = generator.RandomNumber(5, 100);
    Console.WriteLine($"Random number between 5 and 100 is { randomNumber }");

    var randomString = generator.RandomString(10, false);
    Console.WriteLine($"Random string of 10 chars is { randomString }");

    var randomPassword = generator.RandomPassword();
    Console.WriteLine($"Random string of 6 chars is { randomPassword }");
}

public class RandomGenerator
{
    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    // Generate a random string with a given size
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
		
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
		
        if (lowerCase)
            return builder.ToString().ToLower();
			
        return builder.ToString();
    }

    // Generate a random password
    public string RandomPassword()
    {
        StringBuilder builder = new StringBuilder();
		
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));
		
        return builder.ToString();
    }
}
