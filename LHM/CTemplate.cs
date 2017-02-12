using System;
using CORE;

namespace LHM {
	public class CTemplate {
		private readonly CPath _dest;
		private readonly CFileEntry _file;

		public CTemplate(CPath dest, CFileEntry file) {
			_dest = dest.resolve(file.Name);
			_file = file;
		}

		public string content() {
			return _file.content();
		}

		public void put(string content) {
			Console.WriteLine("Source file: " + _file.FullName);
			Console.WriteLine("Destination file: " + _dest.Normalized);
// 			Console.WriteLine("Content:");
// 			Console.WriteLine(content);
			Console.WriteLine("--------------------------");
		}

		public CPath Directory() {
			return _file.Dir;
		}
	}
}