/// main source:  see description in accompanying README.md

namespace NameSorter
{
	using System.Linq;

	public class NameSorter
	{
		/// The meat of the solution;  separated out for unit testing
		/// <param>fileName</param> Name of text file containing names
		/// <returns>the contents of the file, sorted by surname over given names.</returns>
		public static string [] sortedNames (string fileName)
		{
			// read the content
			string [] names = System.IO.File.ReadAllLines(fileName);
			// get a parallel array for sorting
			var sortKey = names.Select(theLastWillBeFirst).ToArray();
			System.Array.Sort(sortKey, names);
			return names;
		}

		/// Entry point
		public static void Main (string [] args)
		{
			// Take each argument as a filename:
			foreach (string arg in args)
			{
				var names = sortedNames(arg);
				foreach (string name in names)
				{
					System.Console.WriteLine(name);
				}
				System.IO.File.WriteAllLines(@"sorted-names-list.txt", names);
			}
		}

		/// <param>multi-word name, surname last</param>
		/// <returns>the name with the surname placed at the front, for sorting</returns>
		private static string theLastWillBeFirst (string name)
		{
			// break up the name into words
			var names = name.Split(' ', System.StringSplitOptions.None);
			var length = names.Length;
			// put the surname at the front
			return names[length - 1] + ' ' + string.Join(' ', names, 0, length - 1);
		}
	}
}
