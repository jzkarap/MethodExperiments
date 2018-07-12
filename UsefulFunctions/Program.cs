﻿using System;
using System.Threading;

namespace UsefulFunctions
{
	class Program
	{
		static void Main(string[] args)
		{
			AnimateString("This is my string", .2, true);

			AnimateString("This is my string vertically", .2, false);

			Console.WriteLine("This will be your string:");

			string newString = Console.ReadLine();

			AnimateString(newString, .2, true);

			while (true)
			{
				Console.WriteLine("Do you want the delay between printed letters to change?? (y/n)");

				string answer = (Console.ReadLine()).ToLower();

				if (answer != "y")
				{
					Console.WriteLine("I can see we're done here. Goodbye!");
					return;
				}
				else
				{
					Console.WriteLine("How long would you like your delay to be? (0.1 - 1.0 seconds)");
				}

				double userDelay = Convert.ToDouble(Console.ReadLine());

				if (userDelay <= 0 || userDelay > 1)
				{
					Console.WriteLine("I can see we're done here. Goodbye!");
					return;
				}
				else
				{
					AnimateString(newString, userDelay, true);
				}
			}
		}

		/// <summary>
		/// Takes a string, a delay in seconds, and a choice between horizontal or vertical print,
		/// does a rudimentary animation using Thread.Sleep
		/// </summary>
		/// <param name="stringToPrint">The string to print</param>
		/// <param name="printDelayInSeconds">The delay between each printed letter</param>
		/// <param name="inline">A choice for either horizontal (inline) or vertical (block) printing</param>
		static void AnimateString(string stringToPrint, double printDelayInSeconds, bool inline)
		{
			int count = 0;
			// Thread.Sleep uses 1/1000s of second as parameter; must convert user choice to this increment
			int printDelay = (int)(printDelayInSeconds * 1000);
			// Playing around with variables to get code close to natural language
			int lengthOfString = stringToPrint.Length;

			while (count < lengthOfString)
			{
				if (inline == true)
				{
					Console.Write(stringToPrint[count]);
					Thread.Sleep(printDelay);
				}
				else
				{
					Console.WriteLine(stringToPrint[count]);
					Thread.Sleep(printDelay);
				}

				count++;
			}

			Thread.Sleep(printDelay);
			Console.WriteLine();
		}
	}
}
