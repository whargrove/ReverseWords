using NUnit.Framework;

namespace ReverseWords
{
	[TestFixture]
	class ProgramTest
	{
		[TestCase("Use the force")]
		public void ReverseWords_ShouldReturnAString(string s)
		{
			// Given a string (see test cases)
			// When ReverseWords() is invoked
			var result = Program.ReverseWords(s);
			// The value of the return type should be a string
			Assert.That(result, Is.TypeOf(typeof(string)));
		}

		[TestCase("")]
		[TestCase(null)]
		public void ReverseWords_ShouldReturnAnEmptyString(string s)
		{
			// Given an empty or null string (see test cases)
			// When ReverseWords() is invoked
			var actual = Program.ReverseWords(s);
			var expected = string.Empty;
			// Then the output is an empty string
			Assert.AreEqual(expected, actual);
		}

		[TestCase("A long time ago in a galaxy far far away", "away far far galaxy a in ago time long A")]
		[TestCase("Hello, my name is George!", "!George is name my, Hello")]
		public void ReverseWords_ShouldReturnAStringWithWordsReversed(string s, string expected)
		{
			// Given a string (see test cases)
			// When ReverseWords() is invoked
			var actual = Program.ReverseWords(s);
			// Then the output is the string reversed by word
			Assert.AreEqual(expected, actual);
		}
	}
}
