using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Reversing string...");
			Console.WriteLine(ReverseWords(args[0]));
		}

		internal static string ReverseWords(string s)
		{
			if (string.IsNullOrEmpty(s))
				return string.Empty;

			var reversed = new StringBuilder();
			var split = s.Split(' ').ToList();
			for (var i = split.Count - 1; i >= 0; i--)
			{
				reversed.Append(string.Format("{0}{1}", split[i], i == 0 ? string.Empty : " "));
			}
			return reversed.ToString();
		}
	}
}
