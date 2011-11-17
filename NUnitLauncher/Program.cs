using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace NUnitLauncher
{
	class Program
	{
		public static int Main(string[] args)
		{
			if(args.Length <= 0)
			{
				Console.WriteLine("Please provide the directory to search for test assemblies.");
				return -1;
			}

			List<string> testAssemblies = new List<string>();
			foreach(string file in Directory.GetFiles(args[0], "*.Tests.dll", SearchOption.AllDirectories))
			{
				string[] pathParts = file.Split(Path.DirectorySeparatorChar);

				if(pathParts[pathParts.Length - 3] == "bin")
				{
					testAssemblies.Add(file);
				}
			}

			if(testAssemblies.Count == 1)
			{
				// NUnit needs to be on your PATH
				ProcessStartInfo startInfo = new ProcessStartInfo()
				{
					FileName = "nunit",
					Arguments = "\"" + testAssemblies[0] + "\" /run"
				};

				Process.Start(startInfo);
				return 0;
			}
			else if(testAssemblies.Count > 1)
			{
				// TODO: Add support for multiple assemblies
				Console.WriteLine("No test assemblies found...");
				Console.ReadKey();
				return -1;
			}
			else
			{
				Console.WriteLine("No test assemblies found...");
				Console.ReadKey();
				return -1;
			}
		}
	}
}
