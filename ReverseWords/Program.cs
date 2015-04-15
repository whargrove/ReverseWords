using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReverseWords
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 1)
			{
				Func<string, string> profileReverse = ReverseWords;
				Console.WriteLine("Using profile...");
				Profile(50, args[1], profileReverse);
			}
			else
			{
				Console.WriteLine("Reversing string...");
				Console.WriteLine(ReverseWords(args[0]));
			}

		}

		internal static string ReverseWords(string s)
		{
			if (string.IsNullOrEmpty(s))
				return string.Empty;

			var reversed = new StringBuilder();
			var split = s.Split(' ').ToList();
			for (var i = split.Count - 1; i >= 0; i--)
			{
				reversed.Append(string.Format("{0} ", split[i]));
			}
			reversed.Remove(s.Length, 1); // Remove the last character
			return reversed.ToString();
		}

		static void Profile(int iterations, string input, Func<string, string> reverse)
		{
			// Warm up
			reverse(input);

			var watch = new Stopwatch();

			// Clean up
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			watch.Start();
			for (int i = 0; i < iterations; i++)
			{
				reverse(input);
			}
			watch.Stop();
			Console.WriteLine("Average time per iteration: {0} ms", watch.Elapsed.TotalMilliseconds / iterations);
		}
	}
}
