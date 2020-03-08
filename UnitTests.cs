using NameSorter;

namespace UnitTests
{
	public class NameSorterTests
	{
		public NameSorterTests () {
			System.Console.WriteLine("Creating test object");
		}

		[NUnit.Framework.SetUp]
		public void GetReady()
		{
			System.Console.WriteLine("starting test");
		}

		[NUnit.Framework.TearDown]
		public void Clean()
		{
			System.Console.WriteLine("closing test");
		}

		/// The only test:
		/// Read the given file and check that each name is lexically after the previous.
		[NUnit.Framework.Test]
		public void monotonicSequence ()
		{
			var names = NameSorter.NameSorter.sortedNames("unsorted-names-list.txt");
			var prevName = "";
			var lineCount = 0;
			foreach (string line in names)
			{
				var surName = lastWord(line);
				NUnit.Framework.Assert.Greater(surName, prevName, "line " + lineCount);
				lineCount += 1;
				prevName = surName;
			}
		}

		private static string lastWord (string name)
		{
			var names = name.Split(' ', System.StringSplitOptions.None);
			var length = names.Length;
			return names[length - 1];
		}

		/// This should not be here;  see accompanying README.md
		public static void Main (string [] args)
		{
			var ns = new NameSorterTests();
			ns.GetReady();
			ns.monotonicSequence();
			ns.Clean();
		}
	}
}
