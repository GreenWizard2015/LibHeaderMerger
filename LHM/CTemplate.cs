using System.IO;
using CORE;

namespace LHM {
	public class CTemplate {
		private readonly CPath _destDir;
		private readonly CFileEntry _file;

		public CTemplate(CPath destDir, CFileEntry file) {
			_destDir = destDir;
			_file = file;
		}

		public string Name {
			get { return _file.Name; }
		}

		public string content() {
			return _file.content();
		}

		public void put(string content) {
			var destPath = _destDir.resolve(_file.Name).changeExtension(".h");
			System.IO.Directory.CreateDirectory(destPath.parent().Normalized);
			File.WriteAllText(destPath.Normalized, content);
		}

		public CPath Directory() {
			return _file.Dir;
		}
	}
}