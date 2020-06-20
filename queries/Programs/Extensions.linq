<Query Kind="Program" />

void Main()
{
    var array1 = new double[10];
    var array2 = new double[10];
    
    array1.Populate(21);
    array1.CopyTo(array2);
    array1.Clear();
    
    "\nPopulate, CopyTo and Clear:".Dump();
    $"Array 1: {string.Join(", ", array1)} ".Dump();
    $"Array 2: {string.Join(", ", array2)} ".Dump();
    
    "\nContains:".Dump();
    $"Array 1: {array1.Contains(21)}".Dump();
    $"Array 2: {array2.Contains(21)}".Dump();
    
    "\nSumSlow:".Dump();
    $"Array 1: {array1.SumSlow()}".Dump();
    $"Array 2: {array2.SumSlow()}".Dump();
}

public static class Utils
{
    public static void Populate<T>(this T[] source, T value)
    {
        for (var i = 0; i < source.Length; i++)
        {
            source[i] = value;
        }
    }
    
    public static void CopyTo<T>(this T[] source, T[] target)
    {
        Array.Copy(source, target, target.Length);
    }
        
    public static void Clear<T>(this T[] target)
    {
        if (target == null) return;

        for (int i = 0; i < target.Length; i++)
        {
            target[i] = default(T);
        }
    }
    
    public static bool Contains<T>(this T[] source, T value)
    {
        return Array.IndexOf(source, value) != -1;
    }
    
    public static double? SumSlow(this double[] array)
    {
        var total = 0d;
        
        for (int i = 0; i < array.Length; i++)
        {
            total += array[i];
        }
        
        return total;
    }
}