using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
namespace LZWDescomprimir
{
	public class LZW
	{
		/// <summary>
		/// Compress a string to a list of output symbols. </summary>
		public static List<int> Compresion(string uncompressed)
		{
			// Build the dictionary.
			int TamañoDiccionario = 256;

			int j = 0;
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, int> dictionaryP = new Dictionary<string, int>();
			for (int i = 0; i < 256; i++)
			{
				dictionary["" + (char)i] = i;
			}

			string w = "";
			List<int> result = new List<int>();

			foreach (char c in uncompressed.ToCharArray())
			{
				string wc = w + c;
				if (dictionary.ContainsKey(wc))
				{
					w = wc;
				}
				// dictionaryP.put(wc, dictSize++);
				else
				{
					result.Add(dictionary[w]);
					// Add wc to the dictionary.
					dictionary[wc] = TamañoDiccionario++;
					w = "" + c;
				}
			}

			// Output the code for w.
			if (!w.Equals(""))
			{
				result.Add(dictionary[w]);
			}

			int x = 1;
			string res = "";
			int[] vec = result.ToArray();
			for (int i = 0; i < result.Count; i++)
			{

				res = vec[i].ToString();
				dictionaryP[res] = x++;
			}

			for (int i = 0; i < dictionaryP.Count; i++)
			{
				//result2.Add(dictionary.Values[i]);
			}

			return result;
		}

		public static string Descompresion(List<int> compressed)
		{
			// Build the dictionary.
			int dictSize = 256;
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			for (int i = 0; i < 256; i++)
			{
				dictionary[i] = "" + (char)i;
			}

			string w = "" + (char)(int)compressed.ElementAt(0);
			compressed.RemoveAt(0);
			StringBuilder result = new StringBuilder(w);
			foreach (int k in compressed)
			{
				string entry;
				if (dictionary.ContainsKey(k))
				{
					entry = dictionary[k];
				}
				else if (k == dictSize)
				{
					entry = w + w[0];
				}
				else
				{
					throw new System.ArgumentException("Bad compressed k: " + k);
				}

				result.Append(entry);

				// Add w+entry[0] to the dictionary.
				dictionary[dictSize++] = w + entry[0];

				w = entry;
			}
			return result.ToString();
		}


	}
}
