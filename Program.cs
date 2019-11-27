using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scriptable
{
	class Program
	{
		static void Main(string[] args)
		{
			if( args.Length !=1)
			{
				Console.WriteLine("Usage:  Scriptable.exe  dir");
				Console.WriteLine("Updates Java source, setting attribute @Scriptable ");
				return;
			}
			string[] files = Directory.GetFiles(args[0],
					 "*.java",
					 SearchOption.AllDirectories);

			// Display all the files.
			foreach (string file in files)
			{
				Console.WriteLine(file);
			}
		}
	}
}
