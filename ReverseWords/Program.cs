using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReverseWords
{
	class Program
	{
		private const string S = "A long time ago in a galaxy far far away";
		private const string L = "Whatever placeat Marfa, cornhole fingerstache qui kitsch occupy butcher dolor sapiente ullamco ennui. American Apparel voluptate Tumblr, readymade retro Williamsburg eiusmod et disrupt Schlitz. Tofu beard narwhal dolor mustache, occupy adipisicing et DIY nostrud raw denim farm-to-table four loko Thundercats put a bird on it. Aesthetic distillery occupy synth, pariatur cred Vice deserunt sapiente you probably haven't heard of them consequat American Apparel. Ea odio leggings tofu tattooed tote bag. Umami health goth mollit in synth put a bird on it. Mollit labore Godard, excepteur chillwave proident gluten-free aesthetic.";
		private const string XL = "Meggings 90's 3 wolf moon, ut Neutra mustache reprehenderit chambray Bushwick lomo butcher. Vice bicycle rights ad lo-fi, chia Pitchfork Blue Bottle eiusmod artisan drinking vinegar. Esse duis PBR&B, eiusmod VHS Blue Bottle Tumblr four loko occaecat gluten-free shabby chic asymmetrical wayfarers. Gastropub bitters narwhal nesciunt tousled eu, sustainable exercitation asymmetrical gentrify Helvetica. Ennui stumptown photo booth vinyl non veniam. Skateboard meh farm-to-table wayfarers scenester. Small batch Tumblr pariatur banh mi. Whatever placeat Marfa, cornhole fingerstache qui kitsch occupy butcher dolor sapiente ullamco ennui. American Apparel voluptate Tumblr, readymade retro Williamsburg eiusmod et disrupt Schlitz. Tofu beard narwhal dolor mustache, occupy adipisicing et DIY nostrud raw denim farm-to-table four loko Thundercats put a bird on it. Aesthetic distillery occupy synth, pariatur cred Vice deserunt sapiente you probably haven't heard of them consequat American Apparel. Ea odio leggings tofu tattooed tote bag. Umami health goth mollit in synth put a bird on it. Mollit labore Godard, excepteur chillwave proident gluten-free aesthetic. Skateboard esse delectus trust fund, forage Williamsburg Shoreditch heirloom eu authentic PBR&B voluptate Banksy. Craft beer single-origin coffee cray cliche 90's. Accusamus quinoa nesciunt, pariatur irure cred jean shorts you probably haven't heard of them Pitchfork chia VHS cronut disrupt. Lo-fi fingerstache 3 wolf moon, fashion axe seitan culpa XOXO readymade Vice iPhone retro cronut. Velit incididunt wolf laboris assumenda Neutra, Pitchfork deserunt ugh cliche mustache esse cardigan. Labore Marfa consectetur, consequat odio Helvetica minim art party seitan craft beer four dollar toast sapiente squid duis. VHS aute Vice, 90's voluptate beard Echo Park officia Wes Anderson. Taxidermy quinoa direct trade put a bird on it, beard you probably haven't heard of them blog flexitarian sed mustache post-ironic adipisicing Odd Future Austin kitsch. Enim meh pariatur Pitchfork. Normcore shabby chic flexitarian Pitchfork. Commodo iPhone next level Carles, officia fingerstache excepteur laboris plaid drinking vinegar DIY vinyl yr swag. Mustache gastropub listicle, deserunt authentic butcher farm-to-table scenester fixie Odd Future gentrify wayfarers voluptate. Freegan sunt gastropub, deep v distillery hella exercitation. Viral biodiesel Brooklyn, id eu gastropub pug umami Williamsburg High Life Pinterest meditation small batch.";

		static void Main(string[] args)
		{
			if (string.Equals(args[0], "profile"))
			{
				Func<string, string> profileReverse = ReverseWords;
				Console.WriteLine("Using profile...");
				switch (args[1])
				{
					case "small":
						Profile(50, S, profileReverse);
						break;
					case "large":
						Profile(50, L, profileReverse);
						break;
					case "extra-large":
						Profile(50, XL, profileReverse);
						break;
					default:
						Console.WriteLine("Invalid input length. Use small, large, or extra-large");
						break;
				}
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
