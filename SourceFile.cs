using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scriptable
{
	class SourceFile
	{

		List<string> lines;
		public SourceFile(string fileName)
		{
			lines.AddRange(File.ReadAllLines(fileName));
		}

		/// <summary>
		/// set the java annotation in the method 
		/// below @scriptable in comments
		/// 
		/// 
		/// </summary>
		public void InsertScriptable()
		{
			int i = 0;
			while(i< lines.Count)
			{
				// search for @scriptable
				int idx = Find("@scriptable", i);
					if( idx >=0)
				{
					i = idx+1;
					// must be inside comments
					if( InsideComment(idx) && MethodWithoutScriptable(idx))
					{
						// find end of comment
						int idx2 = EndOfComent(idx);
							if( idx2 > idx )
						{
							i = idx2;
							// insert scriptable
						}

					}
				}


				// method below comments must not have @Scriptable




			}

		}

		/// <summary>
		/// find index to end of javadoc comment
		/// </summary>
		/// <param name="idx">starting index for search</param>
		/// <param name="maxLines">max number of lines to search for ending comment</param>
		/// <returns></returns>
		private int EndOfComent(int idx, int maxLines=100)
		{// */
			int count = 0;
			for (int i = idx; i<lines.Count ; i++)
			{

				if (Regex.IsMatch(lines[i], @"\s*\*/"))
					return i;

					count++;
				if (count > maxLines)
					return -1;
			}
			return -1;
		}

		private bool MethodWithoutScriptable(int idx)
		{
		
		}

		/// <summary>
		/// returns true if the input index is inside a java doc comment
		///  /** ... */"  
		///  http://www.drjava.org/docs/user/ch10.html
		/// </summary>
		/// <param name="idx"></param>
		/// 
		/// <returns>true if inside a comment other wise false</returns>
		private bool InsideComment(int idx)		{
			if (idx < 0 || idx >= lines.Count) 
				return false;
			// line starts with a *
			if (Regex.IsMatch(lines[idx], @"\s+\*"))
				return true;
		

			return false;
		}

		/// <summary>
		/// Finds a string s return index to that line
		/// </summary>
		/// <param name="s">string to serach for</param>
		/// <param name="startIndex">index to start search</param>
		/// <returns>index to string or negative is not foud</returns>
		int Find(string s, int startIndex=0)
		{
			int i = startIndex;
			while (i < lines.Count)
			{

				var idx = lines[i].IndexOf(s, StringComparison.CurrentCultureIgnoreCase);
				if (idx >= 0)
					return idx;

				i++;
			}
			return -1;
		}

	}
}
