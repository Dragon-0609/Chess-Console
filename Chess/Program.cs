using System;

namespace Chess
{
	internal class Program
	{
		[STAThread]
		public static void Main (string [] args)
		{
			new Game ();
		}

		public static int[] Read(string text)
		{
			string[] input = text.Split();
			return new int[] {int.Parse(input[0]) - 1, int.Parse(input[1]) - 1};
		}
	}
}