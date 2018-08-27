using System;
using System.Linq;
using System.Diagnostics;
					
public class Program
{
	
	public static void Main(string[] args)
	{
		
		const int n = 9999999;
		var rnd = new Random();
		var array = new int[n];
		
		for (var i = 0; i < n; i++)
		{
			array[i] = rnd.Next(0, int.MaxValue);
		}
		
        // Chose implementation or suggest your own. Explain your answer.
		IArraySorter _utility = new ArraySorterImpl_ ();
		var sorted = _utility.Sort(array);

        var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        Console.WriteLine($"Process working set: {currentProcess.WorkingSet64 / 1024 / 1024} MB");
        Console.WriteLine($"Process total CPU time: {currentProcess.TotalProcessorTime}");
        Console.WriteLine($"Process user CPU time: {currentProcess.UserProcessorTime}");
        Console.WriteLine(sorted.Length);
        Console.ReadKey();
	}
}

public interface IArraySorter
{
	int[] Sort(int[] array);
}

public class ArraySorterImpl_1: IArraySorter
{
	public int[] Sort(int[] array)
	{
		return array.OrderBy(x => x).ToArray();
	}
}

public class ArraySorterImpl_2: IArraySorter
{
	public int[] Sort(int[] array)
	{
		var sorted = new int[array.Length];
		Array.Copy(array, sorted, array.Length);
		Array.Sort(sorted);
		
		return sorted;
	}
}

public class ArraySorterImpl_3: IArraySorter
{
	public int[] Sort(int[] array)
	{
		var sortedList = array.ToList();
		sortedList.Sort();
		return sortedList.ToArray();
	}
}

